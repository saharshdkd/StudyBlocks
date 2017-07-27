using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StudyBlocks.Model
{
    [JsonObject("result")]
    public class SpeechResult
    {
        public string RecognitionStatus { get; set; }
        public string DisplayText { get; set; }
        public string Offset { get; set; }
        public string Duration { get; set; }
        /*public string Confidence { get; set; }*/
        //public List<SpeechResults> FinalResults { get; set; }
    }

    public class SpeechResults
    {
        public string Confidence { get; set; }
        public string Lexical { get; set; }
        public string ITN { get; set; }
        public string MaskedITN { get; set; }
        public string Display { get; set; }
    }
}
