using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Models {
    public class SincronizacaoConfig : Helpers.ObservableObject {

        /// <summary>
        /// Really? 
        /// </summary>
        private long? _id;
        [PrimaryKey, AutoIncrement]
        public long? Id {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        /// <summary>
        /// ENDERECO DE CONEXÃO COM O SISTEMA GOVERNA.SAUDE.ATENCAOBASICA
        /// </summary>
        private string _DesEndereco;
        [NotNull]
        public string DesEndereco {
            get { return this._DesEndereco; }
            set {
                SetProperty(ref _DesEndereco, value);
                OnPropertyChanged("hasDesEndereco");
            }
        }

        public bool hasDesEndereco {
            get {
                return !string.IsNullOrEmpty(this.DesEndereco);
            }
            set {
                
            }
        }

        /// <summary>
        /// UNIDADE DE ATENDIMENTO (ESTABELECIMENTO) AO QUAL O TABLE SERA SINCRONIZADO
        /// </summary>
        private long? _CodEstabelecimento;
        [NotNull]
        public long? CodEstabelecimento {
            get { return this._CodEstabelecimento; }
            set { SetProperty(ref _CodEstabelecimento, value); }
        }

        ///
        private string _DesVersao;
        [NotNull]
        public string DesVersao {
            get { return this._DesVersao; }
            set { SetProperty(ref _DesVersao, value); }
        }
    }
}
