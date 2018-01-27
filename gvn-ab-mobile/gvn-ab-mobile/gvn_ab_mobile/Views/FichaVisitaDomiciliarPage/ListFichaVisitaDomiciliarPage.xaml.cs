using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gvn_ab_mobile.ViewModels;
using gvn_ab_mobile.Helpers;
using System.Windows.Input;
using System;

namespace gvn_ab_mobile.Views.FichaVisitaDomiciliarPage {

    public class ListFichaVisitaDomiciliarPageViewModel : BaseViewModel {
        private ListFichaVisitaDomiciliarPage Page { get; set; }
        private ObservableRangeCollection<object> fichas = new ObservableRangeCollection<object>();
        public ObservableRangeCollection<object> Fichas {
            get { return this.fichas; }
            set { SetProperty(ref this.fichas, value); }
        }

        public ICommand Add { get; }
        public ICommand Delete { get; }

        public ListFichaVisitaDomiciliarPageViewModel(ListFichaVisitaDomiciliarPage page) {
            this.Page = page;

            this.Add = new Command(() => this.Page.AddAsync());
            this.Delete = new Command((item) => this.DeleteExecute(item));
        }

        private void DeleteExecute(object item) {
            Task.Run(() => {
                try {
                    var objFicha = (Models.FichaVisitaDomiciliarTerritorial)item;
                    using (DAO.DAOFichaVisitaDomiciliar DAO = new DAO.DAOFichaVisitaDomiciliar()) {
                        DAO.Delete(objFicha);
                        this.Fichas = new ObservableRangeCollection<object>(DAO.Select());
                    };
                } catch(Exception e) {

                };
            });
        }

        public void Load() {
            using (DAO.DAOFichaVisitaDomiciliar DAO = new DAO.DAOFichaVisitaDomiciliar()) {
                this.Fichas = new ObservableRangeCollection<object>(DAO.Select());
            };
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFichaVisitaDomiciliarPage : ContentPage {
        public MenuPage MenuPage { get; }
        private ListFichaVisitaDomiciliarPageViewModel viewModel { get; }
        
        public ListFichaVisitaDomiciliarPage(MenuPage menu) {
            InitializeComponent();

            this.MenuPage = menu;
            this.BindingContext = this.viewModel = new ListFichaVisitaDomiciliarPageViewModel(this);
        }

        protected override void OnAppearing() {
            Task.Run(() => this.viewModel?.Load());
        }

        public async Task AddAsync() {
            await Navigation.PushAsync(new FichaVisitaDomiciliarPage.FichaVisitaDomiciliarPage1(new ViewModels.FichaVisitaDomiciliarViewModel(this)));
        }
    }
}