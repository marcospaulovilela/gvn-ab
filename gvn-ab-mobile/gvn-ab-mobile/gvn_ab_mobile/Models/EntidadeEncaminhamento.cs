using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Models
{
    public abstract class EntidadeEncaminhamento : Helpers.ObservableObject
    {
        public EntidadeEncaminhamento() { }

        public EntidadeEncaminhamento(string descricao)
        {
            this.Descricao = descricao;
            this.Observacao = "";
        }

        public EntidadeEncaminhamento(string descricao, string observacao)
        {
            this.Descricao = descricao;
            this.Observacao = observacao;
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

        private string _observacao;
        public string Observacao
        {
            get { return this._observacao; }
            set { SetProperty(ref _observacao, value); }
        }

        public override string ToString()
        {
            return $"{this.Descricao}";
        }
    }
}
