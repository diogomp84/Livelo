using AutoWebFramework.Base;
using Newtonsoft.Json;

namespace AutoWebFramework.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("aut")]
        public string AUT { get; set; }

        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }

    }
}
