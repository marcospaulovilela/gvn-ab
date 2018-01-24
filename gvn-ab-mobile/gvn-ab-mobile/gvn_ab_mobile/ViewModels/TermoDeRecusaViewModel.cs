using gvn_ab_mobile.Helpers;
using SignaturePad.Forms;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace gvn_ab_mobile.ViewModels
{
    public class TermoDeRecusaViewModel : BaseViewModel
    {

        private Views.MenuPage MenuPage { get; set; }

        public ICommand Continuar { get; }

        public Models.AssinaturaTermoRecusa.TermoDeRecusaModel Termo { get; set; }

        public List<Point> SignaturePoints;
        public Stream SignatureImage;

        public string NomeRG => $"{this.Termo.NomeCompletoCidadao}, portador(a) do RG nº {this.Termo.RGCidadao}".Trim();

        public TermoDeRecusaViewModel(Views.MenuPage menuPage)
        {
            this.Termo = App.Current.TermoDeRecusa;
            this.MenuPage = menuPage;

            this.Continuar = new Command(async () => ContinuarExecuteAsync());

        }

        private async System.Threading.Tasks.Task ContinuarExecuteAsync()
        {
            var CurrentPage = this.MenuPage.Navigation.NavigationStack.Last(); //PEGA A ULTIMA PAGINA NA PILHA DE NAVEGAÇÃO, OU SEJA A ATUAL.
            if (CurrentPage is Views.AssinaturaTermoRecusa.TermoDeRecusaPage)
            {
                await this.MenuPage.Navigation.PushAsync(new Views.AssinaturaTermoRecusa.AssinaturaPage(this));
            }
        }

        private void OnRestartClicked(object sender, EventArgs e)
        {
            App.Current.RestartWizard();
        }

        public async System.Threading.Tasks.Task SalvarTermoAsync()
        {
            //App.Current.CompleteWizard();

            this.IsBusy = true;
            #pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
            Task.Run(async () =>
            {

                using (DAO.DAOFichaUnicaLotacaoHeader DAOFichaUnicaLotacaoHeader = new DAO.DAOFichaUnicaLotacaoHeader())
                using (DAO.DAOTermoDeRecusa DAOTermoDeRecusa = new DAO.DAOTermoDeRecusa())
                {
                    try
                    {
                        this.Termo.Header = new Models.FichaUnicaLotacaoHeader()
                        {
                            Cbo = this.MenuPage.ViewModel.Cbo.CodCbo,
                            CnsProfissional = this.MenuPage.ViewModel.Profissional.CnsProfissional,
                            Cnes = this.MenuPage.ViewModel.Estabelecimento.ImpCnes,
                            Ine = this.MenuPage.ViewModel.Equipe.CodEquipe,
                            DataAtendimento = DateTime.Now
                        };

                        DAOFichaUnicaLotacaoHeader.Insert(this.Termo.Header);
                        DAOTermoDeRecusa.Insert(this.Termo);
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => await this.MenuPage.Navigation.PopToRootAsync());
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e);
                    }
                    finally
                    {
                        this.IsBusy = false;
                    };
                };
            });
            #pragma warning restore CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
        }

    }
}
