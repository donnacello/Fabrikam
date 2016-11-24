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

            //////////////////////////////////////////

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }


    }
}
