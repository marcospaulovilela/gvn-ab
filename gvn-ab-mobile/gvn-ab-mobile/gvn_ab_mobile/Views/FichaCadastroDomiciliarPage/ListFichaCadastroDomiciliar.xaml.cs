using gvn_ab_mobile.Helpers;
using gvn_ab_mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views.FichaCadastroDomiciliarPage {
    public class ListFichaCadastroDomiciliarPageViewModel : BaseViewModel {
        private ListFichaCadastroDomiciliar Page { get; set; }
        private ObservableRangeCollection<object> fichas = new ObservableRangeCollection<object>();
        public ObservableRangeCollection<object> Fichas {
            get { return this.fichas; }
            set { SetProperty(ref this.fichas, value); }
        }

        public ICommand Add { get; }
        public ICommand Edit { get; }
        public ICommand Delete { get; }

        public ListFichaCadastroDomiciliarPageViewModel(ListFichaCadastroDomiciliar page) {
            this.Page = page;

            this.Add = new Command(async () => await this.AddExecuteAsync());
            this.Delete = new Command((item) => this.DeleteExecute(item));
            this.Edit = new Command((item) => this.EditExecute(item));
        }

        private void DeleteExecute(object item) {
            Task.Run(() => {
                try {
                    var objFicha = (Models.FichaCadastroDomiciliarTerritorial)item;
                    using (DAO.DAOFichaCadastroDomiciliarTerritorial DAO = new DAO.DAOFichaCadastroDomiciliarTerritorial()) {
                        DAO.Delete(objFicha);
                        this.Fichas = new ObservableRangeCollection<object>(DAO.Select());
                    };
                } catch (Exception e) {

                };
            });
        }

        public async Task AddExecuteAsync() {
            await this.Page.Navigation.PushAsync(new FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage1(new ViewModels.FichaCadastroDomiciliarViewModel(this.Page)));
        }

        private void EditExecute(object item) {
            Task.Run(() => {
                try {
                    var objFicha = (Models.FichaCadastroDomiciliarTerritorial)item;
                    var vm = new ViewModels.FichaCadastroDomiciliarViewModel(this.Page, objFicha);

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => 
                        await this.Page.Navigation.PushAsync(new FichaCadastroDomiciliarPage.FichaCadastroDomiciliarPage1(vm)));

                } catch (Exception e) {

                };
            });
        }

        public void Load() {
            using (DAO.DAOFichaCadastroDomiciliarTerritorial DAO = new DAO.DAOFichaCadastroDomiciliarTerritorial()) {
                this.Fichas = new ObservableRangeCollection<object>(DAO.Select());
            };
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFichaCadastroDomiciliar : ContentPage {
        public MenuPage MenuPage { get; }
        private ListFichaCadastroDomiciliarPageViewModel viewModel { get; }

        public ListFichaCadastroDomiciliar(MenuPage menuPage) {
            InitializeComponent();
            this.MenuPage = menuPage;
            this.BindingContext = this.viewModel = new ListFichaCadastroDomiciliarPageViewModel(this);
        }

        protected override void OnAppearing() {
            Task.Run(() => this.viewModel?.Load());
        }
    }
}