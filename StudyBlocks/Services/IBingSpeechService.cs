using System;
using System.Threading.Tasks;
using StudyBlocks.Model;


namespace StudyBlocks.Services
{
	public interface IBingSpeechService
	{
        Task<string> RecognizeSpeechAsync(string filename);
	}
}
