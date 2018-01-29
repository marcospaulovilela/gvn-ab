using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gvn_ab_mobile.ViewModels;
using gvn_ab_mobile.Helpers;
using System.Windows.Input;
using System;
using System.Linq;

namespace gvn_ab_mobile.Views.FichaVisitaDomiciliarPage {

    public class ListFichaVisitaDomiciliarPageViewModel : BaseViewModel {
        private ListFichaVisitaDomiciliarPage Page { get; set; }
        private ObservableRangeCollection<object> fichas = new ObservableRangeCollection<object>();
        public ObservableRangeCollection<object> Fichas {
            get { return this.fichas; }
            set { SetProperty(ref this.fichas, value); }
        }

        public ICommand Add { get; }
        public ICommand Edit { get; }
        public ICommand Delete { get; }

        public ListFichaVisitaDomiciliarPageViewModel(ListFichaVisitaDomiciliarPage page) {
            this.Page = page;

            this.Add = new Command(async () => await this.AddExecuteAsync());
            this.Delete = new Command(async (item) => {
                var answer = await this.Page.DisplayAlert("Exclusão", "Deseja realmente excluir essa ficha?", "Sim", "Não");
                if (answer) {
                    this.DeleteExecute(item);
                };
            });
            this.Edit = new Command((item) => this.EditExecute(item));
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

        public async Task AddExecuteAsync() {
            await this.Page.Navigation.PushAsync(new FichaVisitaDomiciliarPage.FichaVisitaDomiciliarPage1(new ViewModels.FichaVisitaDomiciliarViewModel(this.Page)));
        }

        private void EditExecute(object item) {
            Task.Run(() => {
                try {
                    var objFicha = (Models.FichaVisitaDomiciliarTerritorial)item;
                    var vm = new ViewModels.FichaVisitaDomiciliarViewModel(this.Page, objFicha);
                    
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => await this.Page.Navigation.PushAsync(new FichaVisitaDomiciliarPage.FichaVisitaDomiciliarPage1(vm)));

                } catch (Exception e) {

                };
            });
        }

        public void Load() {
            using (DAO.DAOFichaVisitaDomiciliar DAO = new DAO.DAOFichaVisitaDomiciliar()) {
                this.Fichas = new ObservableRangeCollection<object>(DAO.Select().Where(o => o.Header.CnsProfissional == this.Page.MenuPage.ViewModel.Profissional.CnsProfissional));
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
    }
}