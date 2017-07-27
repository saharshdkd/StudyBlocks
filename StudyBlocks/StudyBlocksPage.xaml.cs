using Xamarin.Forms;
using System;
using StudyBlocks.Model;

namespace StudyBlocks
{
    public partial class StudyBlocksPage : ContentPage
    {
        public StudyBlocksPage()
        {
            InitializeComponent();

            Padding = new Thickness(5, 20, 5, 0);

            //NavigationPage.SetHasBackButton(this, false);

            NavigationPage.SetHasNavigationBar(this, false);

            var fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "Study", FontSize = 30, FontAttributes = FontAttributes.Bold });
            fs.Spans.Add(new Span { Text = "Blocks", FontSize = 30, FontAttributes = FontAttributes.Italic });

            Title.FormattedText = fs;

            Setup.FontSize = 10;

            History.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new History());
            };

       
        }


        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BlockSetup());
        }
	
    }
}