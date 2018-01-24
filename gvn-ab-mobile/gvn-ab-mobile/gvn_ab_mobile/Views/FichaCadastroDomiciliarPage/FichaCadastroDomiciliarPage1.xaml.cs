using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gvn_ab_mobile.Views.FichaCadastroDomiciliarPage;

namespace gvn_ab_mobile.Views.FichaCadastroDomiciliarPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FichaCadastroDomiciliarPage1 : ContentPage
    {
        ViewModels.FichaCadastroDomiciliarViewModel ViewModel { get; set; }

        public FichaCadastroDomiciliarPage1(ViewModels.FichaCadastroDomiciliarViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = this.ViewModel = viewModel;
        }
    }
}