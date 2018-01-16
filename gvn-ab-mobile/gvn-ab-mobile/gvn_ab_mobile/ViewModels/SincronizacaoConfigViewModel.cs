using gvn_ab_mobile.Helpers;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class SincronizacaoConfigViewModel : BaseViewModel {
        private Page Page { get; set; }

        public ICommand Connectar { get; }
        public ICommand Sync { get; }
        public ICommand SyncOffline { get; }


        public Models.Estabelecimento Estabelecimento { get; set; }
        public Models.SincronizacaoConfig SincronizacaoConfig { get; set; }
        public ObservableRangeCollection<Models.Estabelecimento> Estabelecimentos { get; set; }

        public SincronizacaoConfigViewModel(Page page) {
            this.Page = page;
            this.SincronizacaoConfig = new Models.SincronizacaoConfig() {
                DesEndereco = "192.168.0.170"
            };

            this.Sync = new Command(() => this.SyncExecute());
            this.Connectar = new Command(() => this.ConnectarExecuteAsync());
            this.Estabelecimentos = new ObservableRangeCollection<Models.Estabelecimento>();

            this.SyncOffline = new Command(() => this.SyncOfflineExecute());
        }

        /// <summary>
        /// TABELAS FIXAS.
        /// </summary>
        private void CargaDados() {
            //CRIA OS ENUMERADORES E SALVA OS VALORES PADROES DO ESUS
            using (DAO.DAOSexo DAOSexo = new DAO.DAOSexo()) { DAOSexo.CreateTable(); }
            using (DAO.DAOPais DAOPais = new DAO.DAOPais()) { DAOPais.CreateTable(); }
            using (DAO.DAORacaCor DAORacaCor = new DAO.DAORacaCor()) { DAORacaCor.CreateTable(); }
            using (DAO.DAOEtnia DAOEtnia = new DAO.DAOEtnia()) { DAOEtnia.CreateTable(); }
            using (DAO.DAOOrientacaoSexual DAOOrientacaoSexual = new DAO.DAOOrientacaoSexual()) { DAOOrientacaoSexual.CreateTable(); }
            using (DAO.DAOCursoMaisElevado DAOCursoMaisElevado = new DAO.DAOCursoMaisElevado()) { DAOCursoMaisElevado.CreateTable(); }
            using (DAO.DAORelacaoParentesco DAORelacaoParentesco = new DAO.DAORelacaoParentesco()) { DAORelacaoParentesco.CreateTable(); }
            using (DAO.DAOResponsavelCrianca DAOResponsavelCrianca = new DAO.DAOResponsavelCrianca()) { DAOResponsavelCrianca.CreateTable(); }
            using (DAO.DAOMotivoSaida DAOMotivoSaida = new DAO.DAOMotivoSaida()) { DAOMotivoSaida.CreateTable(); }
            using (DAO.DAONacionalidade DAONacionalidade = new DAO.DAONacionalidade()) { DAONacionalidade.CreateTable(); }
            using (DAO.DAOSituacaoMercadoTrabalho DAOSituacaoMercadoTrabalho = new DAO.DAOSituacaoMercadoTrabalho()) { DAOSituacaoMercadoTrabalho.CreateTable(); }
            using (DAO.DAOIdentidadeGeneroCidadao DAOIdentidadeGenero = new DAO.DAOIdentidadeGeneroCidadao()) { DAOIdentidadeGenero.CreateTable(); }
            using (DAO.DAOConsideracaoPeso DAOConsideracaoPeso = new DAO.DAOConsideracaoPeso()) { DAOConsideracaoPeso.CreateTable(); }
            using (DAO.DAODoencaCardiaca DAODoencaCardiaca = new DAO.DAODoencaCardiaca()) { DAODoencaCardiaca.CreateTable(); }
            using (DAO.DAOProblemaRins DAOProblemaRins = new DAO.DAOProblemaRins()) { DAOProblemaRins.CreateTable(); }
            using (DAO.DAODoencaRespiratoria DAODoencaRespiratoria = new DAO.DAODoencaRespiratoria()) { DAODoencaRespiratoria.CreateTable(); }
            using (DAO.DAODeficienciaCidadao DAODeficienciaCidadao = new DAO.DAODeficienciaCidadao()) { DAODeficienciaCidadao.CreateTable();  }
            using (DAO.DAOAcessoHigiene DAOAcessoHigiene = new DAO.DAOAcessoHigiene()) { DAOAcessoHigiene.CreateTable(); }
            using (DAO.DAOQuantasVezesAlimentacao DAOQuantasVezesAlimentacao = new DAO.DAOQuantasVezesAlimentacao()) { DAOQuantasVezesAlimentacao.CreateTable();  }

            using (DAO.DAOTurno DAOTurno = new DAO.DAOTurno()) { DAOTurno.CreateTable(); }
            using (DAO.DAOLocalDeAtendimento DAOLocalAtendimento = new DAO.DAOLocalDeAtendimento()) { DAOLocalAtendimento.CreateTable(); }
            using (DAO.DAOTipoDeAtendimento DAOTipoAtendimento = new DAO.DAOTipoDeAtendimento()) { DAOTipoAtendimento.CreateTable(); }
            using (DAO.DAOModalidadeAD DAOModalidadeAD = new DAO.DAOModalidadeAD()) { DAOModalidadeAD.CreateTable(); }
            using (DAO.DAORacionalidadeSaude DAORacionalidadeSaude = new DAO.DAORacionalidadeSaude()) { DAORacionalidadeSaude.CreateTable(); }
            using (DAO.DAOAleitamentoMaterno DAOAleitamentoMaterno = new DAO.DAOAleitamentoMaterno()) { DAOAleitamentoMaterno.CreateTable(); }

            using (DAO.DAOTipoDeImovel DAOTipoDeImovel = new DAO.DAOTipoDeImovel()) { DAOTipoDeImovel.CreateTable(); }
            using (DAO.DAOTipoDeLogradouro DAOTipoDeLogradouro = new DAO.DAOTipoDeLogradouro()) { DAOTipoDeLogradouro.CreateTable(); }
            using (DAO.DAOSituacaoDeMoradia DAOSituacaoDeMoradia = new DAO.DAOSituacaoDeMoradia()) { DAOSituacaoDeMoradia.CreateTable(); }
            using (DAO.DAOTipoDeDomicilio DAOTipoDeDomicilio = new DAO.DAOTipoDeDomicilio()) { DAOTipoDeDomicilio.CreateTable(); }
            using (DAO.DAOTipoDeAcessoAoDomicilio DAOTipoDeAcessoAoDomicilio = new DAO.DAOTipoDeAcessoAoDomicilio()) { DAOTipoDeAcessoAoDomicilio.CreateTable(); }
            using (DAO.DAOCondicaoDePosseEUsoDaTerra DAOCondicaoDePosseEUsoDaTerra = new DAO.DAOCondicaoDePosseEUsoDaTerra()) { DAOCondicaoDePosseEUsoDaTerra.CreateTable(); }
            using (DAO.DAOMaterialPredominanteNaConstrucao DAOMaterialPredominanteNaConstrucao = new DAO.DAOMaterialPredominanteNaConstrucao()) { DAOMaterialPredominanteNaConstrucao.CreateTable(); }
            using (DAO.DAOLocalizacaoDaMoradia DAOLocalizacaoDaMoradia = new DAO.DAOLocalizacaoDaMoradia()) { DAOLocalizacaoDaMoradia.CreateTable(); }
            using (DAO.DAOAbastecimentoDeAgua DAOAbastecimentoDeAgua = new DAO.DAOAbastecimentoDeAgua()) { DAOAbastecimentoDeAgua.CreateTable(); }
            using (DAO.DAOAguaConsumoDomicilio DAOAguaConsumoDomicilio = new DAO.DAOAguaConsumoDomicilio()) { DAOAguaConsumoDomicilio.CreateTable(); }
            using (DAO.DAOFormaDeEscoamentoDoBanheiroOuSanitario DAOFormaDeEscoamentoDoBanheiroOuSanitario = new DAO.DAOFormaDeEscoamentoDoBanheiroOuSanitario()) { DAOFormaDeEscoamentoDoBanheiroOuSanitario.CreateTable(); }
            using (DAO.DAODestinoDoLixo DAODestinoDoLixo = new DAO.DAODestinoDoLixo()) { DAODestinoDoLixo.CreateTable(); }

            using (DAO.DAOAnimalNoDomicilio DAOAnimalNoDomicilio = new DAO.DAOAnimalNoDomicilio()) { DAOAnimalNoDomicilio.CreateTable(); }
            using (DAO.DAORendaFamiliar DAORendaFamiliar = new DAO.DAORendaFamiliar()) { DAORendaFamiliar.CreateTable(); }
        }

        private void SyncOfflineExecute() {
            this.IsBusy = true;
            Task.Run( () => {
                try {
                    this.CargaDados();

                    using (DAO.DAOEstabelecimento DAOEstabelecimento = new DAO.DAOEstabelecimento()) {
                        DAOEstabelecimento.DropTable();
                        DAOEstabelecimento.CreateTable();
                        DAOEstabelecimento.Insert(new Models.Estabelecimento() { CodUnidade = 1, DesNomFantasia = "Unidade fixa" });
                    };

                    #region Profissionais
                    using (DAO.DAOProfissional DAOProfissional = new DAO.DAOProfissional()) {
                        using (DAO.DAOCbo DAOCbo = new DAO.DAOCbo()) {
                            DAOCbo.CreateTable();
                        }

                        DAOProfissional.CreateTable();
                        DAOProfissional.Insert(new Models.Profissional() {
                            CodProfissional = "123456",
                            DesLogin = "admsaude",
                            DesSenha = "123456",
                            NomProfissional = "ADM Saude",
                            Cbos = new List<Models.Cbo>() {
                                new Models.Cbo() { CodCbo = "225125", NomCbo="Médico clínico" },
                                new Models.Cbo() { CodCbo = "223505", NomCbo = "Enfermeiro" }
                            }
                        });
                    };
                    #endregion

                    using (DAO.DAOSincronizacaoConfig DAOSync = new DAO.DAOSincronizacaoConfig()) {
                        //DAOSync.CreateTable();
                        //DAOSync.Insert(this.SincronizacaoConfig);
                    };

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new Views.Login.LoginPage()) { BarBackgroundColor = Color.FromHex("#003264") });

                } catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine(ex);
                } finally {
                    IsBusy = false;
                };
            });
        }

        private void ConnectarExecuteAsync() {
            this.IsBusy = true;
            Task.Run(async () => {
                try {
                    //this.Estabelecimentos.Clear();
                    //this.Estabelecimentos.AddRange(await new RestAPI($"http://{this.SincronizacaoConfig.DesEndereco}/Governa.Saude.AtencaoBasica.Ministerio/Handlers/Mobile/Estabelecimento.ashx").GetAsync<Models.Estabelecimento>());

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new Views.SincronizacaoConfigPage2(this)) { BarBackgroundColor = Color.FromHex("#003264") });

                } catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine(ex);
                    MessagingCenter.Send(new MessagingCenterAlert {
                        Title = "Error",
                        Message = "Não foi possivel carregar os items do serviço.",
                        Cancel = "OK"
                    }, "message");
                } finally {
                    IsBusy = false;
                };
            });
        }

        private void SyncExecute() {
            this.IsBusy = true;
            Task.Run(async () => {
                try {
                    //APAGA TODO O BANCO DE DADOS E O RECONSTROI
                    //DAO.DAO<object>.DropDatabase();

                    //INICIA A BUSCA POR PROFISSIONAIS
                    //this.SincronizacaoConfig.CodEstabelecimento = this.Estabelecimento.CodUnidade;
                    //var TaskGetProfissionais = new RestAPI($"http://{this.SincronizacaoConfig.DesEndereco}/Governa.Saude.AtencaoBasica.Ministerio/Handlers/Mobile/Profissional.ashx?codUnidade={this.Estabelecimento.CodUnidade}").GetAsync<Models.Profissional>();

                    this.CargaDados();

                    using (DAO.DAOEstabelecimento DAOEstabelecimento = new DAO.DAOEstabelecimento()) {
                        /*DAOEstabelecimento.DropTable();
                        DAOEstabelecimento.CreateTable();
                        DAOEstabelecimento.Insert(this.Estabelecimento);*/
                    }

                    #region Profissionais
                    using (DAO.DAOProfissional DAOProfissional = new DAO.DAOProfissional()) {
                        /*var Profissionais = await TaskGetProfissionais;
                        Profissionais.ForEach(o => o.DesSenha = "123456");

                        using (DAO.DAOCbo DAOCbo = new DAO.DAOCbo()) {
                            DAOCbo.CreateTable();
                        }

                        DAOProfissional.CreateTable();
                        DAOProfissional.Insert(Profissionais);*/
                    };
                    #endregion

                    using (DAO.DAOSincronizacaoConfig DAOSync = new DAO.DAOSincronizacaoConfig()) {
                        //DAOSync.CreateTable();
                        //DAOSync.Insert(this.SincronizacaoConfig);
                    };

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new Views.Login.LoginPage()) { BarBackgroundColor = Color.FromHex("#003264") });

                } catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine(ex);
                } finally {
                    IsBusy = false;
                };
            });
        }
    }
}
