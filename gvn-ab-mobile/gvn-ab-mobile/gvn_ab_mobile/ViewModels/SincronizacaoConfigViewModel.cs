using gvn_ab_mobile.Helpers;
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
        }

        private void ConnectarExecuteAsync() {
            this.IsBusy = true;
            Task.Run(async () => {
                try {
                    this.Estabelecimentos.Clear();
                    this.Estabelecimentos.AddRange(await new RestAPI($"http://{this.SincronizacaoConfig.DesEndereco}/Governa.Saude.AtencaoBasica.Ministerio/Handlers/Mobile/Estabelecimento.ashx").GetAsync<Models.Estabelecimento>());

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new Views.SincronizacaoConfigPage2(this)) { BarBackgroundColor = Color.SteelBlue });

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
                    this.SincronizacaoConfig.CodEstabelecimento = this.Estabelecimento.CodUnidade;
                    var TaskGetProfissionais = new RestAPI($"http://{this.SincronizacaoConfig.DesEndereco}/Governa.Saude.AtencaoBasica.Ministerio/Handlers/Mobile/Profissional.ashx?codUnidade={this.Estabelecimento.CodUnidade}").GetAsync<Models.Profissional>();

                    using (DAO.DAOEstabelecimento DAOEstabelecimento = new DAO.DAOEstabelecimento()) {
                        DAOEstabelecimento.DropTable();
                        DAOEstabelecimento.CreateTable();
                        DAOEstabelecimento.Insert(this.Estabelecimento);
                    }

                    //CRIA OS ENUMERADORES E SALVA OS VALORES PADROES DO ESUS
                    using (DAO.DAOSexo DAOSexo = new DAO.DAOSexo()) { DAOSexo.CreateTable(); }
                    using (DAO.DAOPais DAOPais = new DAO.DAOPais()) { DAOPais.CreateTable(); }
                    using (DAO.DAORacaCor DAORacaCor = new DAO.DAORacaCor()) { DAORacaCor.CreateTable(); }
                    using (DAO.DAOEtnia DAOEtnia = new DAO.DAOEtnia()) { DAOEtnia.CreateTable(); }
                    using (DAO.DAOOrientacaoSexual DAOOrientacaoSexual = new DAO.DAOOrientacaoSexual()) { DAOOrientacaoSexual.CreateTable(); }
                    using (DAO.DAOCurso DAOCurso = new DAO.DAOCurso()) { DAOCurso.CreateTable(); }
                    using (DAO.DAORelacaoParentesco DAORelacaoParentesco = new DAO.DAORelacaoParentesco()) { DAORelacaoParentesco.CreateTable(); }
                    using (DAO.DAOResponsavel DAOResponsavel = new DAO.DAOResponsavel()) { DAOResponsavel.CreateTable(); }
                    using (DAO.DAOMotivoSaida DAOMotivoSaida = new DAO.DAOMotivoSaida()) { DAOMotivoSaida.CreateTable(); }
                    using (DAO.DAONacionalidade DAONacionalidade = new DAO.DAONacionalidade()) { DAONacionalidade.CreateTable(); }
                    using (DAO.DAOSituacaoMercado DAOSituacaoMercado = new DAO.DAOSituacaoMercado()) { DAOSituacaoMercado.CreateTable(); }
                    using (DAO.DAOIdentidadeGenero DAOIdentidadeGenero = new DAO.DAOIdentidadeGenero()) { DAOIdentidadeGenero.CreateTable(); }
                    using (DAO.DAOConsideracaoPeso DAOConsideracaoPeso = new DAO.DAOConsideracaoPeso()) { DAOConsideracaoPeso.CreateTable(); }
                    using (DAO.DAODoencaCardiaca DAODoencaCardiaca = new DAO.DAODoencaCardiaca()) { DAODoencaCardiaca.CreateTable(); }
                    using (DAO.DAOProblemaRins DAOProblemaRins = new DAO.DAOProblemaRins()) { DAOProblemaRins.CreateTable(); }
                    using (DAO.DAODoencaRespiratoria DAODoencaRespiratoria = new DAO.DAODoencaRespiratoria()) { DAODoencaRespiratoria.CreateTable(); }

                    using (DAO.DAOProfissional DAOProfissional = new DAO.DAOProfissional()) {
                        var _Profissionais = await TaskGetProfissionais;
                        var Profissionais = new List<Models.Profissional>();
                        foreach (var profissional in _Profissionais) {
                            if (!Profissionais.Any(o => o.CodProfissional == profissional.CodProfissional))
                                Profissionais.Add(profissional);
                        };


                        var Cbos = new List<Models.Cbo>();
                        foreach(var cbo in Profissionais.SelectMany(o => o.Cbos).Distinct().ToList()) {
                            if (!Cbos.Any(o => o.CodCbo == cbo.CodCbo))
                                Cbos.Add(cbo);
                        };
                       
                        using (DAO.DAOCbo DAOCbo = new DAO.DAOCbo()) {
                            DAOCbo.DropTable();
                            DAOCbo.CreateTable();
                            DAOCbo.Insert(Cbos);
                        };

                        DAOProfissional.DropTable();
                        DAOProfissional.CreateTable();
                        DAOProfissional.Insert(new Models.Profissional() {
                            CodProfissional = "11958730696",
                            DesSenha = "123456",
                            NomProfissional = "Marcos Paulo Vilela"
                        });

                        DAOProfissional.Insert(Profissionais);
                    };


                    using (DAO.DAOSincronizacaoConfig DAOSync = new DAO.DAOSincronizacaoConfig()) {
                        //DAOSync.CreateTable();
                        //DAOSync.Insert(this.SincronizacaoConfig);
                    };

                    new DAO.DAOTurno().CreateTable();
                    new DAO.DAOLocalAtendimento().CreateTable();
                    new DAO.DAOTipoAtendimento().CreateTable();
                    new DAO.DAOAtencaoDomiciliar().CreateTable();
                    new DAO.DAORacionalidadeSaude().CreateTable();
                    new DAO.DAOAleitamentoMaterno().CreateTable();

                    new DAO.DAOSituacaoMoradiaPosseTerra().CreateTable();
                    new DAO.DAOLocalizacao().CreateTable();
                    new DAO.DAOTipoDeDomicilio().CreateTable();
                    new DAO.DAOTipoDeAcessoAoDomicilio().CreateTable();
                    new DAO.DAOCondicaoDePosseEUsoDaTerra().CreateTable();
                    new DAO.DAOMaterialPredominanteNaConstrucao().CreateTable();
                    new DAO.DAOAbastecimentoDeAgua().CreateTable();
                    new DAO.DAOAguaConsumoDomicilio().CreateTable();
                    new DAO.DAOFormaDeEscoamentoDoBanheiroOuSanitario().CreateTable();
                    new DAO.DAODestinoDoLixo().CreateTable();

                    new DAO.DAOAnimalNoDomicilio().CreateTable();

                    new DAO.DAORendaFamiliar().CreateTable();

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new Views.LoginPage()) { BarBackgroundColor = Color.SteelBlue });

                } catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine(ex);
                } finally {
                    IsBusy = false;
                };
            });
        }
    }
}
