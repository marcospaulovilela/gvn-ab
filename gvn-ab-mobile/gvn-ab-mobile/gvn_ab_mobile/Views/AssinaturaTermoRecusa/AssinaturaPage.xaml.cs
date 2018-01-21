using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views.AssinaturaTermoRecusa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssinaturaPage : ContentPage
    {
        public AssinaturaPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public Models.AssinaturaTermoRecusa.TermoDeRecusaModel TermoDeRecusa => App.Current.TermoDeRecusa;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            RestoreSignature();
        }

        private void OnBackClicked(object sender, EventArgs e)
        {
            // don't save picture on back
            SaveSignatureAsync(false);

            Navigation.PopAsync();
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            if (signaturePad.IsBlank)
            {
                await DisplayAlert("Sem Assinatura", "Nenhuma assinatura detectada. Por favor, tenha certeza de que assinou acima da linha.", "OK");
                return;
            }

            // save all on next
            await SaveSignatureAsync(true);

            await Navigation.PushAsync(new ConfirmacaoPage());
        }

        private void RestoreSignature()
        {
            var pd = App.Current.TermoDeRecusa;

            // just to make sure
            signaturePad.Clear();

            // load the saved signature
            if (pd.SignaturePoints != null)
            {
                signaturePad.Points = pd.SignaturePoints;
            }
        }

        private async Task SaveSignatureAsync(bool saveImage)
        {
            IsBusy = true;

            var pd = App.Current.TermoDeRecusa;

            // save the signature points
            pd.SignaturePoints = signaturePad.Points.ToList();

            if (saveImage)
            {
                // save the signature image (encoded as .png)
                pd.SignatureImage = await signaturePad.GetImageStreamAsync(SignatureImageFormat.Png, new ImageConstructionSettings
                {
                    BackgroundColor = Color.Transparent,
                    ShouldCrop = true,
                    StrokeColor = Color.Black,
                    StrokeWidth = 2,
                });

            }

            IsBusy = false;
        }

        private void StreamToBase64()
        {

            var pd = App.Current.TermoDeRecusa;

            Stream InputStream = pd.SignatureImage;           
            byte[] result;

            using (var streamReader = new MemoryStream())
            {

                InputStream.CopyTo(streamReader);
                result = streamReader.ToArray();

            }

            string base64 = Convert.ToBase64String(result);

            pd.SignatureStream = base64;

        }

        public string NomeRG => $"{TermoDeRecusa.NomeCompletoCidadao}, portador(a) do RG nº {TermoDeRecusa.RGCidadao}".Trim();

        private void OnRestartClicked(object sender, EventArgs e)
        {
            App.Current.RestartWizard();
        }
    }
}