using gvn_ab_mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels
{
    public class FichaCadastroIndividualViewModel : BaseViewModel { 
        private Page Page { get; set; }

        public ICommand Concordar { get; }
        public ICommand NaoConcordar { get; }

        public Models.FichaCadastroIndividual Ficha { get; set; }

        public ObservableRangeCollection<Models.Sexo> Sexos { get; set; }
        public ObservableRangeCollection<Models.Pais> Paises { get; set; }
        public ObservableRangeCollection<Models.Etinia> Etinias { get; set; }
        public ObservableRangeCollection<Models.RacaCor> RacasCores { get; set; }
        public ObservableRangeCollection<Models.Nacionalidade> Nacionalidades { get; set; }

        public FichaCadastroIndividualViewModel(Page page)
        {
            this.Ficha = new Models.FichaCadastroIndividual();
            this.Page = page;

            this.Concordar = new Command(async () => await ConcordarExecuteAsync());
            this.NaoConcordar = new Command(async () => await NaoConcordarExecuteAsync());

        }

        private async System.Threading.Tasks.Task ConcordarExecuteAsync() {
            this.Sexos = new ObservableRangeCollection<Models.Sexo>();
            this.Paises = new ObservableRangeCollection<Models.Pais>();
            this.Etinias = new ObservableRangeCollection<Models.Etinia>();
            this.RacasCores = new ObservableRangeCollection<Models.RacaCor>();
            this.Nacionalidades = new ObservableRangeCollection<Models.Nacionalidade>();
            
            this.Sexos.Add(new Models.Sexo() { CodSexo = 0, DesSexo = "LEMBRAR DE TRAZER ISSO NA SINCRONIZAÇÃO." });
            this.Sexos.Add(new Models.Sexo() { CodSexo = 0, DesSexo = "Masculino" });
            this.Sexos.Add(new Models.Sexo() { CodSexo = 1, DesSexo = "Feminino" });
            this.Sexos.Add(new Models.Sexo() { CodSexo = 4, DesSexo = "Ignorado" });

            this.RacasCores.Add(new Models.RacaCor() { CodRacaCor = 0, DesRacaCor= "LEMBRAR DE TRAZER ISSO NA SINCRONIZAÇÃO." });

            this.Etinias.Add(new Models.Etinia() { CodEtinia = 0, DesEtinia = "LEMBRAR DE TRAZER ISSO NA SINCRONIZAÇÃO." });

            this.Nacionalidades.Add(new Models.Nacionalidade() { CodNacionalidade = 0, DesNacionalidade = "LEMBRAR DE TRAZER ISSO NA SINCRONIZAÇÃO." });

            this.Paises.Add(new Models.Pais() { CodPais = 0, DesPais = "LEMBRAR DE TRAZER ISSO NA SINCRONIZAÇÃO." });


            await this.Page.Navigation.PushAsync(new Views.FichaCadastroIndividualPage.FichaCadastroIndividualPage2(this));
        }

        private async System.Threading.Tasks.Task NaoConcordarExecuteAsync() {
            await this.Page.DisplayAlert("Salvar no banco", "voltar para o menu", "fazer isso depois.");
        }
    }
}