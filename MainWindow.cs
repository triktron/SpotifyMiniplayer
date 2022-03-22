using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyMiniplayer
{
    public partial class MainWindow : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        private Settings settings = new Settings();

        private readonly List<string> Scopes = new List<string> {
            SpotifyAPI.Web.Scopes.UserReadPlaybackState,
            SpotifyAPI.Web.Scopes.Streaming,
        };

        private readonly EmbedIOAuthServer _server = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);
        private SpotifyClient _client = new SpotifyClient("");

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public MainWindow()
        {
            InitializeComponent();
            SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        private void DragWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void ScaleWindow(float factor = 1)
        {
            Console.WriteLine($"Scaling Window");

            Scale(new SizeF(factor, factor));
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            foreach (Control control in this.Controls)
            {
                var font = control.Font;
                control.Font = new Font(font.FontFamily, font.Size * factor);

                if (control is ScrollingLabel label)
                {
                    label.AvailebleWidth = (int)(label.AvailebleWidth * factor);
                }
            }
        }

        private async void OnLoad(object sender, EventArgs e)
        {
            await StartSpotify();
        }

        private async Task StartSpotify()
        {
            settings = await Settings.LoadFromFile();

            SongTitle.Speed = settings.TextScrollingSpeed;
            SongTitle.Delay = settings.TextScrollingDelay;

            ArtistsNames.Speed = settings.TextScrollingSpeed;
            ArtistsNames.Delay = settings.TextScrollingDelay;

            ScaleWindow(settings.Scale);

            if (settings.Token == null)
            {
                await StartAuthentication();
            }
            else
            {
                await StartSpotifyClient();
            }
        }

        private async Task StartAuthentication()
        {
            var (verifier, challenge) = PKCEUtil.GenerateCodes();

            await _server.Start();
            _server.AuthorizationCodeReceived += async (sender, response) =>
            {
                await _server.Stop();
                settings.Token = await new OAuthClient().RequestToken(
                  new PKCETokenRequest(settings.ClientID, response.Code, _server.BaseUri, verifier)
                );
                await settings.SaveToFile();

                await StartSpotifyClient();
            };

            var request = new LoginRequest(_server.BaseUri, settings.ClientID, LoginRequest.ResponseType.Code)
            {
                CodeChallenge = challenge,
                CodeChallengeMethod = "S256",
                Scope = Scopes
            };

            Uri uri = request.ToUri();
            BrowserUtil.Open(uri);
        }

        private async Task StartSpotifyClient()
        {
            var authenticator = new PKCEAuthenticator(settings.ClientID, settings.Token!);
            authenticator.TokenRefreshed += async (sender, token) =>
            {
                settings.Token = token;
                await settings.SaveToFile();
            };

            var config = SpotifyClientConfig.CreateDefault().WithAuthenticator(authenticator);

            _client = new SpotifyClient(config);

            _server.Dispose();

            UpdateInfoTimer.Interval = settings.UpdateInterval;
            UpdateInfoTimer.Tick += async (object? sender, EventArgs e) => await UpdateInfo();
            UpdateInfoTimer.Start();
            await UpdateInfo();
        }

        private async Task UpdateInfo()
        {
            var state = await _client.Player.GetCurrentPlayback();
            if (state == null || state.Item == null || state.Item is not FullTrack track)
            {
                ProgressBar.Percentage = 0;
                SongTitle.Text = "No track playing";
                ArtistsNames.Text = "";
                Cover.Image = Properties.Resources.NoTrack;
            }
            else
            {
                PlayButton.Invoke((MethodInvoker)delegate
                {
                    ShuffleButton.SetState(state.ShuffleState);
                    LoopButton.SetState(state.RepeatState != "off");
                    PlayButton.SetState(state.IsPlaying);
                    ProgressBar.Percentage = (float)state.ProgressMs / (float)track.DurationMs;
                    SongTitle.Text = track.Name;
                    ArtistsNames.Text = String.Join(", ", track.Artists.Select(a => a.Name));
                    Cover.Load(track.Album.Images.First().Url);
                });
            }
        }

        private async void TogglePlay(object sender, EventArgs e)
        {
            try
            {
                if (!PlayButton.IsActive)
                {
                    await _client.Player.PausePlayback();
                }
                else
                {
                    await _client.Player.ResumePlayback();
                }
            }
            catch (Exception)
            {
            }
        }

        private async void PrevSong(object sender, EventArgs e)
        {
            try
            {
                await _client.Player.SkipPrevious();
                await UpdateInfo();
            }
            catch (Exception)
            {
            }
        }

        private async void NextSong(object sender, EventArgs e)
        {
            try
            {
                await _client.Player.SkipNext();
                await UpdateInfo();
            }
            catch (Exception)
            {
            }
        }

        private async void Shuffle(object sender, EventArgs e)
        {
            try
            {
                await _client.Player.SetShuffle(new PlayerShuffleRequest(ShuffleButton.IsActive));
            }
            catch (Exception)
            {
            }
        }

        private async void Loop(object sender, EventArgs e)
        {
            try
            {
                if (!LoopButton.IsActive)
                {
                    await _client.Player.SetRepeat(new PlayerSetRepeatRequest(PlayerSetRepeatRequest.State.Off));
                }
                else
                {
                    await _client.Player.SetRepeat(new PlayerSetRepeatRequest(PlayerSetRepeatRequest.State.Context));
                }
            }
            catch (Exception)
            {
            }
        }

        private async void SeekTo(object sender, MouseEventArgs e)
        {
            float percentage = (float)e.X / (float)ProgressBar.Width;

            try
            {
                var state = await _client.Player.GetCurrentPlayback();
                if (state == null || state.Item == null || state.Item is not FullTrack track) return;

                await _client.Player.SeekTo(new PlayerSeekToRequest((long)(track.DurationMs * percentage)));
                await UpdateInfo();
            }
            catch (Exception)
            {
            }
        }
    }
}