using System;
using System.Collections.Generic;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace gvn_ab_mobile.Models.AssinaturaTermoRecusa
{
    public class TermoDeRecusaModel : Helpers.ObservableObject
    {

        //Campo ID - Tipo long
        private long? _id;
        [PrimaryKey, AutoIncrement] //Chave Primária com incremento automático
        public long? Id
        {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        //Campo NomeCompletoCidadao - Tipo String
        private string _nomeCompletoCidadao;
        public string NomeCompletoCidadao
        {
            get { return this._nomeCompletoCidadao; }
            set { SetProperty(ref _nomeCompletoCidadao, value); }
        }

        //Campo RGCidadao - Tipo String
        private string _rgCidadao;
        public string RGCidadao
        {
            get { return this._rgCidadao; }
            set { SetProperty(ref _rgCidadao, value); }
        }

        //Campo AssinaturaBase64 - Tipo String
        private string _assinaturaBase64;
        public string AssinaturaBase64
        {
            get { return this._assinaturaBase64; }
            set { SetProperty(ref _assinaturaBase64, value); }
        }

        public long? HeaderId { get; set; }
        //CAMPO HEADERTRANSPORT
        private FichaUnicaLotacaoHeader _header;

        [NotNull, OneToOne("HeaderId")]
        public FichaUnicaLotacaoHeader Header
        {
            get { return this._header; }
            set { SetProperty(ref _header, value); }
        }

    }
}
