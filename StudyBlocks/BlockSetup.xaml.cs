using System;
using System.Collections.Generic;
using StudyBlocks.Model;
using System.Diagnostics;
using System.Linq;


using Xamarin.Forms;

namespace StudyBlocks
{
    public partial class BlockSetup : ContentPage
    {
        public BlockSetup()
        {
            InitializeComponent();

            Padding = new Thickness(10, 20, 10, 10);










            StudyBlock blockItem = new StudyBlock();

            Begin.Clicked += async (sender, args) =>
            {
                blockItem.Topic += Topic.Text;
                blockItem.Location += Location.Text;
                blockItem.Goal += Goal.Text;
                blockItem.StartTime += DateTime.Now.ToString("T");
                await Navigation.PushAsync(new Distracted(blockItem));
               


            };


        }

        void SetButtonEnable(object sender, EventArgs e)
        {
            Begin.IsEnabled = true;
        }

    }

}
