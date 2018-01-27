using gvn_ab_mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class FichaVisitaDomiciliarViewModel : BaseViewModel {

        private Views.FichaVisitaDomiciliarPage.ListFichaVisitaDomiciliarPage RootPage { get; set; }

        public ICommand Continuar { get; }

        public Models.FichaVisitaDomiciliarTerritorial Ficha { get; set; }

        // USADO PAGE 1
        public ObservableRangeCollection<Models.Turno> Turnos { get; set; }
        public ObservableRangeCollection<Models.Sexo> Sexos { get; set; }
        public ObservableCollection<Models.TipoDeImovel> TiposImoveis { get; set; }
        public ObservableCollection<Models.MotivoVisita> MotivosVisitas { get; set; }

        public List<Models.MotivoVisita> motivosVisitasLiberados;
        public List<Models.MotivoVisita> MotivosVisitasLiberados {
            get { return this.motivosVisitasLiberados; }
            set { SetProperty(ref this.motivosVisitasLiberados, value); }
        }

        public ObservableCollection<object> motivosSelecionados;
        public ObservableCollection<object> MotivosSelecionados {
            get { return this.motivosSelecionados; }
            set { SetProperty(ref this.motivosSelecionados, value); }

        }
        public ObservableCollection<Models.Desfecho> Desfechos { get; set; }

        private bool _stForaArea;
        public bool StForaArea {
            get { return this._stForaArea; }
            set {
                this.Ficha.StForaArea = value;
                this.Ficha.Microarea = value ? "FA" : string.Empty;
                
                SetProperty(ref _stForaArea, value);
                OnPropertyChanged("IsForaArea");
            }
        }
        public bool IsForaArea {
            get {
                return !this.StForaArea;
            }
        }

        private Models.Sexo _sexo; //Obrigatório
        public Models.Sexo Sexo {
            get { return this._sexo; }
            set {
                this.Ficha.Sexo = value;
                this.Ficha.SexoId = value?.Codigo;

                SetProperty(ref _sexo, value);
            }
        }

        private Models.Turno _turno; //Obrigatório
        public Models.Turno Turno {
            get { return this._turno; }
            set {
                this.Ficha.TurnoId = value?.Codigo;
                this.Ficha.Turno = value;

                SetProperty(ref _turno, value);
            }
        }

        private Models.TipoDeImovel _tipoDeImovel; //Obrigatório
        public Models.TipoDeImovel TipoDeImovel {
            get { return this._tipoDeImovel; }
            set {
                this.Ficha.TipoDeImovelId = value?.Codigo;
                this.Ficha.TipoDeImovel = value;

                if (!((value.Codigo == 2) || (value.Codigo == 3) || (value.Codigo == 4) || (value.Codigo == 5) || (value.Codigo == 6) || (value.Codigo == 12))) {
                    this.MotivosVisitasLiberados = this.MotivosVisitas.Select(o => o).ToList();
                } else {
                    this.MotivosVisitasLiberados = this.MotivosVisitas.Where(o => o.Codigo == 1 || o.Codigo == 34 || o.Codigo == 35 || o.Codigo == 36 || o.Codigo == 37 || o.Codigo == 27 || o.Codigo == 31 || o.Codigo == 28).ToList();
                    if (this.MotivosSelecionados?.Any(o => this.MotivosVisitasLiberados.IndexOf((Models.MotivoVisita)o) == -1) ?? false) {
                        //this.MotivosSelecionados = new ObservableCollection<object>();
                    };
                };

                SetProperty(ref _tipoDeImovel, value);
                OnPropertyChanged("IsNotImovelCod2and3and4and5and6and12");
                OnPropertyChanged("IsVisitaRealizadaAndIsNotImovelCod2and3and4and5and6and12");
            }
        }
        public bool IsNotImovelCod2and3and4and5and6and12 {
            get {
                return (!((this.TipoDeImovel?.Codigo == 2) || (this.TipoDeImovel?.Codigo == 3) || (this.TipoDeImovel?.Codigo == 4) || (this.TipoDeImovel?.Codigo == 5) || (this.TipoDeImovel?.Codigo == 6) || (this.TipoDeImovel?.Codigo == 12)));
            }
        }

        private Models.Desfecho _desfecho;
        public Models.Desfecho Desfecho {
            get { return this._desfecho; }
            set {
                this.Ficha.DesfechoId = value?.Codigo;
                this.Ficha.Desfecho = value;

                SetProperty(ref _desfecho, value);
                OnPropertyChanged("IsVisitaRealizada");
                OnPropertyChanged("IsVisitaRealizadaAndIsNotImovelCod2and3and4and5and6and12");
            }
        }

        public bool IsVisitaRealizada {
            get {
                return this.Desfecho?.Codigo == 1;
            }
        }

        public bool IsVisitaRealizadaAndIsNotImovelCod2and3and4and5and6and12 {
            get {
                return ((this.IsVisitaRealizada == true) && (this.IsNotImovelCod2and3and4and5and6and12 == true));
            }
        }

        public FichaVisitaDomiciliarViewModel(Views.FichaVisitaDomiciliarPage.ListFichaVisitaDomiciliarPage rootPage, Models.FichaVisitaDomiciliarTerritorial ficha = null) {
            this.RootPage = rootPage;

            this.Continuar = new Command(async () => ContinuarExecute());

            this.Turnos = new ObservableRangeCollection<Models.Turno>(new DAO.DAOTurno().Select());
            this.Sexos = new ObservableRangeCollection<Models.Sexo>(new DAO.DAOSexo().Select()); //traz todos os sexos na base.
            this.TiposImoveis = new ObservableCollection<Models.TipoDeImovel>(new DAO.DAOTipoDeImovel().Select());
            this.MotivosVisitas = new ObservableCollection<Models.MotivoVisita>(new DAO.DAOMotivoVisita().Select());
            this.Desfechos = new ObservableCollection<Models.Desfecho>(new DAO.DAODesfecho().Select());

            this.MotivosVisitasLiberados = this.MotivosVisitas.Select(o => o).ToList();

            if (ficha == null) {
                this.Ficha = new Models.FichaVisitaDomiciliarTerritorial();
                this.MotivosSelecionados = new ObservableCollection<object>();

            } else {
                this.Ficha = ficha;

                if (ficha.StForaArea) this.StForaArea = true; // SE APENAS SETAR O VALOR DA FICHA, O CAMPO MICRO AREA SERÁ LIMPO !!! CUIDADO.

                this.Sexo = this.Sexos.Where(o => o.Codigo == ficha.SexoId).FirstOrDefault();
                this.Turno = this.Turnos.Where(o => o.Codigo == ficha.TurnoId).FirstOrDefault();
                this.TipoDeImovel = this.TiposImoveis.Where(o => o.Codigo == ficha.TipoDeImovelId).FirstOrDefault();
                this.Desfecho = this.Desfechos.Where(o => o.Codigo == ficha.DesfechoId).FirstOrDefault();

                var SelectedItems = this.MotivosVisitas.Where(o => ficha.MotivosVisita.Any(o2 => o.Codigo == o2.Codigo)).ToList();
                this.MotivosSelecionados = new ObservableCollection<object>(this.Ficha.MotivosVisita = SelectedItems);
            };
        }

        private void ContinuarExecute() {
            this.IsBusy = true;
            Task.Run(async () => {
                this.Ficha.MotivosVisita = this.MotivosSelecionados.Select(o => (Models.MotivoVisita)o).ToList();

                using (DAO.DAOFichaUnicaLotacaoHeader DAOFichaUnicaLotacaoHeader = new DAO.DAOFichaUnicaLotacaoHeader())
                using (DAO.DAOFichaVisitaDomiciliar DAOFichaVisitaDomiciliar = new DAO.DAOFichaVisitaDomiciliar()) {
                    try {
                        if (!this.Ficha.Id.HasValue) {
                            this.Ficha.Header = new Models.FichaUnicaLotacaoHeader() {
                                Cbo = this.RootPage.MenuPage.ViewModel.Cbo.CodCbo,
                                CnsProfissional = this.RootPage.MenuPage.ViewModel.Profissional.CnsProfissional,
                                Cnes = this.RootPage.MenuPage.ViewModel.Estabelecimento.ImpCnes,
                                Ine = this.RootPage.MenuPage.ViewModel.Equipe.CodEquipe,
                                DataAtendimento = DateTime.Now
                            };
                            DAOFichaUnicaLotacaoHeader.Insert(this.Ficha.Header);
                            DAOFichaVisitaDomiciliar.Insert(this.Ficha);
                        } else {
                            DAOFichaVisitaDomiciliar.Update(this.Ficha);
                        };
                        
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => {
                            try {
                                //var BackCount = this.RootPage.Navigation.NavigationStack.Count - 2;
                                //for (var counter = 1; counter < BackCount; counter++) {
                                //    this.RootPage.Navigation.RemovePage(this.RootPage.Navigation.NavigationStack[this.RootPage.Navigation.NavigationStack.Count - 2]);
                                //}
                                await this.RootPage.Navigation.PopAsync();
                            } catch (Exception e) {

                            };
                        });
                    } catch (Exception e) {
                        System.Diagnostics.Debug.WriteLine(e);
                    } finally {
                        this.IsBusy = false;
                    };
                };
            });
        }

    }

}
