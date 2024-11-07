using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace poczta
{
    public partial class MainPage : ContentPage
    {
        public class Country
        {
            [JsonPropertyName("post code")]
            public string? post_code { get; set; }
            public string? country { get; set; }
            [JsonPropertyName("country abbreviation")]
            public string? country_abbreviation { get; set; }
            public IList<Places> places { get; set; }
        }

        public class Places
        {
            [JsonPropertyName("place name")]
            public string? place_name { get; set; }
            public string? longitude { get; set; }
            public string? state { get; set; }
            [JsonPropertyName("state abbreviation")]
            public string? state_abbreviation { get; set; }
            public string? latitude { get; set; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
        private void OnCounterClicked(object sender, EventArgs e)
        {
            string k = kraj.Text;
            string kp = kodp.Text;
            string url1 = "https://api.zippopotam.us/" + k + "/" + kp;
            string json;
            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(url1);
            }
            Country c = JsonSerializer.Deserialize<Country>(json);
            string s = $"post code: {c.post_code}\n";
            s += $"country: {c.country}\n";
            s += $"country abbreviation: {c.country_abbreviation}\n";
            s += $"place name: {c.places[0].place_name}\n";
            s += $"longitude: {c.places[0].longitude}\n";
            s += $"state: {c.places[0].state}\n";
            s += $"state abbreviation: {c.places[0].state_abbreviation}\n";
            s += $"latitude: {c.places[0].latitude}\n";
            wynik.Text = s;
        }
    }
}
