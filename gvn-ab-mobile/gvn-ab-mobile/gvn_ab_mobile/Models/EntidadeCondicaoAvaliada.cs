using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Models
{
    public abstract class EntidadeCondicaoAvaliada : Helpers.ObservableObject
    {
        public EntidadeCondicaoAvaliada() { }

        public EntidadeCondicaoAvaliada(string descricaoAB, string ciap2Relacionada)
        {
            this.DescricaoAB = descricaoAB;
            this.CIAP2Relacionada = ciap2Relacionada;
        }

        private string _codigoAB;
        [PrimaryKey]
        public string CodigoAB
        {
            get { return this._codigoAB; }
            set { SetProperty(ref _codigoAB, value); }
        }

        private string _descricaoAB;
        public string DescricaoAB
        {
            get { return this._descricaoAB; }
            set { SetProperty(ref _descricaoAB, value); }
        }

        private string _ciap2Relacionada;
        public string CIAP2Relacionada
        {
            get { return this._ciap2Relacionada; }
            set { SetProperty(ref _ciap2Relacionada, value); }
        }

        public override string ToString()
        {
            return $"{this.DescricaoAB}";
        }
    }
}
