using gvn_ab_mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels
{
    public class FichaVisitaDomiciliarViewModel : BaseViewModel
    {

        private Page Page { get; set; }

        public ICommand Continuar { get; }

        public Models.FichaVisitaDomiciliarTerritorial Ficha { get; set; }

        // USADO PAGE 1
        public ObservableRangeCollection<Models.Turno> Turnos { get; set; }
        public ObservableRangeCollection<Models.Sexo> Sexos { get; set; }
        public ObservableCollection<Models.TipoDeImovel> TiposImoveis { get; set; }
        public ObservableCollection<Models.MotivoVisita> MotivosVisitas { get; set; }
        public ObservableCollection<object> MotivosSelecionados { get; } = new ObservableCollection<object>();
        public ObservableCollection<Models.Desfecho> Desfechos { get; set; }

        private bool _stForaArea;
        public bool StForaArea
        {
            get { return this._stForaArea; }
            set
            {
                this.Ficha.StForaArea = value;
                this.Ficha.Microarea = value ? "FA" : string.Empty;

                SetProperty(ref _stForaArea, value);
                OnPropertyChanged("IsForaArea");
            }
        }
        public bool IsForaArea
        {
            get
            {
                return !this.StForaArea;
            }
        }

        private Models.Sexo _sexo; //Obrigatório
        public Models.Sexo Sexo
        {
            get { return this._sexo; }
            set
            {
                this.Ficha.Sexo = value;

                SetProperty(ref _sexo, value);
            }
        }

        private Models.Turno _turno; //Obrigatório
        public Models.Turno Turno
        {
            get { return this._turno; }
            set
            {
                this.Ficha.Turno = value;

                SetProperty(ref _turno, value);
            }
        }

        private Models.TipoDeImovel _tipoDeImovel; //Obrigatório
        public Models.TipoDeImovel TipoDeImovel
        {
            get { return this._tipoDeImovel; }
            set {
                this.Ficha.TipoDeImovel = value;

                SetProperty(ref _tipoDeImovel, value);
                OnPropertyChanged("IsNotImovelCod2and3and4and5and6and12");
                OnPropertyChanged("IsVisitaRealizadaAndIsNotImovelCod2and3and4and5and6and12");
            }
        }
        public bool IsNotImovelCod2and3and4and5and6and12
        {
            get
            {
                return !((this.TipoDeImovel?.Codigo == 2) || (this.TipoDeImovel?.Codigo == 3) || (this.TipoDeImovel?.Codigo == 4)
                    || (this.TipoDeImovel?.Codigo == 5) || (this.TipoDeImovel?.Codigo == 6) || (this.TipoDeImovel?.Codigo == 12));
            }
        }
        

        private Models.Desfecho _desfecho;
        public Models.Desfecho Desfecho
        {
            get { return this._desfecho; }
            set {
                this.Ficha.Desfecho = value;

                SetProperty(ref _desfecho, value);
                OnPropertyChanged("IsVisitaRealizada");
                OnPropertyChanged("IsVisitaRealizadaAndIsNotImovelCod2and3and4and5and6and12");
            }
        }
        public bool IsVisitaRealizada
        {
            get
            {
                return this.Desfecho?.Codigo == 1;
            }
        }

        public bool IsVisitaRealizadaAndIsNotImovelCod2and3and4and5and6and12
        {
            get
            {
                return ((this.IsVisitaRealizada == true) && (this.IsNotImovelCod2and3and4and5and6and12 == true));
            }
        }


        public FichaVisitaDomiciliarViewModel(Page page)
        {
            this.Ficha = new Models.FichaVisitaDomiciliarTerritorial();
            this.Page = page;

            this.Continuar = new Command(async () => await ContinuarExecuteAsync());

            this.Turnos = new ObservableRangeCollection<Models.Turno>(new DAO.DAOTurno().Select());
            this.Sexos = new ObservableRangeCollection<Models.Sexo>(new DAO.DAOSexo().Select()); //traz todos os sexos na base.
            this.TiposImoveis = new ObservableCollection<Models.TipoDeImovel>(new DAO.DAOTipoDeImovel().Select());
            this.MotivosVisitas = new ObservableCollection<Models.MotivoVisita>(new DAO.DAOMotivoVisita().Select());
            this.Desfechos = new ObservableCollection<Models.Desfecho>(new DAO.DAODesfecho().Select());
        }

        private async System.Threading.Tasks.Task ContinuarExecuteAsync()
        {
            var CurrentPage = this.Page.Navigation.NavigationStack.Last(); //PEGA A ULTIMA PAGINA NA PILHA DE NAVEGAÇÃO, OU SEJA A ATUAL.
        }

    }

}
