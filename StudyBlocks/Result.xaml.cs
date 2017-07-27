using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StudyBlocks
{
    public partial class Result : ContentPage
    {
        public Result()
        {
            InitializeComponent();

			NavigationPage.SetHasBackButton(this, true);

            /*Test.Clicked += OnButtonClicked;*/

            /*Home.Clicked += async (sender, args) =>
            {
                await Navigation.PopToRootAsync();
            };*/

        }

		/*void OnButtonClicked(object sender, EventArgs e)
		{
            Results.Text = "Started at: " + Block.CurrentTime + "\n"
						   + "Ended at: " + Block.EndTime + "\n"
						   + "Topic: " + Block.Topic;
		}*/

	}
  
}
