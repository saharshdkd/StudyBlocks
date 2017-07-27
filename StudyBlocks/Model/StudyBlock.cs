using System;
using System.ComponentModel;
using Newtonsoft.Json;


namespace StudyBlocks.Model
{
    public class StudyBlock
    {
		[JsonProperty(PropertyName = "id")]
		public string ID { get; set; }

		[JsonProperty(PropertyName = "StartTime")]
		public string StartTime { get; set; }

		[JsonProperty(PropertyName = "EndTime")]
		public string EndTime { get; set; }

		[JsonProperty(PropertyName = "Topic")]
		public string Topic { get; set; }

		[JsonProperty(PropertyName = "Location")]
		public string Location { get; set; }

		[JsonProperty(PropertyName = "Goal")]
        public string Goal { get; set; }

        [JsonProperty(PropertyName = "Reason")]
        public string Reason { get; set; }

    }
}
