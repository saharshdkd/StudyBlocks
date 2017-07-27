using System;
using System.Threading.Tasks;


namespace StudyBlocks.Services
{
	public interface IAuthenticationService
	{
		Task InitializeAsync();
		string GetAccessToken();
	}
}
