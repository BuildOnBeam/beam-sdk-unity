using System;
using Newtonsoft.Json;

namespace Beam.Models
{
    public class BeamSession
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("entityId")] public string EntityId { get; set; }
        [JsonProperty("sessionAddress")] public string SessionAddress { get; set; }
        [JsonProperty("startTime")] public DateTimeOffset StartTime { get; set; }
        [JsonProperty("endTime")] public DateTimeOffset EndTime { get; set; }
    }
}