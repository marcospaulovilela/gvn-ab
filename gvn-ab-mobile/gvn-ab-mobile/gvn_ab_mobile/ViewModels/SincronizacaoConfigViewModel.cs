using gvn_ab_mobile.Helpers;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class SincronizacaoConfigViewModel : BaseViewModel {
        private Page Page { get; set; }

        public ICommand Connectar { get; }
        public ICommand Sync { get; }

        public Models.SincronizacaoConfig SincronizacaoConfig { get; set; }
        public ObservableRangeCollection<Models.Estabelecimento> Estabelecimentos { get; set; }

        public SincronizacaoConfigViewModel(Page page) {
            this.Page = page;
            this.SincronizacaoConfig = new Models.SincronizacaoConfig();

            this.Sync = new Command(async () => await this.SyncExecuteAsync());
            this.Connectar = new Command(async () => await this.ConnectarExecuteAsync());
            this.Estabelecimentos = new ObservableRangeCollection<Models.Estabelecimento>();
        }

        private async System.Threading.Tasks.Task ConnectarExecuteAsync() {
            this.IsBusy = true;

            try {
                this.Estabelecimentos.Clear();
                this.Estabelecimentos.Add(new Models.Estabelecimento() { CodEstabelecimento = 10, NomEstabelecimento = "E.S.F. São Pedro" });
                this.Estabelecimentos.Add(new Models.Estabelecimento() { CodEstabelecimento = 12, NomEstabelecimento = "U.P.A. Teste 2" });

                await this.Page.Navigation.PushAsync(new Views.SincronizacaoConfigPage2(this));

            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            } finally {
                IsBusy = false;
            };   
        }

        private async System.Threading.Tasks.Task SyncExecuteAsync() {
            this.IsBusy = true;

            try {
                this.Page.DisplayAlert("A", "B", "C");

            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            } finally {
                IsBusy = false;
            };
        }
    }
}
