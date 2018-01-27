using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gvn_ab_mobile.ViewModels;
using gvn_ab_mobile.Helpers;

namespace gvn_ab_mobile.Views.FichaVisitaDomiciliarPage {

    public class ListFichaVisitaDomiciliarPageViewModel : BaseViewModel {
        public ObservableRangeCollection<object> Fichas { get; } = new ObservableRangeCollection<object>();

        public void Load() {
            using (DAO.DAOFichaVisitaDomiciliar DAO = new DAO.DAOFichaVisitaDomiciliar()) {
                this.Fichas.AddRange(DAO.Select());
            };
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFichaVisitaDomiciliarPage : ContentPage {
        private MenuPage MenuPage { get; }
        private ListFichaVisitaDomiciliarPageViewModel viewModel { get; }
        
        public ListFichaVisitaDomiciliarPage(MenuPage menu) {
            InitializeComponent();

            this.MenuPage = menu;
            this.BindingContext = this.viewModel = new ListFichaVisitaDomiciliarPageViewModel();
        }

        protected override void OnAppearing() {
            Task.Run(() => this.viewModel?.Load());
        }

    }
}