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
        ViewModels.TermoDeRecusaViewModel ViewModel { get; set; }

        public TermoDeRecusaPage(ViewModels.TermoDeRecusaViewModel viewModel)
        {
            InitializeComponent();

            this.BindingContext = this.ViewModel = viewModel;
        }

    }
}