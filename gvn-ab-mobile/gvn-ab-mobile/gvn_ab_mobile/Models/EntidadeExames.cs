using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Models
{
    public abstract class EntidadeExames : Helpers.ObservableObject
    {
        public EntidadeExames() { }

        public EntidadeExames(string descricaoAB, string codigoSIGTAP)
        {
            this.DescricaoAB = descricaoAB;
            this.CodigoSIGTAP = codigoSIGTAP;
        }

        private string _codigoAB;
        [PrimaryKey]
        public string CodigoAB
        {
            get { return this._codigoAB; }
            set { SetProperty(ref _codigoAB, value); }
        }

        private string _descricaoAB;
        [MaxLength(100), NotNull]
        public string DescricaoAB
        {
            get { return this._descricaoAB; }
            set { SetProperty(ref _descricaoAB, value); }
        }

        private string _codigoSIGTAP;
        public string CodigoSIGTAP
        {
            get { return this._codigoSIGTAP; }
            set { SetProperty(ref _codigoSIGTAP, value); }
        }

        public override string ToString()
        {
            return $"{this.DescricaoAB}";
        }
    }
}
