﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO {

    abstract class DAOEnumerador<T> : DAO<T> 
    where T : Models.EntidadeEnumerador, new() {
        public override int? Insert(T obj) {
            if (obj == null) return null;
            try {
                string cmdText = $"INSERT INTO {typeof(T).Name} (Codigo, Descricao) values (?, ?)";
                var cmd = connection.CreateCommand(cmdText, obj.Codigo, obj.Descricao);
                return cmd.ExecuteNonQuery();
            } catch (Exception e) {
                return null;
            };
        }

        public override int? Insert(IEnumerable<T> obj) {
            if (obj == null || !obj.Any()) return null;
            try {
                StringBuilder cmdText = new StringBuilder($"INSERT INTO {typeof(T).Name} (Codigo, Descricao) values ");

                foreach (var o in obj) {
                    cmdText.Append($"('{o.Codigo}', '{o.Descricao.Replace("'", "\'")}'),");
                }
                cmdText[cmdText.Length - 1] = ' ';

                var cmd = connection.CreateCommand(cmdText.ToString());
                var result = cmd.ExecuteNonQuery();

                this.connection.Commit();
                
                return result;
            } catch (Exception e) {
                return null;
            };
        }
    }

    //Ficha Cadastro Individual

    class DAOPais : DAOEnumerador<Models.Pais>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Pais>() {
                new Models.Pais("AFEGANISTÃO") { Codigo = 1 },
                new Models.Pais("ÁFRICA DO SUL") { Codigo = 2 },
                new Models.Pais("ALBÂNIA") { Codigo = 3 },
                new Models.Pais("ALEMANHA") { Codigo = 4 },
                new Models.Pais("ANDORRA") { Codigo = 5 },
                new Models.Pais("ANGOLA") { Codigo = 6 },
                new Models.Pais("ANGUILLA") { Codigo = 7 },
                new Models.Pais("ANTÁRCTICA") { Codigo = 8 },
                new Models.Pais("ANTIGUA E BARBUDA") { Codigo = 9 },
                new Models.Pais("ANTILHAS HOLANDESAS") { Codigo = 10 },
                new Models.Pais("ARÁBIA SAUDITA") { Codigo = 11 },
                new Models.Pais("ARGÉLIA") { Codigo = 12 },
                new Models.Pais("ARGENTINA") { Codigo = 13 },
                new Models.Pais("ARMÊNIA") { Codigo = 14 },
                new Models.Pais("ARUBA") { Codigo = 15 },
                new Models.Pais("AUSTRÁLIA") { Codigo = 16 },
                new Models.Pais("ÁUSTRIA") { Codigo = 17 },
                new Models.Pais("AZERBAIDJÃO") { Codigo = 18 },
                new Models.Pais("BAHAMAS") { Codigo = 19 },
                new Models.Pais("BANGLADESH") { Codigo = 20 },
                new Models.Pais("BARBADOS") { Codigo = 21 },
                new Models.Pais("BAREIN") { Codigo = 22 },
                new Models.Pais("BELARUS") { Codigo = 23 },
                new Models.Pais("BÉLGICA") { Codigo = 24 },
                new Models.Pais("BELIZE") { Codigo = 25 },
                new Models.Pais("BENIN") { Codigo = 26 },
                new Models.Pais("BERMUDA") { Codigo = 27 },
                new Models.Pais("BOLÍVIA") { Codigo = 28 },
                new Models.Pais("BÓSNIA E HERZEGÓVINA") { Codigo = 29 },
                new Models.Pais("BOTSWANA") { Codigo = 30 },
                new Models.Pais("BRASIL") { Codigo = 31 },
                new Models.Pais("BRUNEI") { Codigo = 32 },
                new Models.Pais("BULGÁRIA") { Codigo = 33 },
                new Models.Pais("BURKINA FASSO") { Codigo = 34 },
                new Models.Pais("BURUNDI") { Codigo = 35 },
                new Models.Pais("BUTÃO") { Codigo = 36 },
                new Models.Pais("CABO VERDE") { Codigo = 37 },
                new Models.Pais("CAMARÕES") { Codigo = 38 },
                new Models.Pais("CAMBOJA") { Codigo = 39 },
                new Models.Pais("CANADÁ") { Codigo = 40 },
                new Models.Pais("CATAR") { Codigo = 41 },
                new Models.Pais("CAZAQUISTÃO") { Codigo = 42 },
                new Models.Pais("CHADE") { Codigo = 43 },
                new Models.Pais("CHILE") { Codigo = 44 },
                new Models.Pais("CHINA") { Codigo = 45 },
                new Models.Pais("CHIPRE") { Codigo = 46 },
                new Models.Pais("CINGAPURA") { Codigo = 47 },
                new Models.Pais("COLÔMBIA") { Codigo = 48 },
                new Models.Pais("COMORES") { Codigo = 49 },
                new Models.Pais("CONGO") { Codigo = 50 },
                new Models.Pais("CORÉIA DO NORTE") { Codigo = 51 },
                new Models.Pais("CORÉIA DO SUL") { Codigo = 52 },
                new Models.Pais("COSTA DO MARFIM") { Codigo = 53 },
                new Models.Pais("COSTA RICA") { Codigo = 54 },
                new Models.Pais("CROÁCIA") { Codigo = 55 },
                new Models.Pais("CUBA") { Codigo = 56 },
                new Models.Pais("DINAMARCA") { Codigo = 57 },
                new Models.Pais("DJIBUTI") { Codigo = 58 },
                new Models.Pais("DOMINICA") { Codigo = 59 },
                new Models.Pais("EGITO") { Codigo = 60 },
                new Models.Pais("EL SALVADOR") { Codigo = 61 },
                new Models.Pais("EMIRADOS ÁRABES UNIDOS") { Codigo = 62 },
                new Models.Pais("EQUADOR") { Codigo = 63 },
                new Models.Pais("ERITRÉIA") { Codigo = 64 },
                new Models.Pais("ESLOVÁQUIA") { Codigo = 65 },
                new Models.Pais("ESLOVÊNIA") { Codigo = 66 },
                new Models.Pais("ESPANHA") { Codigo = 67 },
                new Models.Pais("ESTADOS UNIDOS") { Codigo = 68 },
                new Models.Pais("ESTÔNIA") { Codigo = 69 },
                new Models.Pais("ETIÓPIA") { Codigo = 70 },
                new Models.Pais("FEDERAÇÃO RUSSA") { Codigo = 71 },
                new Models.Pais("FIJI") { Codigo = 72 },
                new Models.Pais("FILIPINAS") { Codigo = 73 },
                new Models.Pais("FINLÂNDIA") { Codigo = 74 },
                new Models.Pais("FRANÇA") { Codigo = 75 },
                new Models.Pais("FRANÇA METROPOLITANA") { Codigo = 76 },
                new Models.Pais("GABÃO") { Codigo = 77 },
                new Models.Pais("GÂMBIA") { Codigo = 78 },
                new Models.Pais("GANA") { Codigo = 79 },
                new Models.Pais("GEÓRGIA") { Codigo = 80 },
                new Models.Pais("GIBRALTAR") { Codigo = 81 },
                new Models.Pais("GRÃ-BRETANHA") { Codigo = 82 },
                new Models.Pais("GRANADA") { Codigo = 83 },
                new Models.Pais("GRÉCIA") { Codigo = 84 },
                new Models.Pais("GROENLÂNDIA") { Codigo = 85 },
                new Models.Pais("GUADALUPE") { Codigo = 86 },
                new Models.Pais("GUAM") { Codigo = 87 },
                new Models.Pais("GUATEMALA") { Codigo = 88 },
                new Models.Pais("GUIANA") { Codigo = 89 },
                new Models.Pais("GUIANA FRANCESA") { Codigo = 90 },
                new Models.Pais("GUINÉ") { Codigo = 91 },
                new Models.Pais("GUINÉ EQUATORIAL") { Codigo = 92 },
                new Models.Pais("GUINÉ-BISSAU") { Codigo = 93 },
                new Models.Pais("HAITI") { Codigo = 94 },
                new Models.Pais("HOLANDA") { Codigo = 95 },
                new Models.Pais("HONDURAS") { Codigo = 96 },
                new Models.Pais("HONG KONG") { Codigo = 97 },
                new Models.Pais("HUNGRIA") { Codigo = 98 },
                new Models.Pais("IÊMEN") { Codigo = 99 },
                new Models.Pais("ILHA BOUVET") { Codigo = 100 },
                new Models.Pais("ILHA CHRISTMAS") { Codigo = 101 },
                new Models.Pais("ILHA NORFOLK") { Codigo = 102 },
                new Models.Pais("ILHAS CAYMAN") { Codigo = 103 },
                new Models.Pais("ILHAS COCOS") { Codigo = 104 },
                new Models.Pais("ILHAS COOK") { Codigo = 105 },
                new Models.Pais("ILHAS DE GUERNSEY") { Codigo = 106 },
                new Models.Pais("ILHAS DE JERSEY") { Codigo = 107 },
                new Models.Pais("ILHAS FAROE") { Codigo = 108 },
                new Models.Pais("ILHAS GEÓRGIA DO SUL E ILHAS SANDWICH DO SUL") { Codigo = 109 },
                new Models.Pais("ILHAS HEARD E MAC DONALD") { Codigo = 110 },
                new Models.Pais("ILHAS MALVINAS") { Codigo = 111 },
                new Models.Pais("ILHAS MARIANA") { Codigo = 112 },
                new Models.Pais("ILHAS MARSHALL") { Codigo = 113 },
                new Models.Pais("ILHAS PITCAIRN") { Codigo = 114 },
                new Models.Pais("ILHAS REUNIÃO") { Codigo = 115 },
                new Models.Pais("ILHAS SALOMÃO") { Codigo = 116 },
                new Models.Pais("ILHAS SANTA HELENA") { Codigo = 117 },
                new Models.Pais("ILHAS SVALBARD E JAN MAYEN") { Codigo = 118 },
                new Models.Pais("ILHAS TOKELAU") { Codigo = 119 },
                new Models.Pais("ILHAS TURKS E CAICOS") { Codigo = 120 },
                new Models.Pais("ILHAS VIRGENS") { Codigo = 121 },
                new Models.Pais("ILHAS VIRGENS BRITÂNICAS") { Codigo = 122 },
                new Models.Pais("ILHAS WALLIS E FUTUNA") { Codigo = 123 },
                new Models.Pais("ÍNDIA") { Codigo = 124 },
                new Models.Pais("INDONÉSIA") { Codigo = 125 },
                new Models.Pais("IRÃ") { Codigo = 126 },
                new Models.Pais("IRAQUE") { Codigo = 127 },
                new Models.Pais("IRLANDA") { Codigo = 128 },
                new Models.Pais("ISLÂNDIA") { Codigo = 129 },
                new Models.Pais("ISRAEL") { Codigo = 130 },
                new Models.Pais("ITÁLIA") { Codigo = 131 },
                new Models.Pais("IUGOSLÁVIA") { Codigo = 132 },
                new Models.Pais("JAMAICA") { Codigo = 133 },
                new Models.Pais("JAPÃO") { Codigo = 134 },
                new Models.Pais("JORDÂNIA") { Codigo = 135 },
                new Models.Pais("KIRIBATI") { Codigo = 136 },
                new Models.Pais("KUWEIT") { Codigo = 137 },
                new Models.Pais("LAOS") { Codigo = 138 },
                new Models.Pais("LESOTO") { Codigo = 139 },
                new Models.Pais("LETÔNIA") { Codigo = 140 },
                new Models.Pais("LÍBANO") { Codigo = 141 },
                new Models.Pais("LIBÉRIA") { Codigo = 142 },
                new Models.Pais("LÍBIA") { Codigo = 143 },
                new Models.Pais("LIECHTENSTEIN") { Codigo = 144 },
                new Models.Pais("LITUÂNIA") { Codigo = 145 },
                new Models.Pais("LUXEMBURGO") { Codigo = 146 },
                new Models.Pais("MACAU") { Codigo = 147 },
                new Models.Pais("MACEDÔNIA") { Codigo = 148 },
                new Models.Pais("MADAGASCAR") { Codigo = 149 },
                new Models.Pais("MALÁSIA") { Codigo = 150 },
                new Models.Pais("MALAUÍ") { Codigo = 151 },
                new Models.Pais("MALDIVAS") { Codigo = 152 },
                new Models.Pais("MALI") { Codigo = 153 },
                new Models.Pais("MALTA") { Codigo = 154 },
                new Models.Pais("MARROCOS") { Codigo = 155 },
                new Models.Pais("MARTINICA") { Codigo = 156 },
                new Models.Pais("MAURÍCIO") { Codigo = 157 },
                new Models.Pais("MAURITÂNIA") { Codigo = 158 },
                new Models.Pais("MAYOTTE") { Codigo = 159 },
                new Models.Pais("MÉXICO") { Codigo = 160 },
                new Models.Pais("MIANMAR") { Codigo = 161 },
                new Models.Pais("MICRONÉSIA") { Codigo = 162 },
                new Models.Pais("MOÇAMBIQUE") { Codigo = 163 },
                new Models.Pais("MOLDÁVIA") { Codigo = 164 },
                new Models.Pais("MÔNACO") { Codigo = 165 },
                new Models.Pais("MONGÓLIA") { Codigo = 166 },
                new Models.Pais("MONTSERRAT") { Codigo = 167 },
                new Models.Pais("NAMÍBIA") { Codigo = 168 },
                new Models.Pais("NAURU") { Codigo = 169 },
                new Models.Pais("NEPAL") { Codigo = 170 },
                new Models.Pais("NICARÁGUA") { Codigo = 171 },
                new Models.Pais("NIGER") { Codigo = 172 },
                new Models.Pais("NIGÉRIA") { Codigo = 173 },
                new Models.Pais("NIUE") { Codigo = 174 },
                new Models.Pais("NORUEGA") { Codigo = 175 },
                new Models.Pais("NOVA CALEDÔNIA") { Codigo = 176 },
                new Models.Pais("NOVA ZELÂNDIA") { Codigo = 177 },
                new Models.Pais("OMÃ") { Codigo = 178 },
                new Models.Pais("PALAU") { Codigo = 179 },
                new Models.Pais("PANAMÁ") { Codigo = 180 },
                new Models.Pais("PAPUA NOVA GUINÉ") { Codigo = 181 },
                new Models.Pais("PAQUISTÃO") { Codigo = 182 },
                new Models.Pais("PARAGUAI") { Codigo = 183 },
                new Models.Pais("PERU") { Codigo = 184 },
                new Models.Pais("POLINÉSIA FRANCESA") { Codigo = 185 },
                new Models.Pais("POLÔNIA") { Codigo = 186 },
                new Models.Pais("PORTO RICO") { Codigo = 187 },
                new Models.Pais("PORTUGAL") { Codigo = 188 },
                new Models.Pais("QUÊNIA") { Codigo = 189 },
                new Models.Pais("QUIRGUÍZIA") { Codigo = 190 },
                new Models.Pais("REPÚBLICA CENTRO-AFRICANA") { Codigo = 191 },
                new Models.Pais("REPÚBLICA DOMINICANA") { Codigo = 192 },
                new Models.Pais("REPÚBLICA TCHECA") { Codigo = 193 },
                new Models.Pais("ROMÊNIA") { Codigo = 194 },
                new Models.Pais("RUANDA") { Codigo = 195 },
                new Models.Pais("SAHARA OCIDENTAL") { Codigo = 196 },
                new Models.Pais("SAMOA AMERICANA") { Codigo = 197 },
                new Models.Pais("SAMOA OCIDENTAL") { Codigo = 198 },
                new Models.Pais("SAN MARINO") { Codigo = 199 },
                new Models.Pais("SANTA LÚCIA") { Codigo = 200 },
                new Models.Pais("SÃO CRISTÓVÃO E NÉVIS") { Codigo = 201 },
                new Models.Pais("SÃO PIERRE E MIQUELON") { Codigo = 202 },
                new Models.Pais("SÃO TOMÉ E PRÍNCIPE") { Codigo = 203 },
                new Models.Pais("SÃO VICENTE E GRANADINAS") { Codigo = 204 },
                new Models.Pais("SEICHELES") { Codigo = 205 },
                new Models.Pais("SENEGAL") { Codigo = 206 },
                new Models.Pais("SERRA LEOA") { Codigo = 207 },
                new Models.Pais("SÍRIA") { Codigo = 208 },
                new Models.Pais("SOMÁLIA") { Codigo = 209 },
                new Models.Pais("SRI LANKA") { Codigo = 210 },
                new Models.Pais("SUAZILÂNDIA") { Codigo = 211 },
                new Models.Pais("SUDÃO") { Codigo = 212 },
                new Models.Pais("SUÉCIA") { Codigo = 213 },
                new Models.Pais("SUÍÇA") { Codigo = 214 },
                new Models.Pais("SURINAME") { Codigo = 215 },
                new Models.Pais("TADJIQUISTÃO") { Codigo = 216 },
                new Models.Pais("TAILÂNDIA") { Codigo = 217 },
                new Models.Pais("TAIWAN") { Codigo = 218 },
                new Models.Pais("TANZÂNIA") { Codigo = 219 },
                new Models.Pais("TERRITÓRIOS FRANCESES MERIDIONAIS") { Codigo = 220 },
                new Models.Pais("TIMOR LESTE") { Codigo = 221 },
                new Models.Pais("TOGO") { Codigo = 222 },
                new Models.Pais("TONGA") { Codigo = 223 },
                new Models.Pais("TRINIDAD E TOBAGO") { Codigo = 224 },
                new Models.Pais("TUNÍSIA") { Codigo = 225 },
                new Models.Pais("TURCOMÊNIA") { Codigo = 226 },
                new Models.Pais("TURQUIA") { Codigo = 227 },
                new Models.Pais("TUVALU") { Codigo = 228 },
                new Models.Pais("UCRÂNIA") { Codigo = 229 },
                new Models.Pais("UGANDA") { Codigo = 230 },
                new Models.Pais("URUGUAI") { Codigo = 231 },
                new Models.Pais("UZBEQUISTÃO") { Codigo = 232 },
                new Models.Pais("VANUATU") { Codigo = 233 },
                new Models.Pais("VATICANO") { Codigo = 234 },
                new Models.Pais("VENEZUELA") { Codigo = 235 },
                new Models.Pais("VIETNÃ") { Codigo = 236 },
                new Models.Pais("ZÂMBIA") { Codigo = 237 },
                new Models.Pais("ZIMBÁBUE") { Codigo = 238 },
                new Models.Pais("ILHAS GUERNSEY") { Codigo = 239 },
                new Models.Pais("JERSEY") { Codigo = 240 },
                new Models.Pais("MONTENEGRO") { Codigo = 241 },
                new Models.Pais("ESTADO DA PALESTINA") { Codigo = 242 },
                new Models.Pais("SÉRVIA") { Codigo = 243 },
         });
        }
    }

    class DAORacaCor : DAOEnumerador<Models.RacaCor> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.RacaCor>() {
                new Models.RacaCor("Branca") { Codigo = 1 },
                new Models.RacaCor("Preta") { Codigo = 2 },
                new Models.RacaCor("Parda") { Codigo = 3 },
                new Models.RacaCor("Amarela") { Codigo = 4 },
                new Models.RacaCor("Indígena") { Codigo = 5 },
                new Models.RacaCor("Sem informação") { Codigo = 6 },
         });
        }
    }

    class DAOEtnia : DAOEnumerador<Models.Etnia> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Etnia>() {
                new Models.Etnia("ACONA (WAKONAS, NACONAS, JAKONA, ACORANES)") { Codigo = 1 },
                new Models.Etnia("AIKANA (AIKANA, MAS SAKA,TUBARAO)") { Codigo = 2 },
                new Models.Etnia("AJURU") { Codigo = 3 },
                new Models.Etnia("AKUNSU (AKUNT''SU)") { Codigo = 4 },
                new Models.Etnia("AMANAYE") { Codigo = 5 },
                new Models.Etnia("AMONDAWA") { Codigo = 6 },
                new Models.Etnia("ANAMBE") { Codigo = 7 },
                new Models.Etnia("APARAI (APALAI)") { Codigo = 8 },
                new Models.Etnia("APIAKA (APIACA)") { Codigo = 9 },
                new Models.Etnia("APINAYE (APINAJE/APINAIE/APINAGE)") { Codigo = 10 },
                new Models.Etnia("APURINA (APORINA, IPURINA, IPURINA, IPURINAN)") { Codigo = 11 },
                new Models.Etnia("ARANA (ARACUAI DO VALE DO JEQUITINHONHA)") { Codigo = 12 },
                new Models.Etnia("ARAPASO (ARAPACO)") { Codigo = 13 },
                new Models.Etnia("ARARA DE RONDONIA (KARO, URUCU, URUKU)") { Codigo = 14 },
                new Models.Etnia("ARARA DO ACRE (SHAWANAUA, AMAWAKA)") { Codigo = 15 },
                new Models.Etnia("ARARA DO ARIPUANA (ARARA DO BEIRADAO/ARI-PUANA)") { Codigo = 16 },
                new Models.Etnia("ARARA DO PARA (UKARAGMA, UKARAMMA)") { Codigo = 17 },
                new Models.Etnia("ARAWETE (ARAUETE)") { Codigo = 18 },
                new Models.Etnia("ARIKAPU (ARICAPU, ARIKAPO, MASUBI, MAXUBI)") { Codigo = 19 },
                new Models.Etnia("ARIKEM (ARIQUEN, ARIQUEME, ARIKEME)") { Codigo = 20 },
                new Models.Etnia("ARIKOSE (ARICOBE)") { Codigo = 21 },
                new Models.Etnia("ARUA") { Codigo = 22 },
                new Models.Etnia("ARUAK (ARAWAK)") { Codigo = 23 },
                new Models.Etnia("ASHANINKA (KAMPA)") { Codigo = 24 },
                new Models.Etnia("ASURINI DO TOCANTINS (AKUAWA/AKWAWA)") { Codigo = 25 },
                new Models.Etnia("ASURINI DO XINGU (AWAETE)") { Codigo = 26 },
                new Models.Etnia("ATIKUM (ATICUM)") { Codigo = 27 },
                new Models.Etnia("AVA - CANOEIRO") { Codigo = 28 },
                new Models.Etnia("AWETI (AUETI/AUETO)") { Codigo = 29 },
                new Models.Etnia("BAKAIRI (KURA, BACAIRI)") { Codigo = 30 },
                new Models.Etnia("BANAWA YAFI (BANAWA, BANAWA-JAFI)") { Codigo = 31 },
                new Models.Etnia("BANIWA (BANIUA, BANIVA, WALIMANAI, WAKUENAI)") { Codigo = 32 },
                new Models.Etnia("BARA (WAIPINOMAKA)") { Codigo = 33 },
                new Models.Etnia("BARASANA (HANERA)") { Codigo = 34 },
                new Models.Etnia("BARE") { Codigo = 35 },
                new Models.Etnia("BORORO (BOE)") { Codigo = 36 },
                new Models.Etnia("BOTOCUDO (GEREN)") { Codigo = 37 },
                new Models.Etnia("CANOE") { Codigo = 38 },
                new Models.Etnia("CASSUPA") { Codigo = 39 },
                new Models.Etnia("CHAMACOCO") { Codigo = 40 },
                new Models.Etnia("CHIQUITANO (XIQUITANO)") { Codigo = 41 },
                new Models.Etnia("CIKIYANA (SIKIANA)") { Codigo = 42 },
                new Models.Etnia("CINTA LARGA (MATETAMAE)") { Codigo = 43 },
                new Models.Etnia("COLUMBIARA (CORUMBIARA)") { Codigo = 44 },
                new Models.Etnia("DENI") { Codigo = 45 },
                new Models.Etnia("DESANA (DESANA, DESANO, DESSANO, WIRA, UMUKOMASA)") { Codigo = 46 },
                new Models.Etnia("DIAHUI (JAHOI, JAHUI, DIARROI)") { Codigo = 47 },
                new Models.Etnia("ENAWENE-NAWE (SALUMA)") { Codigo = 48 },
                new Models.Etnia("FULNI-O") { Codigo = 49 },
                new Models.Etnia("GALIBI (GALIBI DO OIAPOQUE, KARINHA)") { Codigo = 50 },
                new Models.Etnia("GALIBI MARWORNO (GALIBI DO UACA, ARUA)") { Codigo = 51 },
                new Models.Etnia("GAVIAO DE RONDONIA (DIGUT)") { Codigo = 52 },
                new Models.Etnia("GAVIAO KRIKATEJE") { Codigo = 53 },
                new Models.Etnia("GAVIAO PARKATEJE (PARKATEJE)") { Codigo = 54 },
                new Models.Etnia("GAVIAO PUKOBIE (PUKOBIE, PYKOPJE, GAVIAO DO MARANHAO)") { Codigo = 55 },
                new Models.Etnia("GUAJA (AWA, AVA)") { Codigo = 56 },
                new Models.Etnia("GUAJAJARA (TENETEHARA)") { Codigo = 57 },
                new Models.Etnia("GUARANI KAIOWA (PAI TAVYTERA)") { Codigo = 58 },
                new Models.Etnia("GUARANI M''BYA") { Codigo = 59 },
                new Models.Etnia("GUARANI NANDEVA (AVAKATUETE, CHIRIPA,NHANDEWA, AVA GUARANI)") { Codigo = 60 },
                new Models.Etnia("GUATO") { Codigo = 61 },
                new Models.Etnia("HIMARIMA (HIMERIMA)") { Codigo = 62 },
                new Models.Etnia("INGARIKO (INGARICO, AKAWAIO, KAPON)") { Codigo = 63 },
                new Models.Etnia("IRANXE (IRANTXE)") { Codigo = 64 },
                new Models.Etnia("ISSE") { Codigo = 65 },
                new Models.Etnia("JABOTI (JABUTI, KIPIU, YABYTI)") { Codigo = 66 },
                new Models.Etnia("JAMAMADI (YAMAMADI, DJEOROMITXI)") { Codigo = 67 },
                new Models.Etnia("JARAWARA") { Codigo = 68 },
                new Models.Etnia("JIRIPANCO (JERIPANCO, GERIPANCO)") { Codigo = 69 },
                new Models.Etnia("JUMA (YUMA)") { Codigo = 70 },
                new Models.Etnia("JURUNA") { Codigo = 71 },
                new Models.Etnia("JURUTI (YURITI)") { Codigo = 72 },
                new Models.Etnia("KAAPOR (URUBU-KAAPOR, KA''APOR, KAAPORTE)") { Codigo = 73 },
                new Models.Etnia("KADIWEU (CADUVEO, CADIUEU)") { Codigo = 74 },
                new Models.Etnia("KAIABI (CAIABI, KAYABI)") { Codigo = 75 },
                new Models.Etnia("KAIMBE (CAIMBE)") { Codigo = 76 },
                new Models.Etnia("KAINGANG (CAINGANGUE)") { Codigo = 77 },
                new Models.Etnia("KAIXANA (CAIXANA)") { Codigo = 78 },
                new Models.Etnia("KALABASSA (CALABASSA, CALABACAS)") { Codigo = 79 },
                new Models.Etnia("KALANCO") { Codigo = 80 },
                new Models.Etnia("KALAPALO (CALAPALO)") { Codigo = 81 },
                new Models.Etnia("KAMAYURA (CAMAIURA, KAMAIURA)") { Codigo = 82 },
                new Models.Etnia("KAMBA (CAMBA)") { Codigo = 83 },
                new Models.Etnia("KAMBEBA (CAMBEBA, OMAGUA)") { Codigo = 84 },
                new Models.Etnia("KAMBIWA (CAMBIUA)") { Codigo = 85 },
                new Models.Etnia("KAMBIWA PIPIPA (PIPIPA)") { Codigo = 86 },
                new Models.Etnia("KAMPE") { Codigo = 87 },
                new Models.Etnia("KANAMANTI (KANAMATI, CANAMANTI)") { Codigo = 88 },
                new Models.Etnia("KANAMARI (CANAMARI, KANAMARY, TUKUNA)") { Codigo = 89 },
                new Models.Etnia("KANELA APANIEKRA (CANELA)") { Codigo = 90 },
                new Models.Etnia("KANELA RANKOKAMEKRA (CANELA)") { Codigo = 91 },
                new Models.Etnia("KANINDE") { Codigo = 92 },
                new Models.Etnia("KANOE (CANOE)") { Codigo = 93 },
                new Models.Etnia("KANTARURE (CANTARURE)") { Codigo = 94 },
                new Models.Etnia("KAPINAWA (CAPINAUA)") { Codigo = 95 },
                new Models.Etnia("KARAJA (CARAJA)") { Codigo = 96 },
                new Models.Etnia("KARAJA/JAVAE (JAVAE)") { Codigo = 97 },
                new Models.Etnia("KARAJA/XAMBIOA (KARAJA DO NORTE)") { Codigo = 98 },
                new Models.Etnia("KARAPANA (CARAPANA, MUTEAMASA, UKOPINOPONA)") { Codigo = 99 },
                new Models.Etnia("KARAPOTO (CARAPOTO)") { Codigo = 100 },
                new Models.Etnia("KARIPUNA (CARIPUNA)") { Codigo = 101 },
                new Models.Etnia("KARIPUNA DO AMAPA (CARIPUNA)") { Codigo = 102 },
                new Models.Etnia("KARIRI (CARIRI)") { Codigo = 103 },
                new Models.Etnia("KARIRI-XOCO (CARIRI-CHOCO)") { Codigo = 104 },
                new Models.Etnia("KARITIANA (CARITIANA)") { Codigo = 105 },
                new Models.Etnia("KATAWIXI (KATAUIXI,KATAWIN, KATAWISI, CATAUICHI)") { Codigo = 106 },
                new Models.Etnia("KATUENA (CATUENA, KATWENA)") { Codigo = 107 },
                new Models.Etnia("KATUKINA (PEDA DJAPA)") { Codigo = 108 },
                new Models.Etnia("KATUKINA DO ACRE") { Codigo = 109 },
                new Models.Etnia("KAXARARI (CAXARARI)") { Codigo = 110 },
                new Models.Etnia("KAXINAWA (HUNI-KUIN, CASHINAUA, CAXINAUA)") { Codigo = 111 },
                new Models.Etnia("KAXIXO") { Codigo = 112 },
                new Models.Etnia("KAXUYANA (CAXUIANA)") { Codigo = 113 },
                new Models.Etnia("KAYAPO (CAIAPO)") { Codigo = 114 },
                new Models.Etnia("KAYAPO KARARAO (KARARAO)") { Codigo = 115 },
                new Models.Etnia("KAYAPO TXUKAHAMAE (TXUKAHAMAE)") { Codigo = 116 },
                new Models.Etnia("KAYAPO XICRIM (XIKRIN)") { Codigo = 117 },
                new Models.Etnia("KAYUISANA (CAIXANA, CAUIXANA, KAIXANA)") { Codigo = 118 },
                new Models.Etnia("KINIKINAWA (GUAN, KOINUKOEN, KINIKINAO)") { Codigo = 119 },
                new Models.Etnia("KIRIRI") { Codigo = 120 },
                new Models.Etnia("KOCAMA (COCAMA, KOKAMA)") { Codigo = 121 },
                new Models.Etnia("KOKUIREGATEJE") { Codigo = 122 },
                new Models.Etnia("KORUBO") { Codigo = 123 },
                new Models.Etnia("KRAHO (CRAO, KRAO)") { Codigo = 124 },
                new Models.Etnia("KREJE (KRENYE)") { Codigo = 125 },
                new Models.Etnia("KRENAK (BORUN, CRENAQUE)") { Codigo = 126 },
                new Models.Etnia("KRIKATI (KRINKATI)") { Codigo = 127 },
                new Models.Etnia("KUBEO (CUBEO, COBEWA, KUBEWA, PAMIWA, CUBEU)") { Codigo = 128 },
                new Models.Etnia("KUIKURO (KUIKURU, CUICURO)") { Codigo = 129 },
                new Models.Etnia("KUJUBIM (KUYUBI, CUJUBIM)") { Codigo = 130 },
                new Models.Etnia("KULINA PANO (CULINA)") { Codigo = 131 },
                new Models.Etnia("KULINA/MADIHA (CULINA, MADIJA, MADIHA)") { Codigo = 132 },
                new Models.Etnia("KURIPAKO (CURIPACO, CURRIPACO, CORIPACO, WAKUENAI)") { Codigo = 133 },
                new Models.Etnia("KURUAIA (CURUAIA)") { Codigo = 134 },
                new Models.Etnia("KWAZA (COAIA, KOAIA)") { Codigo = 135 },
                new Models.Etnia("MACHINERI (MANCHINERI, MANXINERI)") { Codigo = 136 },
                new Models.Etnia("MACURAP (MAKURAP)") { Codigo = 137 },
                new Models.Etnia("MAKU DOW (DOW)") { Codigo = 138 },
                new Models.Etnia("MAKU HUPDA (HUPDA)") { Codigo = 139 },
                new Models.Etnia("MAKU NADEB (NADEB)") { Codigo = 140 },
                new Models.Etnia("MAKU YUHUPDE (YUHUPDE)") { Codigo = 141 },
                new Models.Etnia("MAKUNA (MACUNA, YEBA-MASA)") { Codigo = 142 },
                new Models.Etnia("MAKUXI (MACUXI, MACHUSI, PEMON)") { Codigo = 143 },
                new Models.Etnia("MARIMAM (MARIMA)") { Codigo = 144 },
                new Models.Etnia("MARUBO") { Codigo = 145 },
                new Models.Etnia("MATIPU") { Codigo = 146 },
                new Models.Etnia("MATIS") { Codigo = 147 },
                new Models.Etnia("MATSE (MAYORUNA)") { Codigo = 148 },
                new Models.Etnia("MAXAKALI (MAXACALI)") { Codigo = 149 },
                new Models.Etnia("MAYA (MAYA)") { Codigo = 150 },
                new Models.Etnia("MAYTAPU") { Codigo = 151 },
                new Models.Etnia("MEHINAKO (MEINAKU, MEINACU)") { Codigo = 152 },
                new Models.Etnia("MEKEN (MEQUEM, MEKHEM, MICHENS)") { Codigo = 153 },
                new Models.Etnia("MENKY (MYKY, MUNKU, MENKI, MYNKY)") { Codigo = 154 },
                new Models.Etnia("MIRANHA (MIRANHA, MIRANA)") { Codigo = 155 },
                new Models.Etnia("MIRITI TAPUIA (MIRITI-TAPUYA, BUIA-TAPUYA)") { Codigo = 156 },
                new Models.Etnia("MUNDURUKU (MUNDURUCU)") { Codigo = 157 },
                new Models.Etnia("MURA") { Codigo = 158 },
                new Models.Etnia("NAHUKWA (NAFUQUA)") { Codigo = 159 },
                new Models.Etnia("NAMBIKWARA DO CAMPO (HALOTESU, KITHAULU, WAKALITESU, SAWENTES, MANDUKA)") { Codigo = 160 },
                new Models.Etnia("NAMBIKWARA DO NORTE (NEGAROTE ,MAMAINDE, LATUNDE, SABANE E MANDUKA, TAWANDE)") { Codigo = 161 },
                new Models.Etnia("NAMBIKWARA DO SUL (WASUSU ,HAHAINTESU, ALANTESU, WAIKISU, ALAKETESU, WASUSU, SARARE)") { Codigo = 162 },
                new Models.Etnia("NARAVUTE (NARUVOTO)") { Codigo = 163 },
                new Models.Etnia("NAWA (NAUA)") { Codigo = 164 },
                new Models.Etnia("NUKINI (NUQUINI, NUKUINI)") { Codigo = 165 },
                new Models.Etnia("OFAIE (OFAYE-XAVANTE)") { Codigo = 166 },
                new Models.Etnia("ORO WIN") { Codigo = 167 },
                new Models.Etnia("PAIAKU (JENIPAPO-KANINDE)") { Codigo = 168 },
                new Models.Etnia("PAKAA NOVA (WARI, PACAAS NOVOS)") { Codigo = 169 },
                new Models.Etnia("PALIKUR (AUKWAYENE, AUKUYENE, PALIKU''ENE)") { Codigo = 170 },
                new Models.Etnia("PANARA (KRENHAKARORE , KRENAKORE, KRENA-KARORE)") { Codigo = 171 },
                new Models.Etnia("PANKARARE (PANCARARE)") { Codigo = 172 },
                new Models.Etnia("PANKARARU (PANCARARU)") { Codigo = 173 },
                new Models.Etnia("PANKARARU KALANKO (KALANKO)") { Codigo = 174 },
                new Models.Etnia("PANKARARU KARUAZU (KARUAZU)") { Codigo = 175 },
                new Models.Etnia("PANKARU (PANCARU)") { Codigo = 176 },
                new Models.Etnia("PARAKANA (PARACANA, APITEREWA, AWAETE)") { Codigo = 177 },
                new Models.Etnia("PARECI (PARESI, HALITI)") { Codigo = 178 },
                new Models.Etnia("PARINTINTIN") { Codigo = 179 },
                new Models.Etnia("PATAMONA (KAPON)") { Codigo = 180 },
                new Models.Etnia("PATAXO") { Codigo = 181 },
                new Models.Etnia("PATAXO HA-HA-HAE") { Codigo = 182 },
                new Models.Etnia("PAUMARI (PALMARI)") { Codigo = 183 },
                new Models.Etnia("PAUMELENHO") { Codigo = 184 },
                new Models.Etnia("PIRAHA (MURA PIRAHA)") { Codigo = 185 },
                new Models.Etnia("PIRATUAPUIA (PIRATAPUYA, PIRATAPUYO, PIRA-TAPUYA, WAIKANA)") { Codigo = 186 },
                new Models.Etnia("PITAGUARI") { Codigo = 187 },
                new Models.Etnia("POTIGUARA") { Codigo = 188 },
                new Models.Etnia("POYANAWA (POIANAUA)") { Codigo = 189 },
                new Models.Etnia("RIKBAKTSA (CANOEIROS, ERIGPAKTSA)") { Codigo = 190 },
                new Models.Etnia("SAKURABIAT(MEKENS, SAKIRABIAP, SAKIRABIAR)") { Codigo = 191 },
                new Models.Etnia("SATERE-MAWE (SATERE-MAUE)") { Codigo = 192 },
                new Models.Etnia("SHANENAWA (KATUKINA)") { Codigo = 193 },
                new Models.Etnia("SIRIANO (SIRIA-MASA)") { Codigo = 194 },
                new Models.Etnia("SURIANA") { Codigo = 195 },
                new Models.Etnia("SURUI DE RONDONIA (PAITER)") { Codigo = 196 },
                new Models.Etnia("SURUI DO PARA (AIKEWARA)") { Codigo = 197 },
                new Models.Etnia("SUYA (SUIA/KISEDJE)") { Codigo = 198 },
                new Models.Etnia("TAPAYUNA (BEICO-DE-PAU)") { Codigo = 199 },
                new Models.Etnia("TAPEBA") { Codigo = 200 },
                new Models.Etnia("TAPIRAPE (TAPI''IRAPE)") { Codigo = 201 },
                new Models.Etnia("TAPUIA (TAPUIA-XAVANTE, TAPUIO)") { Codigo = 202 },
                new Models.Etnia("TARIANO (TARIANA, TALIASERI)") { Codigo = 203 },
                new Models.Etnia("TAUREPANG (TAULIPANG, PEMON, AREKUNA, PAGEYN)") { Codigo = 204 },
                new Models.Etnia("TEMBE") { Codigo = 205 },
                new Models.Etnia("TENHARIM") { Codigo = 206 },
                new Models.Etnia("TERENA") { Codigo = 207 },
                new Models.Etnia("TICUNA (TIKUNA, TUKUNA, MAGUTA)") { Codigo = 208 },
                new Models.Etnia("TINGUI BOTO") { Codigo = 209 },
                new Models.Etnia("TIRIYO EWARHUYANA (TIRIYO, TRIO, TARONA, YAWI, PIANOKOTO)") { Codigo = 210 },
                new Models.Etnia("TIRIYO KAH''YANA (TIRIYO, TRIO, TARONA, YAWI, PIANOKOTO)") { Codigo = 211 },
                new Models.Etnia("TIRIYO TSIKUYANA (TIRIYO, TRIO, TARONA, YAWI, PIANOKOTO)") { Codigo = 212 },
                new Models.Etnia("TORA") { Codigo = 213 },
                new Models.Etnia("TREMEMBE") { Codigo = 214 },
                new Models.Etnia("TRUKA") { Codigo = 215 },
                new Models.Etnia("TRUMAI") { Codigo = 216 },
                new Models.Etnia("TSOHOM DJAPA (TSUNHUM-DJAPA)") { Codigo = 217 },
                new Models.Etnia("TUKANO (TUCANO, YE''PA-MASA, DASEA)") { Codigo = 218 },
                new Models.Etnia("TUMBALALA") { Codigo = 219 },
                new Models.Etnia("TUNAYANA") { Codigo = 220 },
                new Models.Etnia("TUPARI") { Codigo = 221 },
                new Models.Etnia("TUPINAMBA") { Codigo = 222 },
                new Models.Etnia("TUPINIQUIM") { Codigo = 223 },
                new Models.Etnia("TURIWARA") { Codigo = 224 },
                new Models.Etnia("TUXA") { Codigo = 225 },
                new Models.Etnia("TUYUKA (TUIUCA, DOKAPUARA, UTAPINOMAKAPHONA)") { Codigo = 226 },
                new Models.Etnia("TXIKAO (TXICAO, IKPENG)") { Codigo = 227 },
                new Models.Etnia("UMUTINA (OMOTINA, BARBADOS)") { Codigo = 228 },
                new Models.Etnia("URU-EU-WAU-WAU (URUEU-UAU-UAU, URUPAIN, URUPA)") { Codigo = 229 },
                new Models.Etnia("WAI WAI HIXKARYANA (HIXKARYANA)") { Codigo = 230 },
                new Models.Etnia("WAI WAI KARAFAWYANA (KARAFAWYANA, KARA-PAWYANA)") { Codigo = 231 },
                new Models.Etnia("WAI WAI XEREU (XEREU)") { Codigo = 232 },
                new Models.Etnia("WAI WAI KATUENA (KATUENA)") { Codigo = 233 },
                new Models.Etnia("WAI WAI MAWAYANA (MAWAYANA)") { Codigo = 234 },
                new Models.Etnia("WAIAPI (WAYAMPI, OYAMPI, WAYAPY, )") { Codigo = 235 },
                new Models.Etnia("WAIMIRI ATROARI (KINA)") { Codigo = 236 },
                new Models.Etnia("WANANO (UANANO, WANANA)") { Codigo = 237 },
                new Models.Etnia("WAPIXANA (UAPIXANA, VAPIDIANA, WAPISIANA, WAPISHANA)") { Codigo = 238 },
                new Models.Etnia("WAREKENA (UAREQUENA, WEREKENA)") { Codigo = 239 },
                new Models.Etnia("WASSU") { Codigo = 240 },
                new Models.Etnia("WAURA (UAURA, WAUJA)") { Codigo = 241 },
                new Models.Etnia("WAYANA (WAIANA, UAIANA)") { Codigo = 242 },
                new Models.Etnia("WITOTO (UITOTO, HUITOTO)") { Codigo = 243 },
                new Models.Etnia("XAKRIABA (XACRIABA)") { Codigo = 244 },
                new Models.Etnia("XAVANTE (A''UWE, AKWE, AWEN, AKWEN)") { Codigo = 245 },
                new Models.Etnia("XERENTE (AKWE, AWEN, AKWEN)") { Codigo = 246 },
                new Models.Etnia("XETA") { Codigo = 247 },
                new Models.Etnia("XIPAIA (SHIPAYA, XIPAYA)") { Codigo = 248 },
                new Models.Etnia("XOKLENG (SHOKLENG, XOCLENG)") { Codigo = 249 },
                new Models.Etnia("XOKO (XOCO, CHOCO)") { Codigo = 250 },
                new Models.Etnia("XUKURU (XUCURU)") { Codigo = 251 },
                new Models.Etnia("XUKURU KARIRI (XUCURU-KARIRI)") { Codigo = 252 },
                new Models.Etnia("YAIPIYANA") { Codigo = 253 },
                new Models.Etnia("YAMINAWA (JAMINAWA, IAMINAWA)") { Codigo = 254 },
                new Models.Etnia("YANOMAMI NINAM (IANOMAMI, IANOAMA, XIRIANA)") { Codigo = 255 },
                new Models.Etnia("YANOMAMI SANUMA (IANOMAMI, IANOAMA, XIRIANA)") { Codigo = 256 },
                new Models.Etnia("YANOMAMI YANOMAM (IANOMAMI, IANOAMA, XIRIANA)") { Codigo = 257 },
                new Models.Etnia("YAWALAPITI (IAUALAPITI)") { Codigo = 258 },
                new Models.Etnia("YAWANAWA (IAUANAUA)") { Codigo = 259 },
                new Models.Etnia("YEKUANA (MAIONGON, YE''KUANA, YEKWANA, MAYONGONG)") { Codigo = 260 },
                new Models.Etnia("YUDJA (JURUNA, YURUNA)") { Codigo = 261 },
                new Models.Etnia("ZO''E (POTURU)") { Codigo = 262 },
                new Models.Etnia("ZORO (PAGEYN)") { Codigo = 263 },
                new Models.Etnia("ZURUAHA (SOROWAHA, SURUWAHA)") { Codigo = 264 },
         });
        }
    }

    class DAOOrientacaoSexual : DAOEnumerador<Models.OrientacaoSexual> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.OrientacaoSexual>() {
                new Models.OrientacaoSexual("Heterossexual"){ Codigo = 148 },
                new Models.OrientacaoSexual("Homossexual (gay / lésbica)"){ Codigo = 153 },
                new Models.OrientacaoSexual("Bissexual"){ Codigo = 154 },
                new Models.OrientacaoSexual("Outro"){ Codigo = 155 }
         });
        }
    }

    class DAOIdentidadeGeneroCidadao : DAOEnumerador<Models.IdentidadeGeneroCidadao> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.IdentidadeGeneroCidadao>() {
                new Models.IdentidadeGeneroCidadao("Homem transsexual"){ Codigo = 149 },
                new Models.IdentidadeGeneroCidadao("Mulher transsexual"){ Codigo = 150 },
                new Models.IdentidadeGeneroCidadao("Travesti"){ Codigo = 156 },
                new Models.IdentidadeGeneroCidadao("Outro"){ Codigo = 151 }
         });
        }
    }

    class DAOCursoMaisElevado : DAOEnumerador<Models.CursoMaisElevado> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.CursoMaisElevado>() {
                new Models.CursoMaisElevado("Creche") { Codigo = 51 },
                new Models.CursoMaisElevado("Pré-escola (exceto CA)") { Codigo = 52 },
                new Models.CursoMaisElevado("Classe de alfabetização - CA") { Codigo = 53 },
                new Models.CursoMaisElevado("Ensino fundamental 1ª a 4ª séries") { Codigo = 54 },
                new Models.CursoMaisElevado("Ensino fundamental 5ª a 8ª séries") { Codigo = 55 },
                new Models.CursoMaisElevado("Ensino fundamental completo") { Codigo = 56 },
                new Models.CursoMaisElevado("Ensino fundamental especial") { Codigo = 61 },
                new Models.CursoMaisElevado("Ensino fundamental EJA - séries iniciais (supletivo 1ª a 4ª)") { Codigo = 58 },
                new Models.CursoMaisElevado("Ensino fundamental EJA - séries finais (supletivo 5ª a 8ª)") { Codigo = 59 },
                new Models.CursoMaisElevado("Ensino médio, médio 2º ciclo (científico, técnico e etc)") { Codigo = 60 },
                new Models.CursoMaisElevado("Ensino médio especial") { Codigo = 57 },
                new Models.CursoMaisElevado("Ensino médio EJA (supletivo)") { Codigo = 62 },
                new Models.CursoMaisElevado("Superior, aperfeiçoamento, especialização, mestrado, doutorado") { Codigo = 63 },
                new Models.CursoMaisElevado("Alfabetização para adultos (Mobral, etc)") { Codigo = 64 },
                new Models.CursoMaisElevado("Nenhum") { Codigo = 65 }
         });
        }
    }

    class DAORelacaoParentesco : DAOEnumerador<Models.RelacaoParentesco> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.RelacaoParentesco>() {
                new Models.RelacaoParentesco("Cônjuge / Companheiro(a)") { Codigo = 137 },
                new Models.RelacaoParentesco("Filho(a)") { Codigo = 138 },
                new Models.RelacaoParentesco("Enteado(a)") { Codigo = 139  },
                new Models.RelacaoParentesco("Neto(a) / Bisneto(a)") { Codigo = 140 },
                new Models.RelacaoParentesco("Pai / Mãe") { Codigo = 141 },
                new Models.RelacaoParentesco("Sogro(a)") { Codigo = 142 },
                new Models.RelacaoParentesco("Irmão / Irmã") { Codigo = 143 },
                new Models.RelacaoParentesco("Genro / Nora") { Codigo = 144 },
                new Models.RelacaoParentesco("Outro parente") { Codigo = 145   },
                new Models.RelacaoParentesco("Não parente") { Codigo = 146 }
         });
        }
    }

    class DAOResponsavelCrianca : DAOEnumerador<Models.ResponsavelCrianca> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.ResponsavelCrianca>() {
                new Models.ResponsavelCrianca("Adulto responsável") { Codigo = 1 },
                new Models.ResponsavelCrianca("Outra(s) criança(s)") { Codigo = 2 },
                new Models.ResponsavelCrianca("Adolescente") { Codigo = 133 },
                new Models.ResponsavelCrianca("Sozinha") { Codigo = 3 },
                new Models.ResponsavelCrianca("Creche") { Codigo = 134 },
                new Models.ResponsavelCrianca("Outro") { Codigo = 4 }

            });
        }
    }

    class DAOSexo : DAOEnumerador<Models.Sexo> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Sexo>() {
                  new Models.Sexo("Masculino") { Codigo = 0 },
                  new Models.Sexo("Feminino") { Codigo = 1 },
                  new Models.Sexo("Ignorado") { Codigo = 4 },
            });
        }
    }

    class DAOMotivoSaida : DAOEnumerador<Models.MotivoSaida> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.MotivoSaida>() {
                new Models.MotivoSaida("Óbito") { Codigo = 135 },
                new Models.MotivoSaida("Mudança de território") { Codigo = 136 }
            });
        }
    }

    class DAONacionalidade : DAOEnumerador<Models.Nacionalidade> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Nacionalidade>() {
                new Models.Nacionalidade("Brasileira") { Codigo = 1 },
                new Models.Nacionalidade("Naturalizado") { Codigo = 2 },
                new Models.Nacionalidade("Estrangeiro") { Codigo = 3 }
            });
        }
    }

    class DAOSituacaoMercadoTrabalho : DAOEnumerador<Models.SituacaoMercadoTrabalho> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.SituacaoMercadoTrabalho>() {
                new Models.SituacaoMercadoTrabalho("Empregador") { Codigo = 66 },
                new Models.SituacaoMercadoTrabalho("Assalariado com carteira de trabalho") { Codigo = 67 },
                new Models.SituacaoMercadoTrabalho("Assalariado sem carteira de trabalho") { Codigo = 68 },
                new Models.SituacaoMercadoTrabalho("Autônomo com previdência social") { Codigo = 69 },
                new Models.SituacaoMercadoTrabalho("Autônomo sem previdência social") { Codigo = 70 },
                new Models.SituacaoMercadoTrabalho("Aposentado / Pensionista") { Codigo = 71 },
                new Models.SituacaoMercadoTrabalho("Desempregado") { Codigo = 72 },
                new Models.SituacaoMercadoTrabalho("Não trabalha") { Codigo = 73 },
                new Models.SituacaoMercadoTrabalho("Servidor público / Militar") { Codigo = 147 },
                new Models.SituacaoMercadoTrabalho("Outro") { Codigo = 74 }
            });
        }
    }

    class DAOConsideracaoPeso : DAOEnumerador<Models.ConsideracaoPeso> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.ConsideracaoPeso>() {
                new Models.ConsideracaoPeso("Abaixo do peso") { Codigo = 21 },
                new Models.ConsideracaoPeso("Peso adequado") { Codigo = 22 },
                new Models.ConsideracaoPeso("Acima do peso") { Codigo = 23 }
            });
        }
    }

    class DAODoencaCardiaca : DAOEnumerador<Models.DoencaCardiaca> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.DoencaCardiaca>() {
                new Models.DoencaCardiaca("Insuficiência cardíaca") { Codigo = 24 },
                new Models.DoencaCardiaca("Outro") { Codigo = 25 },
                new Models.DoencaCardiaca("Não sabe") { Codigo = 26 }
            });
        }
    }

    class DAOProblemaRins : DAOEnumerador<Models.ProblemaRins> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.ProblemaRins>() {
                new Models.ProblemaRins("Insuficiência renal") { Codigo = 27 },
                new Models.ProblemaRins("Outro") { Codigo = 28 },
                new Models.ProblemaRins("Não sabe") { Codigo = 29 }
            });
        }
    }

    class DAODoencaRespiratoria : DAOEnumerador<Models.DoencaRespiratoria> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.DoencaRespiratoria>() {
                new Models.DoencaRespiratoria("ASMA") { Codigo = 30 },
                new Models.DoencaRespiratoria("DPOC / Enfisema") { Codigo = 31 },
                new Models.DoencaRespiratoria("Outro") { Codigo = 32 },
                new Models.DoencaRespiratoria("Não sabe") { Codigo = 33 }
            });
        }
    }

    class DAOAcessoHigiene : DAOEnumerador<Models.AcessoHigiene>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.AcessoHigiene>() {
                new Models.AcessoHigiene("Banho") { Codigo = 42 },
                new Models.AcessoHigiene("Acesso a sanitário") { Codigo = 43 },
                new Models.AcessoHigiene("Higiene bucal") { Codigo = 44 },
                new Models.AcessoHigiene("Outros") { Codigo = 45 }
            });
        }
    }

    class DAODeficienciaCidadao : DAOEnumerador<Models.DeficienciaCidadao>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.DeficienciaCidadao>() {
                new Models.DeficienciaCidadao("Auditiva") { Codigo = 12 },
                new Models.DeficienciaCidadao("Visual") { Codigo = 13 },
                new Models.DeficienciaCidadao("Intelectual/Cognitiva") { Codigo = 14 },
                new Models.DeficienciaCidadao("Física") { Codigo = 15 },
                new Models.DeficienciaCidadao("Outra") { Codigo = 16 }
            });
        }
    }

    class DAOQuantasVezesAlimentacao : DAOEnumerador<Models.QuantasVezesAlimentacao>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.QuantasVezesAlimentacao>() {
                new Models.QuantasVezesAlimentacao("1 vez") { Codigo = 34 },
                new Models.QuantasVezesAlimentacao("2 ou 3 vezes") { Codigo = 35 },
                new Models.QuantasVezesAlimentacao("mais de 3 vezes") { Codigo = 36 },
            });
        }
    }

    class DAOTempoSituacaoDeRua : DAOEnumerador<Models.TempoSituacaoDeRua>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.TempoSituacaoDeRua>() {
                new Models.TempoSituacaoDeRua("Menos de 6 meses") { Codigo = 17 },
                new Models.TempoSituacaoDeRua("6 a 12 meses") { Codigo = 18 },
                new Models.TempoSituacaoDeRua("1 a 5 anos") { Codigo = 19 },
                new Models.TempoSituacaoDeRua("Mais de 5 anos") { Codigo = 20 },
            });
        }
    }
    
    class DAOSituacaoDeMoradia : DAOEnumerador<Models.SituacaoDeMoradia> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.SituacaoDeMoradia>() {
                  new Models.SituacaoDeMoradia("Próprio") { Codigo = 75 },
                  new Models.SituacaoDeMoradia("Financiado") { Codigo = 76 },
                  new Models.SituacaoDeMoradia("Alugado") { Codigo = 77 },
                  new Models.SituacaoDeMoradia("Arrendado") { Codigo = 78 },
                  new Models.SituacaoDeMoradia("Cedido") { Codigo = 79 },
                  new Models.SituacaoDeMoradia("Ocupação") { Codigo = 80 },
                  new Models.SituacaoDeMoradia("Situação de Rua") { Codigo = 81 },
                  new Models.SituacaoDeMoradia("Outra") { Codigo = 82 },
            });
        }
    }

    class DAOLocalizacaoDaMoradia : DAOEnumerador<Models.LocalizacaoDaMoradia> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.LocalizacaoDaMoradia>() {
                  new Models.LocalizacaoDaMoradia("Urbana") { Codigo = 83 },
                  new Models.LocalizacaoDaMoradia("Rural") { Codigo = 84 },
            });
        }
    }

    class DAOTipoDeDomicilio : DAOEnumerador<Models.TipoDeDomicilio> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.TipoDeDomicilio>() {
                  new Models.TipoDeDomicilio("Casa") { Codigo = 85 },
                  new Models.TipoDeDomicilio("Apartamento") { Codigo = 86 },
                  new Models.TipoDeDomicilio("Cômodo") { Codigo = 87 },
                  new Models.TipoDeDomicilio("Outro") { Codigo = 88 },
            });
        }
    }

    class DAOTipoDeAcessoAoDomicilio : DAOEnumerador<Models.TipoDeAcessoAoDomicilio> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.TipoDeAcessoAoDomicilio>() {
                  new Models.TipoDeAcessoAoDomicilio("Pavimento") { Codigo = 89 },
                  new Models.TipoDeAcessoAoDomicilio("Chão Batido") { Codigo = 90 },
                  new Models.TipoDeAcessoAoDomicilio("Fluvial") { Codigo = 91 },
                  new Models.TipoDeAcessoAoDomicilio("Outro") { Codigo = 92 },
            });
        }
    }

    class DAOCondicaoDePosseEUsoDaTerra : DAOEnumerador<Models.CondicaoDePosseEUsoDaTerra> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.CondicaoDePosseEUsoDaTerra>() {
                  new Models.CondicaoDePosseEUsoDaTerra("Proprietário") { Codigo = 101 },
                  new Models.CondicaoDePosseEUsoDaTerra("Parceiro(a) / Meeiro(a)") { Codigo = 102 },
                  new Models.CondicaoDePosseEUsoDaTerra("Assentado(a)") { Codigo = 103 },
                  new Models.CondicaoDePosseEUsoDaTerra("Posseiro") { Codigo = 104 },
                  new Models.CondicaoDePosseEUsoDaTerra("Arrendatário(a)") { Codigo = 105 },
                  new Models.CondicaoDePosseEUsoDaTerra("Comodatário(a)") { Codigo = 106 },
                  new Models.CondicaoDePosseEUsoDaTerra("Beneficiário(a) do banco da terra") { Codigo = 107 },
                  new Models.CondicaoDePosseEUsoDaTerra("Não se aplica") { Codigo = 108 },
            });
        }
    }

    class DAOMaterialPredominanteNaConstrucao : DAOEnumerador<Models.MaterialPredominanteNaConstrucao> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.MaterialPredominanteNaConstrucao>() {
                  new Models.MaterialPredominanteNaConstrucao("Alvenaria com revestimento") { Codigo = 109 },
                  new Models.MaterialPredominanteNaConstrucao("Alvenaria sem revestimento") { Codigo = 110 },
                  new Models.MaterialPredominanteNaConstrucao("Taipa com revestimento") { Codigo = 111 },
                  new Models.MaterialPredominanteNaConstrucao("Taipa sem revestimento") { Codigo = 112 },
                  new Models.MaterialPredominanteNaConstrucao("Madeira emparelhada") { Codigo = 113 },
                  new Models.MaterialPredominanteNaConstrucao("Material aproveitado") { Codigo = 114 },
                  new Models.MaterialPredominanteNaConstrucao("Palha") { Codigo = 115 },
                  new Models.MaterialPredominanteNaConstrucao("Outro material") { Codigo = 116 },
            });
        }
    }

    class DAOAbastecimentoDeAgua : DAOEnumerador<Models.AbastecimentoDeAgua> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.AbastecimentoDeAgua>() {
                  new Models.AbastecimentoDeAgua("Rede encanada até o domicílio") { Codigo = 117 },
                  new Models.AbastecimentoDeAgua("Poço / Nascente no domicílio") { Codigo = 118 },
                  new Models.AbastecimentoDeAgua("Cisterna") { Codigo = 119 },
                  new Models.AbastecimentoDeAgua("Carro pipa") { Codigo = 120 },
                  new Models.AbastecimentoDeAgua("Outro") { Codigo = 121 },
            });
        }
    }

    class DAOAguaConsumoDomicilio : DAOEnumerador<Models.AguaConsumoDomicilio> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.AguaConsumoDomicilio>() {
                  new Models.AguaConsumoDomicilio("Filtrada") { Codigo = 97 },
                  new Models.AguaConsumoDomicilio("Fervida") { Codigo = 98 },
                  new Models.AguaConsumoDomicilio("Clorada") { Codigo = 99 },
                  new Models.AguaConsumoDomicilio("Mineral") { Codigo = 152 },
                  new Models.AguaConsumoDomicilio("Sem Tratamento") { Codigo = 100 },
            });
        }
    }

    class DAOFormaDeEscoamentoDoBanheiroOuSanitario : DAOEnumerador<Models.FormaDeEscoamentoDoBanheiroOuSanitario> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.FormaDeEscoamentoDoBanheiroOuSanitario>() {
                  new Models.FormaDeEscoamentoDoBanheiroOuSanitario("Rede coletora de esgoto / pluvial") { Codigo = 122 },
                  new Models.FormaDeEscoamentoDoBanheiroOuSanitario("Fossa séptica") { Codigo = 123 },
                  new Models.FormaDeEscoamentoDoBanheiroOuSanitario("Fossa rudimentar") { Codigo = 124 },
                  new Models.FormaDeEscoamentoDoBanheiroOuSanitario("Direto para um rio / lago / mar") { Codigo = 125 },
                  new Models.FormaDeEscoamentoDoBanheiroOuSanitario("Céu aberto") { Codigo = 126 },
                  new Models.FormaDeEscoamentoDoBanheiroOuSanitario("Outra Forma") { Codigo = 127 },
            });
        }
    }

    class DAODestinoDoLixo : DAOEnumerador<Models.DestinoDoLixo> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.DestinoDoLixo>() {
                  new Models.DestinoDoLixo("Coletado") { Codigo = 93 },
                  new Models.DestinoDoLixo("Queimado / Enterrado") { Codigo = 94 },
                  new Models.DestinoDoLixo("Céu aberto") { Codigo = 95 },
                  new Models.DestinoDoLixo("Outro") { Codigo = 96 },
            });
        }
    }

    class DAOAnimalNoDomicilio : DAOEnumerador<Models.AnimalNoDomicilio> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.AnimalNoDomicilio>() {
                  new Models.AnimalNoDomicilio("Gato") { Codigo = 128 },
                  new Models.AnimalNoDomicilio("Cachorro") { Codigo = 129 },
                  new Models.AnimalNoDomicilio("Pássaro") { Codigo = 130 },
                  new Models.AnimalNoDomicilio("Outros") { Codigo = 132 },
            });
        }
    }

    class DAORendaFamiliar : DAOEnumerador<Models.RendaFamiliar> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.RendaFamiliar>() {
                  new Models.RendaFamiliar("1/4 de salário mínimo") { Codigo = 1 },
                  new Models.RendaFamiliar("Meio salário mínimo") { Codigo = 2 },
                  new Models.RendaFamiliar("Um salário mínimo") { Codigo = 3 },
                  new Models.RendaFamiliar("Dois salários mínimos") { Codigo = 4 },
                  new Models.RendaFamiliar("Três salários mínimos") { Codigo = 7 },
                  new Models.RendaFamiliar("Quatro salários mínimos") { Codigo = 5 },
                  new Models.RendaFamiliar("Acima de quatro salários mínimos") { Codigo = 6 },
            });
        }
    }

    class DAOTipoDeImovel : DAOEnumerador<Models.TipoDeImovel>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.TipoDeImovel>() {
                  new Models.TipoDeImovel("Domicílio") { Codigo = 1 },
                  new Models.TipoDeImovel("Comércio") { Codigo = 2 },
                  new Models.TipoDeImovel("Terreno Baldio") { Codigo = 3 },
                  new Models.TipoDeImovel("Ponto Estratégico (cemitério, borracharia, ferro-velho, depósito de sucata ou materiais de construção, garagem de ônibus ou veículo de grande porte)") { Codigo = 4 },
                  new Models.TipoDeImovel("Escola") { Codigo = 5 },
                  new Models.TipoDeImovel("Creche") { Codigo = 6 },
                  new Models.TipoDeImovel("Abrigo") { Codigo = 7 },
                  new Models.TipoDeImovel("Instituição de longa permanência para idosos") { Codigo = 8 },
                  new Models.TipoDeImovel("Unidade Prisional") { Codigo = 9 },
                  new Models.TipoDeImovel("Unidade de medida sócio educativa") { Codigo = 10 },
                  new Models.TipoDeImovel("Delegacia") { Codigo = 11 },
                  new Models.TipoDeImovel("Estabelecimento religioso") { Codigo = 12 },
                  new Models.TipoDeImovel("Outros") { Codigo = 99 },
            });
        }
    }

    //Ficha Atendimento Individual
    class DAOTurno : DAOEnumerador<Models.Turno> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Turno>() {
                  new Models.Turno("Manhã") { Codigo = 1 },
                  new Models.Turno("Tarde") { Codigo = 2 },
                  new Models.Turno("Noite") { Codigo = 3 },
            });
        }
    }

    class DAOLocalDeAtendimento : DAOEnumerador<Models.LocalDeAtendimento> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.LocalDeAtendimento>() {
                  new Models.LocalDeAtendimento("UBS") { Codigo = 1 },
                  new Models.LocalDeAtendimento("Unidade Móvel") { Codigo = 2 },
                  new Models.LocalDeAtendimento("Rua") { Codigo = 3 },
                  new Models.LocalDeAtendimento("Domicílio") { Codigo = 4 },
                  new Models.LocalDeAtendimento("Escola/Creche") { Codigo = 5 },
                  new Models.LocalDeAtendimento("Outros") { Codigo = 6 },
                  new Models.LocalDeAtendimento("Polo (Academia da Saúde)") { Codigo = 7 },
                  new Models.LocalDeAtendimento("Instituição/Abrigo") { Codigo = 8 },
                  new Models.LocalDeAtendimento("Unidade Prisional ou Congêneres") { Codigo = 9 },
                  new Models.LocalDeAtendimento("Unidade Socioeducativa") { Codigo = 10 },
            });
        }
    }

    class DAOTipoDeAtendimento : DAOEnumerador<Models.TipoDeAtendimento> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.TipoDeAtendimento>() {
                  new Models.TipoDeAtendimento("Consulta Agendada Programada/Cuidado Continuado") { Codigo = 1 },
                  new Models.TipoDeAtendimento("Consulta Agendada") { Codigo = 2 },
                  new Models.TipoDeAtendimento("Escuta Inicial/Orientação") { Codigo = 4 },
                  new Models.TipoDeAtendimento("Consulta no Dia") { Codigo = 5 },
                  new Models.TipoDeAtendimento("Atendimento de Urgência") { Codigo = 6 },
            });
        }
    }

    class DAOModalidadeAD : DAOEnumerador<Models.ModalidadeAD> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.ModalidadeAD>() {
                  new Models.ModalidadeAD("AD1") { Codigo = 1 },
                  new Models.ModalidadeAD("AD2") { Codigo = 2 },
                  new Models.ModalidadeAD("AD3") { Codigo = 3 },
                  new Models.ModalidadeAD("Inelegível") { Codigo = 4 },
            });
        }
    }

    class DAORacionalidadeSaude : DAOEnumerador<Models.RacionalidadeSaude> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.RacionalidadeSaude>() {
                  new Models.RacionalidadeSaude("Medicina Tradicional Chinesa") { Codigo = 1 },
                  new Models.RacionalidadeSaude("Antroposofia Aplicada à Saúde") { Codigo = 2 },
                  new Models.RacionalidadeSaude("Homeopatia") { Codigo = 3 },
                  new Models.RacionalidadeSaude("Fitoterapia") { Codigo = 4 },
                  new Models.RacionalidadeSaude("Ayurveda") { Codigo = 5 },
                  new Models.RacionalidadeSaude("Outra") { Codigo = 6 },
            });
        }
    }

    class DAOAleitamentoMaterno : DAOEnumerador<Models.AleitamentoMaterno> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.AleitamentoMaterno>() {
                  new Models.AleitamentoMaterno("Exclusivo") { Codigo = 1 },
                  new Models.AleitamentoMaterno("Predominante") { Codigo = 2 },
                  new Models.AleitamentoMaterno("Complementado") { Codigo = 3 },
                  new Models.AleitamentoMaterno("Inexistente") { Codigo = 4 },
            });
        }
    }

    class DAOOrigemAlimentacao : DAOEnumerador<Models.OrigemAlimentacao> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.OrigemAlimentacao>() {
                  new Models.OrigemAlimentacao("Restaurante popular") { Codigo = 37 },
                  new Models.OrigemAlimentacao("Doação grupo religioso") { Codigo = 38 },
                  new Models.OrigemAlimentacao("Doação restaurante") { Codigo = 39 },
                  new Models.OrigemAlimentacao("Doação popular") { Codigo = 40 },
                  new Models.OrigemAlimentacao("Outros") { Codigo = 41 }
            });
        }
    }

    class DAONasfs : DAOEnumerador<Models.Nasfs>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Nasfs>() {
                  new Models.Nasfs("Avaliação / Diagnóstico") { Codigo = 1 },
                  new Models.Nasfs("Procedimentos clínicos terapêuticos") { Codigo = 2 },
                  new Models.Nasfs("Prescrição terapêutica") { Codigo = 3 },
            });
        }
    }

    class DAOCondutaEncaminhamento : DAO<Models.CondutaEncaminhamento>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.CondutaEncaminhamento>() {
                  new Models.CondutaEncaminhamento("Retorno para consulta agendada") { Codigo = 1 },
                  new Models.CondutaEncaminhamento("Retorno para cuidado continuado / programado") { Codigo = 2 },
                  new Models.CondutaEncaminhamento("Agendamento para grupos") { Codigo = 12 },
                  new Models.CondutaEncaminhamento("Agendamento para NASF") { Codigo = 3 },
                  new Models.CondutaEncaminhamento("Alta do episódio") { Codigo = 9 },
                  new Models.CondutaEncaminhamento("Encaminhamento interno no dia", "#ENCAMINHAMENTO") { Codigo = 11 },
                  new Models.CondutaEncaminhamento("Encaminhamento para serviço especializado") { Codigo = 4 },
                  new Models.CondutaEncaminhamento("Encaminhamento para CAPS") { Codigo = 5 },
                  new Models.CondutaEncaminhamento("Encaminhamento para internação hospitalar") { Codigo = 6 },
                  new Models.CondutaEncaminhamento("Encaminhamento para urgência") { Codigo = 7 },
                  new Models.CondutaEncaminhamento("Encaminhamento para serviço de atenção domiciliar") { Codigo = 8 },
                  new Models.CondutaEncaminhamento("Encaminhamento intersetorial") { Codigo = 10 },
            });
        }
    }

    class DAOListaCiapCondicaoAvaliada : DAO<Models.ListaCiapCondicaoAvaliada>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.ListaCiapCondicaoAvaliada>() {
                  new Models.ListaCiapCondicaoAvaliada("Asma", "R96") { CodigoAB = "ABP009" },
                  new Models.ListaCiapCondicaoAvaliada("Dengue", "A77") { CodigoAB = "ABP019" },
                  new Models.ListaCiapCondicaoAvaliada("Desnutrição", "T91") { CodigoAB = "ABP008" },
                  new Models.ListaCiapCondicaoAvaliada("Diabetes", "T90") { CodigoAB = "ABP006" },
                  new Models.ListaCiapCondicaoAvaliada("DPOC", "R95") { CodigoAB = "ABP010" },
                  new Models.ListaCiapCondicaoAvaliada("DST", "A78") { CodigoAB = "ABP020" },
                  new Models.ListaCiapCondicaoAvaliada("Hanseníase", "A78") { CodigoAB = "ABP018" },
                  new Models.ListaCiapCondicaoAvaliada("Hipertensão Arterial", "K86") { CodigoAB = "ABP005" },
                  new Models.ListaCiapCondicaoAvaliada("Obesidade", "T82") { CodigoAB = "ABP007" },
                  new Models.ListaCiapCondicaoAvaliada("Pré-natal", "W78") { CodigoAB = "ABP001" },
                  new Models.ListaCiapCondicaoAvaliada("Puericultura", "A98") { CodigoAB = "ABP004" },
                  new Models.ListaCiapCondicaoAvaliada("Puerpério (até 42 dias)", "W18") { CodigoAB = "ABP002" },
                  new Models.ListaCiapCondicaoAvaliada("Rastreamento de Câncer de mama", "Não possui") { CodigoAB = "ABP023" },
                  new Models.ListaCiapCondicaoAvaliada("Rastreamento de Câncer do colo do útero", "Não possui") { CodigoAB = "ABP022" },
                  new Models.ListaCiapCondicaoAvaliada("Rastreamento de Risco cardiovascular", "K22") { CodigoAB = "ABP024" },
                  new Models.ListaCiapCondicaoAvaliada("Reabilitação", "A57") { CodigoAB = "ABP015" },
                  new Models.ListaCiapCondicaoAvaliada("Saúde Mental", "Não possui") { CodigoAB = "ABP014" },
                  new Models.ListaCiapCondicaoAvaliada("Saúde Sexual e Reprodutiva", "Não possui") { CodigoAB = "ABP003" },
                  new Models.ListaCiapCondicaoAvaliada("Tabagismo", "P17") { CodigoAB = "ABP011" },
                  new Models.ListaCiapCondicaoAvaliada("Tuberculose", "A70") { CodigoAB = "ABP017" },
                  new Models.ListaCiapCondicaoAvaliada("Usuário de álcool", "P16") { CodigoAB = "ABP012" },
                  new Models.ListaCiapCondicaoAvaliada("Usuário de outras drogas", "P19") { CodigoAB = "ABP013" },
            });
        }
    }

    class DAOListaExames : DAO<Models.ListaExames>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.ListaExames>() {
                  new Models.ListaExames("Colesterol total", "02.02.01.029-5") { CodigoAB = "ABEX002" },
                  new Models.ListaExames("Creatinina", "02.02.01.031-7") { CodigoAB = "ABEX003" },
                  new Models.ListaExames("EAS / EQU", "02.02.05.001-7") { CodigoAB = "ABEX027" },
                  new Models.ListaExames("Eletrocardiograma", "02.11.02.003-6") { CodigoAB = "ABEX004" },
                  new Models.ListaExames("Espirometria", "02.02.02.035-5") { CodigoAB = "ABEX030" },
                  new Models.ListaExames("Espirometria", "02.11.08.005-5") { CodigoAB = "ABEX005" },
                  new Models.ListaExames("Exame de escarro", "02.02.08.011-0") { CodigoAB = "ABEX006" },
                  new Models.ListaExames("Glicemia", "02.02.01.047-3") { CodigoAB = "ABEX026" },
                  new Models.ListaExames("HDL", "02.02.01.027-9") { CodigoAB = "ABEX007" },
                  new Models.ListaExames("Hemoglobina glicada", "02.02.01.050-3") { CodigoAB = "ABEX008" },
                  new Models.ListaExames("Hemograma", "02.02.02.038-0") { CodigoAB = "ABEX028" },
                  new Models.ListaExames("LDL", "02.02.01.028-7") { CodigoAB = "ABEX009" },
                  new Models.ListaExames("Retinografia/Fundo de olho com oftalmologista", "Não possui") { CodigoAB = "ABEX013" },
                  new Models.ListaExames("Sorologia de Sífilis (VDRL)", "02.02.03.111-0") { CodigoAB = "ABEX019" },
                  new Models.ListaExames("Sorologia para Dengue", "02.02.03.090-3") { CodigoAB = "ABEX016" },
                  new Models.ListaExames("Sorologia para HIV", "02.02.03.030-0") { CodigoAB = "ABEX018" },
                  new Models.ListaExames("Teste indireto de antiglobulina humana (TIA)", "02.02.12.009-0") { CodigoAB = "ABEX031" },
                  new Models.ListaExames("Teste da orelhinha", "02.11.07.014-9") { CodigoAB = "ABEX020" },
                  new Models.ListaExames("Teste de gravidez", "02.02.06.021-7") { CodigoAB = "ABEX023" },
                  new Models.ListaExames("Teste do olhinho", "Não possui") { CodigoAB = "ABEX022" },
                  new Models.ListaExames("Teste do pezinho", "02.02.11.005-2") { CodigoAB = "ABEX021" },
                  new Models.ListaExames("Ultrassonografia obstétrica", "02.05.02.014-3") { CodigoAB = "ABEX024" },
                  new Models.ListaExames("Urocultura", "02.02.08.008-0") { CodigoAB = "ABEX029" },
            });
        }
    }

    //Ficha Visitar Domiciliar e Territorial

    class DAOMotivoVisita : DAO<Models.MotivoVisita>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.MotivoVisita>() {
                  new Models.MotivoVisita("Cadastramento / Atualização", "#TIPO_VISITA") { Codigo = 1 },
                  new Models.MotivoVisita("Visita periódica", "#TIPO_VISITA") { Codigo = 29 },
                  new Models.MotivoVisita("Consulta", "#BUSCA_ATIVA") { Codigo = 2 },
                  new Models.MotivoVisita("Exame", "#BUSCA_ATIVA") { Codigo = 3 },
                  new Models.MotivoVisita("Vacina", "#BUSCA_ATIVA") { Codigo = 4 },
                  new Models.MotivoVisita("Condicionalidades do bolsa família", "#BUSCA_ATIVA") { Codigo = 30 },
                  new Models.MotivoVisita("Gestante", "#ACOMPANHAMENTO") { Codigo = 5 },
                  new Models.MotivoVisita("Puérpera", "#ACOMPANHAMENTO") { Codigo = 6 },
                  new Models.MotivoVisita("Recém-nascido", "#ACOMPANHAMENTO") { Codigo = 7 },
                  new Models.MotivoVisita("Criança", "#ACOMPANHAMENTO") { Codigo = 8 },
                  new Models.MotivoVisita("Pessoa com desnutrição", "#ACOMPANHAMENTO") { Codigo = 9 },
                  new Models.MotivoVisita("Pessoa em reabilitação ou com deficiência", "#ACOMPANHAMENTO") { Codigo = 10 },
                  new Models.MotivoVisita("Pessoa com hipertensão", "#ACOMPANHAMENTO") { Codigo = 11 },
                  new Models.MotivoVisita("Pessoa com diabetes", "#ACOMPANHAMENTO") { Codigo = 12 },
                  new Models.MotivoVisita("Pessoa com asma", "#ACOMPANHAMENTO") { Codigo = 13 },
                  new Models.MotivoVisita("Pessoa com DPOC / enfisema", "#ACOMPANHAMENTO") { Codigo = 14 },
                  new Models.MotivoVisita("Pessoa com câncer", "#ACOMPANHAMENTO") { Codigo = 15 },
                  new Models.MotivoVisita("Pessoa com outras doenças crônicas", "#ACOMPANHAMENTO") { Codigo = 16 },
                  new Models.MotivoVisita("Pessoa com hanseníase", "#ACOMPANHAMENTO") { Codigo = 17 },
                  new Models.MotivoVisita("Pessoa com tuberculose", "#ACOMPANHAMENTO") { Codigo = 18 },
                  new Models.MotivoVisita("Sintomáticos respiratórios", "#ACOMPANHAMENTO") { Codigo = 32 },
                  new Models.MotivoVisita("Tabagista", "#ACOMPANHAMENTO") { Codigo = 33 },
                  new Models.MotivoVisita("Domiciliados / Acamados", "#ACOMPANHAMENTO") { Codigo = 19 },
                  new Models.MotivoVisita("Condições de vulnerabilidade social", "#ACOMPANHAMENTO") { Codigo = 20 },
                  new Models.MotivoVisita("Condicionalidades do bolsa família", "#ACOMPANHAMENTO") { Codigo = 21 },
                  new Models.MotivoVisita("Saúde mental", "#ACOMPANHAMENTO") { Codigo = 22 },
                  new Models.MotivoVisita("Usuário de álcool", "#ACOMPANHAMENTO") { Codigo = 23 },
                  new Models.MotivoVisita("Usuário de outras drogas", "#ACOMPANHAMENTO") { Codigo = 24 },
                  new Models.MotivoVisita("Ação educativa", "#CONTROLE_AMBIENTAL_E_VETORIAL") { Codigo = 34 },
                  new Models.MotivoVisita("Imóvel com foco", "#CONTROLE_AMBIENTAL_E_VETORIAL") { Codigo = 35 },
                  new Models.MotivoVisita("Ação mecânica", "#CONTROLE_AMBIENTAL_E_VETORIAL") { Codigo = 36 },
                  new Models.MotivoVisita("Tratamento focal", "#CONTROLE_AMBIENTAL_E_VETORIAL") { Codigo = 37 },
                  new Models.MotivoVisita("Egresso de internação", "#OUTROS") { Codigo = 25 },
                  new Models.MotivoVisita("Convite para atividades coletivas / campanha de saúde", "#OUTROS") { Codigo = 27 },
                  new Models.MotivoVisita("Orientação / Prevenção", "#OUTROS") { Codigo = 31 },
                  new Models.MotivoVisita("Outros", "#OUTROS") { Codigo = 28 },
            });
        }
    }

    class DAODesfecho : DAOEnumerador<Models.Desfecho>
    {
        public override int? CreateTable()
        {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Desfecho>() {
                  new Models.Desfecho("Visita realizada") { Codigo = 1 },
                  new Models.Desfecho("Visita recusada") { Codigo = 2 },
                  new Models.Desfecho("Ausente") { Codigo = 3 },
            });
        }
    }

}
