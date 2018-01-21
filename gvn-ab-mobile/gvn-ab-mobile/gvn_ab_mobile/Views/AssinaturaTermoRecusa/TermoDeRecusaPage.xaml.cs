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
    public partial class TermoDeRecusaPage : ContentPage
    {
        public TermoDeRecusaPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public Models.AssinaturaTermoRecusa.TermoDeRecusaModel Termo => App.Current.TermoDeRecusa;

        private void OnBackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AssinaturaPage());
        }
    }
}