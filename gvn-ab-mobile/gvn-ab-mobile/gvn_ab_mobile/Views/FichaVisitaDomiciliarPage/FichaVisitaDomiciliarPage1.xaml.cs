using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gvn_ab_mobile.Views.FichaVisitaDomiciliarPage;

namespace gvn_ab_mobile.Views.FichaVisitaDomiciliarPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FichaVisitaDomiciliarPage1 : ContentPage
    {
        ViewModels.FichaVisitaDomiciliarViewModel viewModel;

        public FichaVisitaDomiciliarPage1()
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = new ViewModels.FichaVisitaDomiciliarViewModel(this);
        }
    }
}