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
    public class FichasPageViewModel : BaseViewModel
    {
        private Page Page { get; set; }

        public ICommand Continuar { get; }

        public ObservableCollection<object> FichasCadastroIndividual { get; set; }
        public ObservableCollection<object> FichasCadastroDomiciliar { get; set; }
        public ObservableCollection<object> FichasVisitaDomiciliar { get; set; }

        public FichasPageViewModel(Page page)
        {
            this.Page = page;

            this.FichasCadastroIndividual = new ObservableCollection<object>();
            this.FichasCadastroDomiciliar = new ObservableCollection<object>();
            this.FichasVisitaDomiciliar = new ObservableCollection<object>();
        }

    }

}