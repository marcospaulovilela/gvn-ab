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
    public partial class FichaCadastroDomiciliarPage3 : ContentPage
    {
        ViewModels.FichaCadastroDomiciliarViewModel viewModel;

        public FichaCadastroDomiciliarPage3(ViewModels.FichaCadastroDomiciliarViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = viewModel;
        }
    }
}