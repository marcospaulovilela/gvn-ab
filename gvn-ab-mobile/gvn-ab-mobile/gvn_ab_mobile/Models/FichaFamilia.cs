﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLiteNetExtensions.Attributes;
using SQLite;

namespace gvn_ab_mobile.Models
{
    class FichaFamilia : Helpers.ObservableObject
    {

        //Campo ID - Tipo long
        private long? _id;
        [PrimaryKey, AutoIncrement] //Chave Primária com incremento automático
        public long? Id
        {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        //Campo IDFichaCadastroDomiciliarTerritorial - Tipo long
        public long _idFichaCadastroDomiciliarTerritorial;
        [ForeignKey(typeof(FichaCadastroDomiciliarTerritorial))] //Chave Estrangeira
        public long IdFichaCadastroDomiciliarTerritorial
        {
            get { return this._idFichaCadastroDomiciliarTerritorial; }
            set { SetProperty(ref _idFichaCadastroDomiciliarTerritorial, value);  }
        }

        //INÍCIO FICHA FAMÍLIA

        //Campo dataNascimentoResponsavel - Tipo long
        private long _dataNascimentoResponsavel; //Não Obrigatório
        public long DataNascimentoResponsavel
        {
            get { return this._dataNascimentoResponsavel; }
            set { SetProperty(ref _dataNascimentoResponsavel, value); }
        }

        //Campo numeroCnsResponsavel - Tipo string
        private string _numeroCnsResponsavel; //Obrigatório
        [NotNull, MaxLength(15)] //Mínimo 15 caracteres; Máximo 15 caracteres
        public string NumeroCnsResponsavel
        {
            get { return this._numeroCnsResponsavel; }
            set { SetProperty(ref _numeroCnsResponsavel, value); }
        }

        //Campo numeroMembrosFamilia - Tipo Integer
        private int _numeroMembrosFamilia; //Não Obrigatório
        [MaxLength(2)] //Mínimo 0 dígitos; Máximo 2 dígitos
        public int NumeroMembrosFamilia
        {
            get { return this._numeroMembrosFamilia; }
            set { SetProperty(ref _numeroMembrosFamilia, value); }
        }

        //Campo numeroProntuario - Tipo string
        private string _numeroProntuario; //Não Obrigatório
        [MaxLength(30)] //Mínimo 0 caracteres; Máximo 30 caracteres
        public string NumeroProntuario
        {
            get { return this._numeroProntuario; }
            set { SetProperty(ref _numeroProntuario, value); }
        }

        //Campo rendaFamiliar - Tipo long
        private long _rendaFamiliar; //Não Obrigatório
        public long RendaFamiliar
        {
            get { return this._rendaFamiliar; }
            set { SetProperty(ref _rendaFamiliar, value); }
        }

        //Campo rendaFamiliar - Tipo long
        private long _resideDesde; //Não Obrigatório
        public long ResideDesde
        {
            get { return this._resideDesde; }
            set { SetProperty(ref _resideDesde, value); }
        }

        //Campo rendaFamiliar - Tipo boolean
        private bool _stMudanca; //Não Obrigatório
        public bool StMudanca
        {
            get { return this._stMudanca; }
            set { SetProperty(ref _stMudanca, value); }
        }

        //FIM FICHA FAMÍLIA

    }
}
