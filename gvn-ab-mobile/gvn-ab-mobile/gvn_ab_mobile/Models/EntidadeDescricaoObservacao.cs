using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Models
{
    public abstract class EntidadeDescricaoObservacao : Helpers.ObservableObject
    {
        public EntidadeDescricaoObservacao() { }

        public EntidadeDescricaoObservacao(string descricao)
        {
            this.Descricao = descricao;
            this.Observacoes = "";
        }

        public EntidadeDescricaoObservacao(string descricao, string observacoes)
        {
            this.Descricao = descricao;
            this.Observacoes = observacoes;
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

        private string _observacoes;
        public string Observacoes
        {
            get { return this._observacoes; }
            set { SetProperty(ref _observacoes, value); }
        }

        public override string ToString()
        {
            return $"{this.Descricao}";
        }
    }
}
