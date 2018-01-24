using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Models
{
    public abstract class EntidadeEnumerador : Helpers.ObservableObject
    {
        public EntidadeEnumerador() { }

        public EntidadeEnumerador(string descricao)
        {
            this.Descricao = descricao;
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

        [ForeignKey(typeof(FichaCadastroIndividual))]
        public long? FichaCadastroIndividualId { get; set; }

        [ForeignKey(typeof(FichaCadastroDomiciliarTerritorial))]
        public long? FichaCadastroDomiciliarTerritorialId { get; set; }

        public override string ToString()
        {
            return $"{this.Descricao}";
        }
    }
}