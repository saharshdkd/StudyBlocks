using System;
namespace StudyBlocks
{
	public static class Constants
	{
		public static readonly string AuthenticationTokenEndpoint = "https://api.cognitive.microsoft.com/sts/v1.0";

		public static readonly string BingSpeechApiKey = "0e78692cb5bc4872aad5ee18375dbd7d";
		public static readonly string SpeechRecognitionEndpoint = "https://speech.platform.bing.com/speech/recognition/dictation/cognitiveservices/v1?language=en-NZ";
		public static readonly string AudioContentType = @"audio/wav; codec=""audio/pcm""; samplerate=16000";

		public static readonly string AudioFilename = "Todo.wav";
	}

}
