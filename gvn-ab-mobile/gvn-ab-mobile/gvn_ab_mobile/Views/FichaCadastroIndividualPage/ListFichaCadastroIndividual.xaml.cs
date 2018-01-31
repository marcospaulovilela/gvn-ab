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

namespace gvn_ab_mobile.Views.FichaCadastroIndividualPage {
    public class ListFichaCadastroIndividualViewModel: BaseViewModel {
        private ListFichaCadastroIndividual Page { get; set; }
        private ObservableRangeCollection<object> fichas = new ObservableRangeCollection<object>();
        public ObservableRangeCollection<object> Fichas {
            get { return this.fichas; }
            set { SetProperty(ref this.fichas, value); }
        }

        public ICommand Add { get; }
        public ICommand Edit { get; }
        public ICommand Delete { get; }

        public ListFichaCadastroIndividualViewModel(ListFichaCadastroIndividual page) {
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
                    var objFicha = (Models.FichaCadastroIndividual)item;
                    using (DAO.DAOFichaCadastroIndividual DAO = new DAO.DAOFichaCadastroIndividual()) {
                        DAO.Delete(objFicha);
                        this.Fichas = new ObservableRangeCollection<object>(DAO.Select());
                    };
                } catch (Exception e) {

                };
            });
        }

        public async Task AddExecuteAsync() {
            await this.Page.Navigation.PushAsync(new FichaCadastroIndividualPage.FichaCadastroIndividualPage1(new ViewModels.FichaCadastroIndividualViewModel(this.Page)));
        }

        private void EditExecute(object item) {
            Task.Run(() => {
                try {
                    var objFicha = (Models.FichaCadastroIndividual)item;
                    var vm = new ViewModels.FichaCadastroIndividualViewModel(this.Page, objFicha);

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => await this.Page.Navigation.PushAsync(new FichaCadastroIndividualPage.FichaCadastroIndividualPage1(vm)));

                } catch (Exception e) {

                };
            });
        }

        public void Load() {
            using (DAO.DAOFichaCadastroIndividual DAO = new DAO.DAOFichaCadastroIndividual()) {
                this.Fichas = new ObservableRangeCollection<object>(DAO.Select().Where(o => o.Header.CnsProfissional == this.Page.MenuPage.ViewModel.Profissional.CnsProfissional));
            };
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFichaCadastroIndividual : ContentPage {
        public MenuPage MenuPage { get; }
        private ListFichaCadastroIndividualViewModel viewModel { get; }

        public ListFichaCadastroIndividual(MenuPage menu) {
            InitializeComponent();

            this.MenuPage = menu;
            this.BindingContext = this.viewModel = new ListFichaCadastroIndividualViewModel(this);
        }

        protected override void OnAppearing() {
            Task.Run(() => this.viewModel?.Load());
        }
    }
}