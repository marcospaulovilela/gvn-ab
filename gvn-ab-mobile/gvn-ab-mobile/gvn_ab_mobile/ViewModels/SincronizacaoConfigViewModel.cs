﻿using gvn_ab_mobile.Helpers;
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

            this.Title = "Criando enumeradores sexo";
            using (DAO.DAOSexo DAOSexo = new DAO.DAOSexo()) { DAOSexo.CreateTable(); }
            this.Title = "Criando enumeradores pais";
            using (DAO.DAOPais DAOPais = new DAO.DAOPais()) { DAOPais.CreateTable(); }
            this.Title = "Criando enumeradores raça/cor";
            using (DAO.DAORacaCor DAORacaCor = new DAO.DAORacaCor()) { DAORacaCor.CreateTable(); }
            this.Title = "Criando enumeradores etinia";
            using (DAO.DAOEtnia DAOEtnia = new DAO.DAOEtnia()) { DAOEtnia.CreateTable(); }
            this.Title = "Criando enumeradores orientação sexual";
            using (DAO.DAOOrientacaoSexual DAOOrientacaoSexual = new DAO.DAOOrientacaoSexual()) { DAOOrientacaoSexual.CreateTable(); }
            this.Title = "";
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
            using (DAO.DAOOrigemAlimentacao DAOOrigemAlimentacao = new DAO.DAOOrigemAlimentacao()) { DAOOrigemAlimentacao.CreateTable(); }
            using (DAO.DAOTempoSituacaoDeRua DAOTempoSituacaoDeRua = new DAO.DAOTempoSituacaoDeRua()) { DAOTempoSituacaoDeRua.CreateTable(); }
            using (DAO.DAOMunicipios DAOMunicipios = new DAO.DAOMunicipios()) { DAOMunicipios.CreateTable(); }
            
            using (DAO.DAOUF DAOUF = new DAO.DAOUF()) { DAOUF.CreateTable(); }
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

            //using (DAO.DAOListaCiapCondicaoAvaliada DAOListaCiapCondicaoAvaliada = new DAO.DAOListaCiapCondicaoAvaliada()) { DAOListaCiapCondicaoAvaliada.CreateTable(); }
            //using (DAO.DAOListaExames DAOListaExames = new DAO.DAOListaExames()) { DAOListaExames.CreateTable(); }
            //using (DAO.DAONasfs DAONasfs = new DAO.DAONasfs()) { DAONasfs.CreateTable(); }
            //using (DAO.DAOCondutaEncaminhamento DAOCondutaEncaminhamento = new DAO.DAOCondutaEncaminhamento()) { DAOCondutaEncaminhamento.CreateTable(); }
            //using (DAO.DAOTurno DAOTurno = new DAO.DAOTurno()) { DAOTurno.CreateTable(); }
            //using (DAO.DAOLocalDeAtendimento DAOLocalAtendimento = new DAO.DAOLocalDeAtendimento()) { DAOLocalAtendimento.CreateTable(); }
            //using (DAO.DAOTipoDeAtendimento DAOTipoAtendimento = new DAO.DAOTipoDeAtendimento()) { DAOTipoAtendimento.CreateTable(); }
            //using (DAO.DAOModalidadeAD DAOModalidadeAD = new DAO.DAOModalidadeAD()) { DAOModalidadeAD.CreateTable(); }
            //using (DAO.DAORacionalidadeSaude DAORacionalidadeSaude = new DAO.DAORacionalidadeSaude()) { DAORacionalidadeSaude.CreateTable(); }
            //using (DAO.DAOAleitamentoMaterno DAOAleitamentoMaterno = new DAO.DAOAleitamentoMaterno()) { DAOAleitamentoMaterno.CreateTable(); }

            using (DAO.DAODesfecho DAODesfecho = new DAO.DAODesfecho()) { DAODesfecho.CreateTable(); }
            using (DAO.DAOMotivoVisita DAOMotivoVisita = new DAO.DAOMotivoVisita()) { DAOMotivoVisita.CreateTable(); }

            //using (DAO.DAOFichaCadastroIndividual DAOFichaCadastroIndividual = new DAO.DAOFichaCadastroIndividual()) { DAOFichaCadastroIndividual.CreateTable(); }

        }

        private void SyncOfflineExecute() {
            this.IsBusy = true;
            Task.Run( () => {
                try {
                    this.CargaDados();

                    using (DAO.DAOEstabelecimento DAOEstabelecimento = new DAO.DAOEstabelecimento()) {
                        DAOEstabelecimento.CreateTable();
                        DAOEstabelecimento.Insert(new Models.Estabelecimento() { CodUnidade = 1, DesNomFantasia = "Unidade fixa", ImpCnes="1111" });
                    };
    
                    #region Profissionais
                    using (DAO.DAOProfissional DAOProfissional = new DAO.DAOProfissional()) {
                        using (DAO.DAOEquipe DAOEquipe = new DAO.DAOEquipe()) {
                            DAOEquipe.CreateTable();
                        };
                        using (DAO.DAOCbo DAOCbo = new DAO.DAOCbo()) {
                            DAOCbo.CreateTable();
                        };


                        DAOProfissional.CreateTable();
                        DAOProfissional.Insert(new Models.Profissional() {
                            CpfProfissional = "123456",
                            CnsProfissional = "123456",
                            DesLogin = "admsaude",
                            DesSenha = "123456",
                            NomProfissional = "ADM Saude",
                            Cbos = new List<Models.Cbo>() {
                                new Models.Cbo() {
                                    CodCbo = "352210", NomCbo="AGENTE DE SAÚDE PÚBLICA",
                                    Equipes = new List<Models.Equipe>(){
                                        new Models.Equipe(){
                                            CodEquipe = "123456",
                                            DesEquipe = "EQUIPE TESTE"
                                        },
                                        new Models.Equipe(){
                                            CodEquipe = "123457",
                                            DesEquipe = "EQUIPE TESTE2"
                                        }
                                    }
                                },                                
                                new Models.Cbo() { CodCbo = "225125", NomCbo="MÉDICO CLÍNICO", Equipes = new List<Models.Equipe>(){
                                        new Models.Equipe(){
                                            CodEquipe = "123458",
                                            DesEquipe = "EQUIPE TESTE3"
                                        }
                                    }
                                },
                                new Models.Cbo() { CodCbo = "223505", NomCbo = "ENFERMEIRO", Equipes = new List<Models.Equipe>() }
                            }
                        });
                    };
                    #endregion

                    using (DAO.DAOSincronizacaoConfig DAOSync = new DAO.DAOSincronizacaoConfig()) {
                        DAOSync.CreateTable();
                        DAOSync.Insert(this.SincronizacaoConfig);
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
                    this.Estabelecimentos.Clear();
                    this.Estabelecimentos.AddRange(await new RestAPI($"http://{this.SincronizacaoConfig.DesEndereco}/Governa.Saude.AtencaoBasica.Ministerio/Handlers/Mobile/Estabelecimento.ashx").GetAsync<Models.Estabelecimento>());

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
                    this.SincronizacaoConfig.CodEstabelecimento = this.Estabelecimento.CodUnidade;
                    var TaskGetProfissionais = new RestAPI($"http://{this.SincronizacaoConfig.DesEndereco}/Governa.Saude.AtencaoBasica.Ministerio/Handlers/Mobile/Profissional.ashx?codUnidade={this.Estabelecimento.CodUnidade}").GetAsync<Models.Profissional>();
                    var TaskGetOcupacoes = new RestAPI($"http://{this.SincronizacaoConfig.DesEndereco}/Governa.Saude.AtencaoBasica.Ministerio/Handlers/Mobile/Cbo.ashx").GetAsync<Models.Ocupacao>();

                    this.CargaDados();
                    
                    using (DAO.DAOEstabelecimento DAOEstabelecimento = new DAO.DAOEstabelecimento()) {
                        DAOEstabelecimento.CreateTable();
                        DAOEstabelecimento.Insert(this.Estabelecimento);
                    }

                    #region Profissionais
                    using (DAO.DAOProfissional DAOProfissional = new DAO.DAOProfissional()) {
                        var profissionais = await TaskGetProfissionais;
                        profissionais.ForEach(o => o.DesSenha = "123456");

                        using (DAO.DAOEquipe DAOEquipe = new DAO.DAOEquipe()) {
                            DAOEquipe.CreateTable();
                        };
                        using (DAO.DAOCbo DAOCbo = new DAO.DAOCbo()) {
                            DAOCbo.CreateTable();
                        };

                        DAOProfissional.CreateTable();
                        DAOProfissional.Insert(profissionais);
                    };
                    #endregion

                    using (DAO.DAOSincronizacaoConfig DAOSync = new DAO.DAOSincronizacaoConfig()) {
                        DAOSync.CreateTable();
                        DAOSync.Insert(this.SincronizacaoConfig);
                    };


                    var ocupacoes = await TaskGetOcupacoes;
                    using (DAO.DAOOcupacao DAOOcupacao = new DAO.DAOOcupacao()) {
                        if(DAOOcupacao.CreateTable() == 1) {
                            DAOOcupacao.Insert(ocupacoes);
                        };                        
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
