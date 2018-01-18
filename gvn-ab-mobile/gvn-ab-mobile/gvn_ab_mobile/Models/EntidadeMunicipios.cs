using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Models
{
    public abstract class EntidadeMunicipios : Helpers.ObservableObject
    {
        public EntidadeMunicipios() { }

        public EntidadeMunicipios(string descricao, string siglaUF)
        {
            this.Descricao = descricao;
            this.SiglaUF = siglaUF;
        }

        private long? _codigo;
        [PrimaryKey]
        public long? Codigo
        {
            get { return this._codigo; }
            set { SetProperty(ref _codigo, value); }
        }

        private string _descricao;
        [MaxLength(100), NotNull]
        public string Descricao
        {
            get { return this._descricao; }
            set { SetProperty(ref _descricao, value); }
        }

        private string _siglaUF;
        public string SiglaUF
        {
            get { return this._siglaUF; }
            set { SetProperty(ref _siglaUF, value); }
        }

        public override string ToString()
        {
            return $"{this.Descricao + " - "  + this.SiglaUF}";
        }
    }
}
