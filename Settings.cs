using Newtonsoft.Json;
using SpotifyAPI.Web;
using System.IO;
using System.Threading.Tasks;

namespace SpotifyMiniplayer
{
    internal class Settings
    {
        public PKCETokenResponse? Token = null;
        public string ClientID = "";
        public int UpdateInterval = 2000;
        public int TextScrollingSpeed = 10;
        public int TextScrollingDelay = 10000;
        public float Scale = 1;

        public static async Task<Settings> LoadFromFile(string path = "settings.json")
        {
            if (!File.Exists(path))
            {
                var settigns = new Settings();
                await settigns.SaveToFile(path);
                return settigns;
            }

            var content = await File.ReadAllTextAsync(path);
            var settings = JsonConvert.DeserializeObject<Settings>(content);
            if (settings == null) settings = new Settings();
            return settings;
        }

        public async Task SaveToFile(string path = "settings.json")
        {
            await File.WriteAllTextAsync(path, JsonConvert.SerializeObject(this));
        }
    }
}
