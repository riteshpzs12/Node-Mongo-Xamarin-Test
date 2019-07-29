using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebDeepDa
{
    class MyModel
    {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("pass")]
            public string Pass { get; set; }

            [JsonProperty("imagesrc")]
            public string Imagesrc { get; set; }

            [JsonProperty("uid")]
            public string Uid { get; set; }

            [JsonProperty("manager")]
            public string Manager { get; set; }

            [JsonProperty("Role")]
            public string Role { get; set; }

            [JsonProperty("location")]
            public string Location { get; set; }

            [JsonProperty("geo")]
            public string Geo { get; set; }

            [JsonProperty("device_id")]
            public string DeviceId { get; set; }

    }
}
