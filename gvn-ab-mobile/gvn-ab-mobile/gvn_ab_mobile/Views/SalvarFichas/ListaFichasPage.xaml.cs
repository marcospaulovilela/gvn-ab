using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gvn_ab_mobile.Views;

namespace gvn_ab_mobile.Views.SalvarFichas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaFichasPage : ContentPage
    {
        ViewModels.FichasPageViewModel viewModel;

        public ListaFichasPage()
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = new ViewModels.FichasPageViewModel(this);
        }
    }
}