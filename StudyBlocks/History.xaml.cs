using System;
using System.Collections.Generic;
using StudyBlocks.Model;
using StudyBlocks.Services; 

using Xamarin.Forms;

namespace StudyBlocks
{
    public partial class History : ContentPage
    {
        public History()
        {
            InitializeComponent();
        }


        async void Handle_ClickedAsync(object sender, System.EventArgs e)
		{
            StudyBlockList.IsVisible = true;
            List<StudyBlock> studyBlockInformation = await AzureManager.AzureManagerInstance.GetStudyBlockInformation();

			StudyBlockList.ItemsSource = studyBlockInformation;
		}
	}
}
