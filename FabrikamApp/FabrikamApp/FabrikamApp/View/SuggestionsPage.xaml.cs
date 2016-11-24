using Microsoft.ProjectOxford.Emotion;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using static Android.Manifest;

namespace FabrikamApp.View
{
    public partial class SuggestionsPage : ContentPage
    {
        
        public SuggestionsPage()
        {
            InitializeComponent();
            
        }

        private async void TakePicture_Clicked(object sender, System.EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                Directory = "FabrikamApp",
                Name = $"{DateTime.UtcNow}.jpg",
                CompressionQuality = 50
            });

            if (file == null)
                return;

            try
            {
                SPcircle.IsRunning = true;
                string emotionKey = "b728b031f2874a729b65ffb6f3ed5fb8";
                EmotionServiceClient emotionClient = new EmotionServiceClient(emotionKey);
                var results = await emotionClient.RecognizeAsync(file.GetStream());

                double temp = results[0].Scores.Happiness;
                double percent = temp * 100;

                await DisplayAlert("Happiness Level","You are "+ percent + "% happy","Ok");

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
