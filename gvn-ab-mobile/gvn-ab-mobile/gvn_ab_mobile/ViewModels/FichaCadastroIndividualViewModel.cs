using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels
{
    public class FichaCadastroIndividualViewModel : BaseViewModel
    {
        private Page Page { get; set; }

        public Models.FichaCadastroIndividual Ficha { get; set; }


        public FichaCadastroIndividualViewModel(Page page)
        {
            this.Ficha = new Models.FichaCadastroIndividual();
            this.Page = page;
        }
    }
}