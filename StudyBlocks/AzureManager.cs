using System;
using Microsoft.WindowsAzure.MobileServices;
using StudyBlocks.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyBlocks
{
	public class AzureManager
	{
		private static AzureManager instance;
		private MobileServiceClient client;
		private IMobileServiceTable<StudyBlock> studyblockTable;

		private AzureManager()
		{
			this.client = new MobileServiceClient("http://studyblocks.azurewebsites.net");
			this.studyblockTable = this.client.GetTable<StudyBlock>();


		}

		public MobileServiceClient AzureClient
		{
			get { return client; }
		}

		public static AzureManager AzureManagerInstance
		{
			get
			{
				if (instance == null)
				{
					instance = new AzureManager();
				}

				return instance;
			}

		}

		public async Task<List<StudyBlock>> GetStudyBlockInformation()
		{
			return await this.studyblockTable.ToListAsync();
		}

		public async Task PostStudyBlockInformation(StudyBlock studyblock)
		{
			await this.studyblockTable.InsertAsync(studyblock);
		}

	}
}

