using gvn_ab_mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels
{
    public class FichaAtendimentoIndividualViewModel : BaseViewModel
    {

        private Page Page { get; set; }

        public ICommand Continuar { get; }

        public Models.FichaAtendimentoIndividual Ficha { get; set; }

        // USADO PAGE 1
        public ObservableRangeCollection<Models.Turno> Turnos { get; set; }
        public ObservableRangeCollection<Models.Sexo> Sexos { get; set; }

        // USADO PAGE 2
        public ObservableRangeCollection<Models.LocalDeAtendimento> LocaisAtendimentos { get; set; }
        public ObservableRangeCollection<Models.TipoDeAtendimento> TiposAtendimentos { get; set; }
        public ObservableRangeCollection<Models.AtencaoDomiciliar> AtencaoDomiciliar { get; set; }
        public ObservableRangeCollection<Models.RacionalidadeSaude> RacionalidadeSaude { get; set; }
        public ObservableRangeCollection<Models.AleitamentoMaterno> AleitamentoMaterno { get; set; }

        public FichaAtendimentoIndividualViewModel(Page page)
        {
            this.Ficha = new Models.FichaAtendimentoIndividual();
            this.Page = page;

            this.Continuar = new Command(async () => await ContinuarExecuteAsync());

            this.Turnos = new ObservableRangeCollection<Models.Turno>(new DAO.DAOTurno().Select());
            this.Sexos = new ObservableRangeCollection<Models.Sexo>(new DAO.DAOSexo().Select()); //traz todos os sexos na base.

            this.LocaisAtendimentos = new ObservableRangeCollection<Models.LocalDeAtendimento>(new DAO.DAOLocalAtendimento().Select());
            this.TiposAtendimentos = new ObservableRangeCollection<Models.TipoDeAtendimento>(new DAO.DAOTipoAtendimento().Select());
            this.AtencaoDomiciliar = new ObservableRangeCollection<Models.AtencaoDomiciliar>(new DAO.DAOAtencaoDomiciliar().Select());
            this.RacionalidadeSaude = new ObservableRangeCollection<Models.RacionalidadeSaude>(new DAO.DAORacionalidadeSaude().Select());
            this.AleitamentoMaterno = new ObservableRangeCollection<Models.AleitamentoMaterno>(new DAO.DAOAleitamentoMaterno().Select());
        }

        private async System.Threading.Tasks.Task ContinuarExecuteAsync()
        {
            var CurrentPage = this.Page.Navigation.NavigationStack.Last(); //PEGA A ULTIMA PAGINA NA PILHA DE NAVEGAÇÃO, OU SEJA A ATUAL.
            if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage1)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage2(this));
            }
            else if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage2)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage3(this));
            }
            else if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage3)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage4(this));
            }
            else if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage4)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage5(this));
            }
            else if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage5)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage6(this));
            }
            else if (CurrentPage is Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage6)
            {
                await this.Page.Navigation.PushAsync(new Views.FichaAtendimentoIndividualPage.FichaAtendimentoIndividualPage7(this));
            };
        }

    }

}
