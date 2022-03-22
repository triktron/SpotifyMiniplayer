using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SpotifyMiniplayer
{
    internal class ProgressBar : Panel
    {
        private Color backgroundColor = Color.White;
        private Color foregroundColor = Color.Black;
        private float percentage = .3f;

        [Category("Progress bar")]
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                Invalidate();
            }
        }

        [Category("Progress bar")]
        public Color ForegroundColor
        {
            get { return foregroundColor; }
            set
            {
                foregroundColor = value;
                Invalidate();
            }
        }

        [Category("Progress bar")]
        public float Percentage
        {
            get { return percentage; }
            set
            {
                percentage = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality;

            using var backgroundBrush = new SolidBrush(backgroundColor);
            var backgroundArea = new Rectangle(new Point(0, 0), new Size(this.Size.Width, this.Size.Height));
            var backgroundRect = GetRoundRectagle(backgroundArea, this.Size.Height);
            g.SetClip(backgroundRect);
            g.FillRectangle(backgroundBrush, backgroundArea);

            using var foregroundBrush = new SolidBrush(foregroundColor);
            var foregroundArea = new Rectangle(new Point(0, 0), new Size((int)((this.Size.Width - 1) * percentage), this.Size.Height - 1));
            g.FillPath(foregroundBrush, GetRoundRectagle(foregroundArea, this.Size.Height));

            backgroundBrush.Dispose();
            foregroundBrush.Dispose();
        }

        private GraphicsPath GetRoundRectagle(Rectangle bounds, int radius)
        {
            float r = radius;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.Left, bounds.Top, r, r, 180, 90);
            path.AddArc(bounds.Right - r, bounds.Top, r, r, 270, 90);
            path.AddArc(bounds.Right - r, bounds.Bottom - r, r, r, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
