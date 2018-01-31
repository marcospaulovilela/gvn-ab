using gvn_ab_mobile.Controls;
using gvn_ab_mobile.Helpers;
using System;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views {

    public class FamiliaRowViewModel : ViewModels.BaseViewModel {
        private Models.FichaFamilia FamiliaItem { get; set; }
        public FamiliaRowViewModel(object item) {
            this.RendasFamiliares = new ObservableRangeCollection<Models.RendaFamiliar>(new DAO.DAORendaFamiliar().Select());

            this.FamiliaItem = item as Models.FichaFamilia;
            if (this.FamiliaItem != null && this.FamiliaItem.RendaFamiliar != null) {
                var cod = this.FamiliaItem.RendaFamiliar.Codigo;
                var result = this.RendasFamiliares.Where(o => o.Codigo == cod).First();
                this.FamiliaItem.RendaFamiliar = result ; 
            };

        }

        public ObservableRangeCollection<Models.RendaFamiliar> RendasFamiliares { get; set; }

        private DateTime dataNascimentoResponsavel;
        public DateTime DataNascimentoResponsavel {
            get { return dataNascimentoResponsavel; }
            set {
                this.FamiliaItem.DataNascimentoResponsavel = value;
                if(this.ResideDesde < value) {
                    this.ResideDesde = value;
                };
                SetProperty(ref dataNascimentoResponsavel, value);
            }
        }

        private DateTime resideDesde;
        public DateTime ResideDesde {
            get { return resideDesde; }
            set {
                this.FamiliaItem.ResideDesde = value;
                SetProperty(ref resideDesde, value);
            }
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FamiliaRow : gvn_ab_mobile.Controls.TableGridPage {
        public FamiliaRow(gvn_ab_mobile.Controls.TableGridViewModel viewModel, object item, object itemViewModel = null) : base(viewModel, item, itemViewModel) {
            InitializeComponent();
        }

    }
}