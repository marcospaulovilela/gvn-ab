using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views.AssinaturaTermoRecusa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmacaoPage : ContentPage
    {
        public ConfirmacaoPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public Models.AssinaturaTermoRecusa.TermoDeRecusaModel TermoDeRecusa => App.Current.TermoDeRecusa;

        public ImageSource SignatureImage => ImageSource.FromStream(() => TermoDeRecusa.SignatureImage);

        public string SignatureSize
        {
            get
            {
                var size = TermoDeRecusa.SignatureImage.Length / 1024f;
                var points = TermoDeRecusa.SignaturePoints.Count;
                return $"{size:0.00} KB with {points} points.";
            }
        }

        private void OnBackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            App.Current.CompleteWizard();
        }
    }
}