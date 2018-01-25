using System;
using System.IO;
using SignaturePad.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views.FichaCadastroDomiciliarPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FichaCadastroDomiciliarRecusaPage4 : ContentPage
    {
        ViewModels.FichaCadastroDomiciliarViewModel viewModel;

        public FichaCadastroDomiciliarRecusaPage4(ViewModels.FichaCadastroDomiciliarViewModel viewModel)
        {
            InitializeComponent();
            
            this.BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            RestoreSignature();
        }

        private void RestoreSignature()
        {
            // just to make sure
            signaturePad1.Clear();

            // load the saved signature
            if (this.viewModel.SignaturePoints1 != null)
            {
                signaturePad1.Points = this.viewModel.SignaturePoints1;
            }
        }


        private async void OnContinuarClicked()
        {

            if (signaturePad1.IsBlank)
            {
                await DisplayAlert("Sem Assinatura", "Nenhuma assinatura detectada. Por favor, tenha certeza de que assinou acima da linha.", "OK");
                return;
            }

            // save all on next
            await SaveSignatureAsync(true);

            await StreamToBase64Async();

            await this.viewModel.SalvarExecuteAsync();
        }

        private async Task SaveSignatureAsync(bool saveImage)
        {
            IsBusy = true;

            // save the signature points
            this.viewModel.SignaturePoints1 = signaturePad1.Points.ToList();

            if (saveImage)
            {
                // save the signature image (encoded as .png)
                this.viewModel.SignatureImage1 = await signaturePad1.GetImageStreamAsync(SignatureImageFormat.Png, new ImageConstructionSettings
                {
                    BackgroundColor = Color.Transparent,
                    ShouldCrop = true,
                    StrokeColor = Color.Black,
                    StrokeWidth = 2,
                });

            }

            IsBusy = false;
        }

        private async Task StreamToBase64Async()
        {

            Stream InputStream = this.viewModel.SignatureImage1;
            byte[] result;

            using (var streamReader = new MemoryStream())
            {

                InputStream.CopyTo(streamReader);
                result = streamReader.ToArray();

            }

            string base64 = Convert.ToBase64String(result);

            this.viewModel.Ficha.AssinaturaRecusaInstituicaoPermanenciaCadastroBase64 = base64;

        }

    }
}