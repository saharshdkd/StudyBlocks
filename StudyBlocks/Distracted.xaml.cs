using System;
using System.Collections.Generic;
using StudyBlocks.Model;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using StudyBlocks.Services;
using System.Linq;
using System.Diagnostics;
using Newtonsoft.Json;


namespace StudyBlocks
{
    public partial class Distracted : ContentPage
    {
		IBingSpeechService bingSpeechService;
		bool isRecording = false;

		public static readonly BindableProperty StudyBlockProperty =
            BindableProperty.Create("StudyBlock", typeof(StudyBlock), typeof(Distracted), null);

        public StudyBlock StudyBlock
		{
			get { return (StudyBlock)GetValue(StudyBlockProperty); }
			set { SetValue(StudyBlockProperty, value); }
		}

        /*string speechResult;*/

		public static readonly BindableProperty IsProcessingProperty =
            BindableProperty.Create("IsProcessing", typeof(bool), typeof(Distracted), false);

		public bool IsProcessing
		{
			get { return (bool)GetValue(IsProcessingProperty); }
			set { SetValue(IsProcessingProperty, value); }
		}

        public Distracted(StudyBlock studyBlockItem)
        {
            InitializeComponent();

            bingSpeechService = new BingSpeechService(new AuthenticationService(Constants.BingSpeechApiKey));

            Padding = new Thickness(10, 0, 10, 0);

            Reason.FontSize = 12;

            StudyBlock model = new StudyBlock
			{
				StartTime = studyBlockItem.StartTime,
                EndTime = studyBlockItem.EndTime,
                Topic = studyBlockItem.Topic,
                Location = studyBlockItem.Location,
                Goal = studyBlockItem.Goal,
			};

			NavigationPage.SetHasBackButton(this, false);


			Boom.Clicked += async (sender, args) =>
            {
                Boom.IsVisible = false;
                model.EndTime += DateTime.Now.ToString("T");
                Results.IsVisible = true;
                Results.FormattedText = CheckGoalStatus(model);
                SpeechArea.IsVisible = true;
                await AzureManager.AzureManagerInstance.PostStudyBlockInformation(model);
            };


            Home.Clicked += async (sender, args) =>
            {
                await Navigation.PopToRootAsync();
            };

        }

		async void OnRecognizeSpeechButtonClicked(object sender, EventArgs e)
		{
			try
			{
				var audioRecordingService = DependencyService.Get<IAudioRecorderService>();
				if (!isRecording)
				{
					audioRecordingService.StartRecording();

					((Button)sender).Image = "microphone.png";
					IsProcessing = true;
				}
				else
				{
					audioRecordingService.StopRecording();
				}

				isRecording = !isRecording;
				if (!isRecording)
				{
                    Debug.WriteLine("This is where");
                    string speechResult = await bingSpeechService.RecognizeSpeechAsync(Constants.AudioFilename);
                    Debug.WriteLine("Result: " + speechResult);
                    DisplayResult.Text += speechResult;
                    /*Debug.WriteLine("Confidence: " + speechResult.Confidence);*/

					/*if (!string.IsNullOrWhiteSpace(speechResult.Name))
					{
						StudyBlock.Reason = char.ToUpper(speechResult.Name[0]) + speechResult.Name.Substring(1);
						OnPropertyChanged("StudyBlock");
					}*/
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			finally
			{
				if (!isRecording)
				{
					((Button)sender).Image = "microphone.png";
					IsProcessing = false;
				}
			}
		}


        public FormattedString CheckGoalStatus(StudyBlock item)
        {
            var fs = new FormattedString();
            DateTime start = DateTime.Parse(item.StartTime);
            DateTime end = DateTime.Parse(item.EndTime);
            TimeSpan diff = end.Subtract(start);
            string difference = diff.Minutes.ToString();
            if (Int32.Parse(difference) > Int32.Parse(item.Goal) || Int32.Parse(difference) == Int32.Parse(item.Goal) )
            {
                fs.Spans.Add(new Span { Text = "Congratulations!", FontSize = 20, FontAttributes = FontAttributes.Bold });
                fs.Spans.Add(new Span { Text = " you studied for ", FontSize = 15, FontAttributes = FontAttributes.Italic });
                fs.Spans.Add(new Span { Text = difference + " minutes.", FontSize = 15, FontAttributes = FontAttributes.Bold });
                return fs;///"Congratulations you studied for " + difference + " minutes";
            }
            else
            {
                fs.Spans.Add(new Span { Text = "Sucks!", FontSize = 20, FontAttributes = FontAttributes.Bold });
                fs.Spans.Add(new Span { Text = " you studied for ", FontSize = 15, FontAttributes = FontAttributes.Italic });
                fs.Spans.Add(new Span { Text = difference + " minutes.", FontSize = 15, FontAttributes = FontAttributes.Bold });
                return fs;///"Sucks! you only studied for " + difference + " minutes";
            }


        }

        /*DateTime.Parse(item.EndTime).Subtract(DateTime.Parse(item.StartTime)).ToString("T")*/
		/*Results.Text = "Started at: " + model.StartTime + "\n"
                + "Ended at: " + model.EndTime + "\n"
                    + "Topic: " + model.Topic;*/




		/*async Task postStudyBlockAsync()
		{

			StudyBlock model = new StudyBlock()
			{
				StartTime = endModel.start,
				EndTime = end,
				Topic = (string)block.Topic,
				Location = (string)block.Location,
				Goal = block.Goal

			};



			await AzureManager.AzureManagerInstance.PostStudyBlockInformation(model);
		}*/


	}
}
