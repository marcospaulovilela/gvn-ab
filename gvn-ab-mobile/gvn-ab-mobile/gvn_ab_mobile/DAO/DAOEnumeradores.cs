using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.DAO {
    class DAOPais : DAO<Models.Pais> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Pais>() {
                new Models.Pais("AFEGANISTÃO"),new Models.Pais("ÁFRICA DO SUL"),new Models.Pais("ALBÂNIA"),
                new Models.Pais("ALEMANHA"),new Models.Pais("ANDORRA"),new Models.Pais("ANGOLA"),
                new Models.Pais("ANGUILLA"),new Models.Pais("ANTÁRCTICA"),new Models.Pais("ANTIGUA E BARBUDA"),
                new Models.Pais("ANTILHAS HOLANDESAS"),new Models.Pais("ARÁBIA SAUDITA"),new Models.Pais("ARGÉLIA"),
                new Models.Pais("ARGENTINA"),new Models.Pais("ARMÊNIA"),new Models.Pais("ARUBA"),
                new Models.Pais("AUSTRÁLIA"),new Models.Pais("ÁUSTRIA"),new Models.Pais("AZERBAIDJÃO"),
                new Models.Pais("BAHAMAS"),new Models.Pais("BANGLADESH"),new Models.Pais("BARBADOS"),
                new Models.Pais("BAREIN"),new Models.Pais("BELARUS"),new Models.Pais("BÉLGICA"),
                new Models.Pais("BELIZE"),new Models.Pais("BENIN"),new Models.Pais("BERMUDA"),
                new Models.Pais("BOLÍVIA"),new Models.Pais("BÓSNIA E HERZEGÓVINA"),new Models.Pais("BOTSWANA"),
                new Models.Pais("BRASIL"),new Models.Pais("BRUNEI"),new Models.Pais("BULGÁRIA"),
                new Models.Pais("BURKINA FASSO"),new Models.Pais("BURUNDI"),new Models.Pais("BUTÃO"),
                new Models.Pais("CABO VERDE"),new Models.Pais("CAMARÕES"),new Models.Pais("CAMBOJA"),
                new Models.Pais("CANADÁ"),new Models.Pais("CATAR"),new Models.Pais("CAZAQUISTÃO"),
                new Models.Pais("CHADE"),new Models.Pais("CHILE"),new Models.Pais("CHINA"),
                new Models.Pais("CHIPRE"),new Models.Pais("CINGAPURA"),new Models.Pais("COLÔMBIA"),
                new Models.Pais("COMORES"),new Models.Pais("CONGO"),new Models.Pais("CORÉIA DO NORTE"),
                new Models.Pais("CORÉIA DO SUL"),new Models.Pais("COSTA DO MARFIM"),new Models.Pais("COSTA RICA"),
                new Models.Pais("CROÁCIA"),new Models.Pais("CUBA"),new Models.Pais("DINAMARCA"),
                new Models.Pais("DJIBUTI"),new Models.Pais("DOMINICA"),new Models.Pais("EGITO"),
                new Models.Pais("EL SALVADOR"),new Models.Pais("EMIRADOS ÁRABES UNIDOS"),new Models.Pais("EQUADOR"),
                new Models.Pais("ERITRÉIA"),new Models.Pais("ESLOVÁQUIA"),new Models.Pais("ESLOVÊNIA"),
                new Models.Pais("ESPANHA"),new Models.Pais("ESTADOS UNIDOS"),new Models.Pais("ESTÔNIA"),
                new Models.Pais("ETIÓPIA"),new Models.Pais("FEDERAÇÃO RUSSA"),new Models.Pais("FIJI"),
                new Models.Pais("FILIPINAS"),new Models.Pais("FINLÂNDIA"),new Models.Pais("FRANÇA"),
                new Models.Pais("FRANÇA METROPOLITANA"),new Models.Pais("GABÃO"),new Models.Pais("GÂMBIA"),
                new Models.Pais("GANA"),new Models.Pais("GEÓRGIA"),new Models.Pais("GIBRALTAR"),
                new Models.Pais("GRÃ-BRETANHA"),new Models.Pais("GRANADA"),new Models.Pais("GRÉCIA"),
                new Models.Pais("GROENLÂNDIA"),new Models.Pais("GUADALUPE"),new Models.Pais("GUAM"),
                new Models.Pais("GUATEMALA"),new Models.Pais("GUIANA"),new Models.Pais("GUIANA FRANCESA"),
                new Models.Pais("GUINÉ"),new Models.Pais("GUINÉ EQUATORIAL"),new Models.Pais("GUINÉ-BISSAU"),
                new Models.Pais("HAITI"),new Models.Pais("HOLANDA"),new Models.Pais("HONDURAS"),
                new Models.Pais("HONG KONG"),new Models.Pais("HUNGRIA"),new Models.Pais("IÊMEN"),
                new Models.Pais("ILHA BOUVET"),new Models.Pais("ILHA CHRISTMAS"),new Models.Pais("ILHA NORFOLK"),
                new Models.Pais("ILHAS CAYMAN"),new Models.Pais("ILHAS COCOS"),new Models.Pais("ILHAS COOK"),
                new Models.Pais("ILHAS DE GUERNSEY"),new Models.Pais("ILHAS DE JERSEY"),new Models.Pais("ILHAS FAROE"),
                new Models.Pais("ILHAS GEÓRGIA DO SUL E ILHAS SANDWICH DO SUL"),new Models.Pais("ILHAS HEARD E MAC DONALD"),new Models.Pais("ILHAS MALVINAS"),
                new Models.Pais("ILHAS MARIANA"),new Models.Pais("ILHAS MARSHALL"),new Models.Pais("ILHAS PITCAIRN"),
                new Models.Pais("ILHAS REUNIÃO"),new Models.Pais("ILHAS SALOMÃO"),new Models.Pais("ILHAS SANTA HELENA"),
                new Models.Pais("ILHAS SVALBARD E JAN MAYEN"),new Models.Pais("ILHAS TOKELAU"),new Models.Pais("ILHAS TURKS E CAICOS"),
                new Models.Pais("ILHAS VIRGENS"),new Models.Pais("ILHAS VIRGENS BRITÂNICAS"),new Models.Pais("ILHAS WALLIS E FUTUNA"),
                new Models.Pais("ÍNDIA"),new Models.Pais("INDONÉSIA"),new Models.Pais("IRÃ"),
                new Models.Pais("IRAQUE"),new Models.Pais("IRLANDA"),new Models.Pais("ISLÂNDIA"),
                new Models.Pais("ISRAEL"),new Models.Pais("ITÁLIA"),new Models.Pais("IUGOSLÁVIA"),
                new Models.Pais("JAMAICA"),new Models.Pais("JAPÃO"),new Models.Pais("JORDÂNIA"),
                new Models.Pais("KIRIBATI"),new Models.Pais("KUWEIT"),new Models.Pais("LAOS"),
                new Models.Pais("LESOTO"),new Models.Pais("LETÔNIA"),new Models.Pais("LÍBANO"),
                new Models.Pais("LIBÉRIA"),new Models.Pais("LÍBIA"),new Models.Pais("LIECHTENSTEIN"),
                new Models.Pais("LITUÂNIA"),new Models.Pais("LUXEMBURGO"),new Models.Pais("MACAU"),
                new Models.Pais("MACEDÔNIA"),new Models.Pais("MADAGASCAR"),new Models.Pais("MALÁSIA"),
                new Models.Pais("MALAUÍ"),new Models.Pais("MALDIVAS"),new Models.Pais("MALI"),
                new Models.Pais("MALTA"),new Models.Pais("MARROCOS"),new Models.Pais("MARTINICA"),
                new Models.Pais("MAURÍCIO"),new Models.Pais("MAURITÂNIA"),new Models.Pais("MAYOTTE"),
                new Models.Pais("MÉXICO"),new Models.Pais("MIANMAR"),new Models.Pais("MICRONÉSIA"),
                new Models.Pais("MOÇAMBIQUE"),new Models.Pais("MOLDÁVIA"),new Models.Pais("MÔNACO"),
                new Models.Pais("MONGÓLIA"),new Models.Pais("MONTSERRAT"),new Models.Pais("NAMÍBIA"),
                new Models.Pais("NAURU"),new Models.Pais("NEPAL"),new Models.Pais("NICARÁGUA"),
                new Models.Pais("NIGER"),new Models.Pais("NIGÉRIA"),new Models.Pais("NIUE"),
                new Models.Pais("NORUEGA"),new Models.Pais("NOVA CALEDÔNIA"),new Models.Pais("NOVA ZELÂNDIA"),
                new Models.Pais("OMÃ"),new Models.Pais("PALAU"),new Models.Pais("PANAMÁ"),
                new Models.Pais("PAPUA NOVA GUINÉ"),new Models.Pais("PAQUISTÃO"),new Models.Pais("PARAGUAI"),
                new Models.Pais("PERU"),new Models.Pais("POLINÉSIA FRANCESA"),new Models.Pais("POLÔNIA"),
                new Models.Pais("PORTO RICO"),new Models.Pais("PORTUGAL"),new Models.Pais("QUÊNIA"),
                new Models.Pais("QUIRGUÍZIA"),new Models.Pais("REPÚBLICA CENTRO-AFRICANA"),new Models.Pais("REPÚBLICA DOMINICANA"),
                new Models.Pais("REPÚBLICA TCHECA"),new Models.Pais("ROMÊNIA"),new Models.Pais("RUANDA"),
                new Models.Pais("SAHARA OCIDENTAL"),new Models.Pais("SAMOA AMERICANA"),new Models.Pais("SAMOA OCIDENTAL"),
                new Models.Pais("SAN MARINO"),new Models.Pais("SANTA LÚCIA"),new Models.Pais("SÃO CRISTÓVÃO E NÉVIS"),
                new Models.Pais("SÃO PIERRE E MIQUELON"),new Models.Pais("SÃO TOMÉ E PRÍNCIPE"),new Models.Pais("SÃO VICENTE E GRANADINAS"),
                new Models.Pais("SEICHELES"),new Models.Pais("SENEGAL"),new Models.Pais("SERRA LEOA"),
                new Models.Pais("SÍRIA"),new Models.Pais("SOMÁLIA"),new Models.Pais("SRI LANKA"),
                new Models.Pais("SUAZILÂNDIA"),new Models.Pais("SUDÃO"),new Models.Pais("SUÉCIA"),
                new Models.Pais("SUÍÇA"),new Models.Pais("SURINAME"),new Models.Pais("TADJIQUISTÃO"),
                new Models.Pais("TAILÂNDIA"),new Models.Pais("TAIWAN"),new Models.Pais("TANZÂNIA"),
                new Models.Pais("TERRITÓRIOS FRANCESES MERIDIONAIS"),new Models.Pais("TIMOR LESTE"),new Models.Pais("TOGO"),
                new Models.Pais("TONGA"),new Models.Pais("TRINIDAD E TOBAGO"),new Models.Pais("TUNÍSIA"),
                new Models.Pais("TURCOMÊNIA"),new Models.Pais("TURQUIA"),new Models.Pais("TUVALU"),
                new Models.Pais("UCRÂNIA"),new Models.Pais("UGANDA"),new Models.Pais("URUGUAI"),
                new Models.Pais("UZBEQUISTÃO"),new Models.Pais("VANUATU"),new Models.Pais("VATICANO"),
                new Models.Pais("VENEZUELA"),new Models.Pais("VIETNÃ"),new Models.Pais("ZÂMBIA"),
                new Models.Pais("ZIMBÁBUE"),new Models.Pais("ILHAS GUERNSEY"),new Models.Pais("JERSEY"),
                new Models.Pais("MONTENEGRO"),new Models.Pais("ESTADO DA PALESTINA"),new Models.Pais("SÉRVIA")
         });
        }
    }

    class DAORacaCor : DAO<Models.RacaCor> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.RacaCor>() {
                new Models.RacaCor("Branca"), new Models.RacaCor("Preta"), new Models.RacaCor("Parda"),
                new Models.RacaCor("Amarela"), new Models.RacaCor("Indígena"), new Models.RacaCor("Sem informação")
         });
        }
    }

    class DAOEtnia : DAO<Models.Etnia> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Etnia>() {
                new Models.Etnia("ACONA (WAKONAS, NACONAS, JAKONA, ACORANES)"), new Models.Etnia("AIKANA (AIKANA, MAS SAKA,TUBARAO)"), new Models.Etnia("AJURU"),
                new Models.Etnia("AKUNSU (AKUNT''SU)"), new Models.Etnia("AMANAYE"), new Models.Etnia("AMONDAWA"),
                new Models.Etnia("ANAMBE"), new Models.Etnia("APARAI (APALAI)"), new Models.Etnia("APIAKA (APIACA)"),
                new Models.Etnia("APINAYE (APINAJE/APINAIE/APINAGE)"), new Models.Etnia("APURINA (APORINA, IPURINA, IPURINA, IPURINAN)"), new Models.Etnia("ARANA (ARACUAI DO VALE DO JEQUITINHONHA)"),
                new Models.Etnia("ARAPASO (ARAPACO)"), new Models.Etnia("ARARA DE RONDONIA (KARO, URUCU, URUKU)"), new Models.Etnia("ARARA DO ACRE (SHAWANAUA, AMAWAKA)"),
                new Models.Etnia("ARARA DO ARIPUANA (ARARA DO BEIRADAO/ARI-PUANA)"), new Models.Etnia("ARARA DO PARA (UKARAGMA, UKARAMMA)"), new Models.Etnia("ARAWETE (ARAUETE)"),
                new Models.Etnia("ARIKAPU (ARICAPU, ARIKAPO, MASUBI, MAXUBI)"), new Models.Etnia("ARIKEM (ARIQUEN, ARIQUEME, ARIKEME)"), new Models.Etnia("ARIKOSE (ARICOBE)"),
                new Models.Etnia("ARUA"), new Models.Etnia("ARUAK (ARAWAK)"), new Models.Etnia("ASHANINKA (KAMPA)"),
                new Models.Etnia("ASURINI DO TOCANTINS (AKUAWA/AKWAWA)"), new Models.Etnia("ASURINI DO XINGU (AWAETE)"), new Models.Etnia("ATIKUM (ATICUM)"),
                new Models.Etnia("AVA - CANOEIRO"), new Models.Etnia("AWETI (AUETI/AUETO)"), new Models.Etnia("BAKAIRI (KURA, BACAIRI)"),
                new Models.Etnia("BANAWA YAFI (BANAWA, BANAWA-JAFI)"), new Models.Etnia("BANIWA (BANIUA, BANIVA, WALIMANAI, WAKUENAI)"), new Models.Etnia("BARA (WAIPINOMAKA)"),
                new Models.Etnia("BARASANA (HANERA)"), new Models.Etnia("BARE"), new Models.Etnia("BORORO (BOE)"),
                new Models.Etnia("BOTOCUDO (GEREN)"), new Models.Etnia("CANOE"), new Models.Etnia("CASSUPA"),
                new Models.Etnia("CHAMACOCO"), new Models.Etnia("CHIQUITANO (XIQUITANO)"), new Models.Etnia("CIKIYANA (SIKIANA)"),
                new Models.Etnia("CINTA LARGA (MATETAMAE)"), new Models.Etnia("COLUMBIARA (CORUMBIARA)"), new Models.Etnia("DENI"),
                new Models.Etnia("DESANA (DESANA, DESANO, DESSANO, WIRA, UMUKOMASA)"), new Models.Etnia("DIAHUI (JAHOI, JAHUI, DIARROI)"), new Models.Etnia("ENAWENE-NAWE (SALUMA)"),
                new Models.Etnia("FULNI-O"), new Models.Etnia("GALIBI (GALIBI DO OIAPOQUE, KARINHA)"), new Models.Etnia("GALIBI MARWORNO (GALIBI DO UACA, ARUA)"),
                new Models.Etnia("GAVIAO DE RONDONIA (DIGUT)"), new Models.Etnia("GAVIAO KRIKATEJE"), new Models.Etnia("GAVIAO PARKATEJE (PARKATEJE)"),
                new Models.Etnia("GAVIAO PUKOBIE (PUKOBIE, PYKOPJE, GAVIAO DO MARANHAO)"), new Models.Etnia("GUAJA (AWA, AVA)"), new Models.Etnia("GUAJAJARA (TENETEHARA)"),
                new Models.Etnia("GUARANI KAIOWA (PAI TAVYTERA)"), new Models.Etnia("GUARANI M''BYA"), new Models.Etnia("GUARANI NANDEVA (AVAKATUETE, CHIRIPA,NHANDEWA, AVA GUARANI)"),
                new Models.Etnia("GUATO"), new Models.Etnia("HIMARIMA (HIMERIMA)"), new Models.Etnia("INGARIKO (INGARICO, AKAWAIO, KAPON)"),
                new Models.Etnia("IRANXE (IRANTXE)"), new Models.Etnia("ISSE"), new Models.Etnia("JABOTI (JABUTI, KIPIU, YABYTI)"),
                new Models.Etnia("JAMAMADI (YAMAMADI, DJEOROMITXI)"), new Models.Etnia("JARAWARA"), new Models.Etnia("JIRIPANCO (JERIPANCO, GERIPANCO)"),
                new Models.Etnia("JUMA (YUMA)"), new Models.Etnia("JURUNA"), new Models.Etnia("JURUTI (YURITI)"),
                new Models.Etnia("KAAPOR (URUBU-KAAPOR, KA''APOR, KAAPORTE)"), new Models.Etnia("KADIWEU (CADUVEO, CADIUEU)"), new Models.Etnia("KAIABI (CAIABI, KAYABI)"),
                new Models.Etnia("KAIMBE (CAIMBE)"), new Models.Etnia("KAINGANG (CAINGANGUE)"), new Models.Etnia("KAIXANA (CAIXANA)"),
                new Models.Etnia("KALABASSA (CALABASSA, CALABACAS)"), new Models.Etnia("KALANCO"), new Models.Etnia("KALAPALO (CALAPALO)"),
                new Models.Etnia("KAMAYURA (CAMAIURA, KAMAIURA)"), new Models.Etnia("KAMBA (CAMBA)"), new Models.Etnia("KAMBEBA (CAMBEBA, OMAGUA)"),
                new Models.Etnia("KAMBIWA (CAMBIUA)"), new Models.Etnia("KAMBIWA PIPIPA (PIPIPA)"), new Models.Etnia("KAMPE"),
                new Models.Etnia("KANAMANTI (KANAMATI, CANAMANTI)"), new Models.Etnia("KANAMARI (CANAMARI, KANAMARY, TUKUNA)"), new Models.Etnia("KANELA APANIEKRA (CANELA)"),
                new Models.Etnia("KANELA RANKOKAMEKRA (CANELA)"), new Models.Etnia("KANINDE"), new Models.Etnia("KANOE (CANOE)"),
                new Models.Etnia("KANTARURE (CANTARURE)"), new Models.Etnia("KAPINAWA (CAPINAUA)"), new Models.Etnia("KARAJA (CARAJA)"),
                new Models.Etnia("KARAJA/JAVAE (JAVAE)"), new Models.Etnia("KARAJA/XAMBIOA (KARAJA DO NORTE)"), new Models.Etnia("KARAPANA (CARAPANA, MUTEAMASA, UKOPINOPONA)"),
                new Models.Etnia("KARAPOTO (CARAPOTO)"), new Models.Etnia("KARIPUNA (CARIPUNA)"), new Models.Etnia("KARIPUNA DO AMAPA (CARIPUNA)"),
                new Models.Etnia("KARIRI (CARIRI)"), new Models.Etnia("KARIRI-XOCO (CARIRI-CHOCO)"), new Models.Etnia("KARITIANA (CARITIANA)"),
                new Models.Etnia("KATAWIXI (KATAUIXI,KATAWIN, KATAWISI, CATAUICHI)"), new Models.Etnia("KATUENA (CATUENA, KATWENA)"), new Models.Etnia("KATUKINA (PEDA DJAPA)"),
                new Models.Etnia("KATUKINA DO ACRE"), new Models.Etnia("KAXARARI (CAXARARI)"), new Models.Etnia("KAXINAWA (HUNI-KUIN, CASHINAUA, CAXINAUA)"),
                new Models.Etnia("KAXIXO"), new Models.Etnia("KAXUYANA (CAXUIANA)"), new Models.Etnia("KAYAPO (CAIAPO)"),
                new Models.Etnia("KAYAPO KARARAO (KARARAO)"), new Models.Etnia("KAYAPO TXUKAHAMAE (TXUKAHAMAE)"), new Models.Etnia("KAYAPO XICRIM (XIKRIN)"),
                new Models.Etnia("KAYUISANA (CAIXANA, CAUIXANA, KAIXANA)"), new Models.Etnia("KINIKINAWA (GUAN, KOINUKOEN, KINIKINAO)"), new Models.Etnia("KIRIRI"),
                new Models.Etnia("KOCAMA (COCAMA, KOKAMA)"), new Models.Etnia("KOKUIREGATEJE"), new Models.Etnia("KORUBO"),
                new Models.Etnia("KRAHO (CRAO, KRAO)"), new Models.Etnia("KREJE (KRENYE)"), new Models.Etnia("KRENAK (BORUN, CRENAQUE)"),
                new Models.Etnia("KRIKATI (KRINKATI)"), new Models.Etnia("KUBEO (CUBEO, COBEWA, KUBEWA, PAMIWA, CUBEU)"), new Models.Etnia("KUIKURO (KUIKURU, CUICURO)"),
                new Models.Etnia("KUJUBIM (KUYUBI, CUJUBIM)"), new Models.Etnia("KULINA PANO (CULINA)"), new Models.Etnia("KULINA/MADIHA (CULINA, MADIJA, MADIHA)"),
                new Models.Etnia("KURIPAKO (CURIPACO, CURRIPACO, CORIPACO, WAKUENAI)"), new Models.Etnia("KURUAIA (CURUAIA)"), new Models.Etnia("KWAZA (COAIA, KOAIA)"),
                new Models.Etnia("MACHINERI (MANCHINERI, MANXINERI)"), new Models.Etnia("MACURAP (MAKURAP)"), new Models.Etnia("MAKU DOW (DOW)"),
                new Models.Etnia("MAKU HUPDA (HUPDA)"), new Models.Etnia("MAKU NADEB (NADEB)"), new Models.Etnia("MAKU YUHUPDE (YUHUPDE)"),
                new Models.Etnia("MAKUNA (MACUNA, YEBA-MASA)"), new Models.Etnia("MAKUXI (MACUXI, MACHUSI, PEMON)"), new Models.Etnia("MARIMAM (MARIMA)"),
                new Models.Etnia("MARUBO"), new Models.Etnia("MATIPU"), new Models.Etnia("MATIS"),
                new Models.Etnia("MATSE (MAYORUNA)"), new Models.Etnia("MAXAKALI (MAXACALI)"), new Models.Etnia("MAYA (MAYA)"),
                new Models.Etnia("MAYTAPU"), new Models.Etnia("MEHINAKO (MEINAKU, MEINACU)"), new Models.Etnia("MEKEN (MEQUEM, MEKHEM, MICHENS)"),
                new Models.Etnia("MENKY (MYKY, MUNKU, MENKI, MYNKY)"), new Models.Etnia("MIRANHA (MIRANHA, MIRANA)"), new Models.Etnia("MIRITI TAPUIA (MIRITI-TAPUYA, BUIA-TAPUYA)"),
                new Models.Etnia("MUNDURUKU (MUNDURUCU)"), new Models.Etnia("MURA"), new Models.Etnia("NAHUKWA (NAFUQUA)"),
                new Models.Etnia("NAMBIKWARA DO CAMPO (HALOTESU, KITHAULU, WAKALITESU, SAWENTES, MANDUKA)"), new Models.Etnia("NAMBIKWARA DO NORTE (NEGAROTE ,MAMAINDE, LATUNDE, SABANE E MANDUKA, TAWANDE)"), new Models.Etnia("NAMBIKWARA DO SUL (WASUSU ,HAHAINTESU, ALANTESU, WAIKISU, ALAKETESU, WASUSU, SARARE)"),
                new Models.Etnia("NARAVUTE (NARUVOTO)"), new Models.Etnia("NAWA (NAUA)"), new Models.Etnia("NUKINI (NUQUINI, NUKUINI)"),
                new Models.Etnia("OFAIE (OFAYE-XAVANTE)"), new Models.Etnia("ORO WIN"), new Models.Etnia("PAIAKU (JENIPAPO-KANINDE)"),
                new Models.Etnia("PAKAA NOVA (WARI, PACAAS NOVOS)"), new Models.Etnia("PALIKUR (AUKWAYENE, AUKUYENE, PALIKU''ENE)"), new Models.Etnia("PANARA (KRENHAKARORE , KRENAKORE, KRENA-KARORE)"),
                new Models.Etnia("PANKARARE (PANCARARE)"), new Models.Etnia("PANKARARU (PANCARARU)"), new Models.Etnia("PANKARARU KALANKO (KALANKO)"),
                new Models.Etnia("PANKARARU KARUAZU (KARUAZU)"), new Models.Etnia("PANKARU (PANCARU)"), new Models.Etnia("PARAKANA (PARACANA, APITEREWA, AWAETE)"),
                new Models.Etnia("PARECI (PARESI, HALITI)"), new Models.Etnia("PARINTINTIN"), new Models.Etnia("PATAMONA (KAPON)"),
                new Models.Etnia("PATAXO"), new Models.Etnia("PATAXO HA-HA-HAE"), new Models.Etnia("PAUMARI (PALMARI)"),
                new Models.Etnia("PAUMELENHO"), new Models.Etnia("PIRAHA (MURA PIRAHA)"), new Models.Etnia("PIRATUAPUIA (PIRATAPUYA, PIRATAPUYO, PIRA-TAPUYA, WAIKANA)"),
                new Models.Etnia("PITAGUARI"), new Models.Etnia("POTIGUARA"), new Models.Etnia("POYANAWA (POIANAUA)"),
                new Models.Etnia("RIKBAKTSA (CANOEIROS, ERIGPAKTSA)"), new Models.Etnia("SAKURABIAT(MEKENS, SAKIRABIAP, SAKIRABIAR)"), new Models.Etnia("SATERE-MAWE (SATERE-MAUE)"),
                new Models.Etnia("SHANENAWA (KATUKINA)"), new Models.Etnia("SIRIANO (SIRIA-MASA)"), new Models.Etnia("SURIANA"),
                new Models.Etnia("SURUI DE RONDONIA (PAITER)"), new Models.Etnia("SURUI DO PARA (AIKEWARA)"), new Models.Etnia("SUYA (SUIA/KISEDJE)"),
                new Models.Etnia("TAPAYUNA (BEICO-DE-PAU)"), new Models.Etnia("TAPEBA"), new Models.Etnia("TAPIRAPE (TAPI''IRAPE)"),
                new Models.Etnia("TAPUIA (TAPUIA-XAVANTE, TAPUIO)"), new Models.Etnia("TARIANO (TARIANA, TALIASERI)"), new Models.Etnia("TAUREPANG (TAULIPANG, PEMON, AREKUNA, PAGEYN)"),
                new Models.Etnia("TEMBE"), new Models.Etnia("TENHARIM"), new Models.Etnia("TERENA"),
                new Models.Etnia("TICUNA (TIKUNA, TUKUNA, MAGUTA)"), new Models.Etnia("TINGUI BOTO"), new Models.Etnia("TIRIYO EWARHUYANA (TIRIYO, TRIO, TARONA, YAWI, PIANOKOTO)"),
                new Models.Etnia("TIRIYO KAH''YANA (TIRIYO, TRIO, TARONA, YAWI, PIANOKOTO)"), new Models.Etnia("TIRIYO TSIKUYANA (TIRIYO, TRIO, TARONA, YAWI, PIANOKOTO)"), new Models.Etnia("TORA"),
                new Models.Etnia("TREMEMBE"), new Models.Etnia("TRUKA"), new Models.Etnia("TRUMAI"),
                new Models.Etnia("TSOHOM DJAPA (TSUNHUM-DJAPA)"), new Models.Etnia("TUKANO (TUCANO, YE''PA-MASA, DASEA)"), new Models.Etnia("TUMBALALA"),
                new Models.Etnia("TUNAYANA"), new Models.Etnia("TUPARI"), new Models.Etnia("TUPINAMBA"),
                new Models.Etnia("TUPINIQUIM"), new Models.Etnia("TURIWARA"), new Models.Etnia("TUXA"),
                new Models.Etnia("TUYUKA (TUIUCA, DOKAPUARA, UTAPINOMAKAPHONA)"), new Models.Etnia("TXIKAO (TXICAO, IKPENG)"), new Models.Etnia("UMUTINA (OMOTINA, BARBADOS)"),
                new Models.Etnia("URU-EU-WAU-WAU (URUEU-UAU-UAU, URUPAIN, URUPA)"), new Models.Etnia("WAI WAI HIXKARYANA (HIXKARYANA)"), new Models.Etnia("WAI WAI KARAFAWYANA (KARAFAWYANA, KARA-PAWYANA)"),
                new Models.Etnia("WAI WAI XEREU (XEREU)"), new Models.Etnia("WAI WAI KATUENA (KATUENA)"), new Models.Etnia("WAI WAI MAWAYANA (MAWAYANA)"),
                new Models.Etnia("WAIAPI (WAYAMPI, OYAMPI, WAYAPY, )"), new Models.Etnia("WAIMIRI ATROARI (KINA)"), new Models.Etnia("WANANO (UANANO, WANANA)"),
                new Models.Etnia("WAPIXANA (UAPIXANA, VAPIDIANA, WAPISIANA, WAPISHANA)"), new Models.Etnia("WAREKENA (UAREQUENA, WEREKENA)"), new Models.Etnia("WASSU"),
                new Models.Etnia("WAURA (UAURA, WAUJA)"), new Models.Etnia("WAYANA (WAIANA, UAIANA)"), new Models.Etnia("WITOTO (UITOTO, HUITOTO)"),
                new Models.Etnia("XAKRIABA (XACRIABA)"), new Models.Etnia("XAVANTE (A''UWE, AKWE, AWEN, AKWEN)"), new Models.Etnia("XERENTE (AKWE, AWEN, AKWEN)"),
                new Models.Etnia("XETA"), new Models.Etnia("XIPAIA (SHIPAYA, XIPAYA)"), new Models.Etnia("XOKLENG (SHOKLENG, XOCLENG)"),
                new Models.Etnia("XOKO (XOCO, CHOCO)"), new Models.Etnia("XUKURU (XUCURU)"), new Models.Etnia("XUKURU KARIRI (XUCURU-KARIRI)"),
                new Models.Etnia("YAIPIYANA"), new Models.Etnia("YAMINAWA (JAMINAWA, IAMINAWA)"), new Models.Etnia("YANOMAMI NINAM (IANOMAMI, IANOAMA, XIRIANA)"),
                new Models.Etnia("YANOMAMI SANUMA (IANOMAMI, IANOAMA, XIRIANA)"), new Models.Etnia("YANOMAMI YANOMAM (IANOMAMI, IANOAMA, XIRIANA)"), new Models.Etnia("YAWALAPITI (IAUALAPITI)"),
                new Models.Etnia("YAWANAWA (IAUANAUA)"), new Models.Etnia("YEKUANA (MAIONGON, YE''KUANA, YEKWANA, MAYONGONG)"), new Models.Etnia("YUDJA (JURUNA, YURUNA)"),
                new Models.Etnia("ZO''E (POTURU)"), new Models.Etnia("ZORO (PAGEYN)"), new Models.Etnia("ZURUAHA (SOROWAHA, SURUWAHA)")
         });
        }
    }

    class DAOOrientacaoSexual : DAO<Models.OrientacaoSexual> {
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

    class DAOIdentidadeGenero : DAO<Models.IdentidadeGenero> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.IdentidadeGenero>() {
                new Models.IdentidadeGenero("Homem transsexual"){ Codigo = 149 },
                new Models.IdentidadeGenero("Mulher transsexual"){ Codigo = 150 },
                new Models.IdentidadeGenero("Travesti"){ Codigo = 156 },
                new Models.IdentidadeGenero("Outro"){ Codigo = 151 }
         });
        }
    }

    class DAOCurso : DAO<Models.Curso> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Curso>() {
                new Models.Curso("Creche") { Codigo = 51 },
                new Models.Curso("Pré-escola (exceto CA)") { Codigo = 52 },
                new Models.Curso("Classe de alfabetização - CA") { Codigo = 53 },
                new Models.Curso("Ensino fundamental 1ª a 4ª séries") { Codigo = 54 },
                new Models.Curso("Ensino fundamental 5ª a 8ª séries") { Codigo = 55 },
                new Models.Curso("Ensino fundamental completo") { Codigo = 56 },
                new Models.Curso("Ensino fundamental especial") { Codigo = 61 },
                new Models.Curso("Ensino fundamental EJA - séries iniciais (supletivo 1ª a 4ª)") { Codigo = 58 },
                new Models.Curso("Ensino fundamental EJA - séries finais (supletivo 5ª a 8ª)") { Codigo = 59 },
                new Models.Curso("Ensino médio, médio 2º ciclo (científico, técnico e etc)") { Codigo = 60 },
                new Models.Curso("Ensino médio especial") { Codigo = 57 },
                new Models.Curso("Ensino médio EJA (supletivo)") { Codigo = 62 },
                new Models.Curso("Superior, aperfeiçoamento, especialização, mestrado, doutorado") { Codigo = 63 },
                new Models.Curso("Alfabetização para adultos (Mobral, etc)") { Codigo = 64 },
                new Models.Curso("Nenhum") { Codigo = 65 }
         });
        }
    }

    class DAORelacaoParentesco : DAO<Models.RelacaoParentesco> {
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

    class DAOResponsavel : DAO<Models.Responsavel> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Responsavel>() {
                new Models.Responsavel("Adulto responsável") { Codigo = 1 },
                new Models.Responsavel("Outra(s) criança(s)") { Codigo = 2 },
                new Models.Responsavel("Adolescente") { Codigo = 133 },
                new Models.Responsavel("Sozinha") { Codigo = 3 },
                new Models.Responsavel("Creche") { Codigo = 134 },
                new Models.Responsavel("Outro") { Codigo = 4 }

            });
        }
    }

    class DAOSexo : DAO<Models.Sexo> {
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

    class DAOMotivoSaida : DAO<Models.MotivoSaida> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.MotivoSaida>() {
                new Models.MotivoSaida("Óbito") { Codigo = 135 },
                new Models.MotivoSaida("Mudança de território") { Codigo = 136 }
            });
        }
    }

    class DAONacionalidade : DAO<Models.Nacionalidade> {
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

    class DAOSituacaoMercado : DAO<Models.SituacaoMercado> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.SituacaoMercado>() {
                new Models.SituacaoMercado("Empregador") { Codigo = 66 },
                new Models.SituacaoMercado("Assalariado com carteira de trabalho") { Codigo = 67 },
                new Models.SituacaoMercado("Assalariado sem carteira de trabalho") { Codigo = 68 },
                new Models.SituacaoMercado("Autônomo com previdência social") { Codigo = 69 },
                new Models.SituacaoMercado("Autônomo sem previdência social") { Codigo = 70 },
                new Models.SituacaoMercado("Aposentado / Pensionista") { Codigo = 71 },
                new Models.SituacaoMercado("Desempregado") { Codigo = 72 },
                new Models.SituacaoMercado("Não trabalha") { Codigo = 73 },
                new Models.SituacaoMercado("Servidor público / Militar") { Codigo = 147 },
                new Models.SituacaoMercado("Outro") { Codigo = 74 }
            });
        }
    }

    class DAOConsideracaoPeso : DAO<Models.ConsideracaoPeso> {
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

    class DAODoencaCardiaca : DAO<Models.DoencaCardiaca> {
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

    class DAOProblemaRins : DAO<Models.ProblemaRins> {
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

    class DAODoencaRespiratoria : DAO<Models.DoencaRespiratoria> {
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

    //Ficha Cadastro Domiciliar e Territorial

    class DAOSituacaoMoradiaPosseTerra : DAO<Models.SituacaoMoradiaPosseTerra> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.SituacaoMoradiaPosseTerra>() {
                  new Models.SituacaoMoradiaPosseTerra("Próprio") { Codigo = 75 },
                  new Models.SituacaoMoradiaPosseTerra("Financiado") { Codigo = 76 },
                  new Models.SituacaoMoradiaPosseTerra("Alugado") { Codigo = 77 },
                  new Models.SituacaoMoradiaPosseTerra("Arrendado") { Codigo = 78 },
                  new Models.SituacaoMoradiaPosseTerra("Cedido") { Codigo = 79 },
                  new Models.SituacaoMoradiaPosseTerra("Ocupação") { Codigo = 80 },
                  new Models.SituacaoMoradiaPosseTerra("Situação de Rua") { Codigo = 81 },
                  new Models.SituacaoMoradiaPosseTerra("Outra") { Codigo = 82 },
            });
        }
    }

    class DAOLocalizacao : DAO<Models.Localizacao> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.Localizacao>() {
                  new Models.Localizacao("Urbana") { Codigo = 83 },
                  new Models.Localizacao("Rural") { Codigo = 84 },
            });
        }
    }

    class DAOTipoDeDomicilio : DAO<Models.TipoDomicilio> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.TipoDomicilio>() {
                  new Models.TipoDomicilio("Casa") { Codigo = 85 },
                  new Models.TipoDomicilio("Apartamento") { Codigo = 86 },
                  new Models.TipoDomicilio("Cômodo") { Codigo = 87 },
                  new Models.TipoDomicilio("Outro") { Codigo = 88 },
            });
        }
    }

    class DAOTipoAcessoDomicilio : DAO<Models.TipoAcessoDomicilio> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.TipoAcessoDomicilio>() {
                  new Models.TipoAcessoDomicilio("Pavimento") { Codigo = 89 },
                  new Models.TipoAcessoDomicilio("Chão Batido") { Codigo = 90 },
                  new Models.TipoAcessoDomicilio("Fluvial") { Codigo = 91 },
                  new Models.TipoAcessoDomicilio("Outro") { Codigo = 92 },
            });
        }
    }

    class DAOTipoDeAcessoAoDomicilio : DAO<Models.TipoAcessoDomicilio> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.TipoAcessoDomicilio>() {
                  new Models.TipoAcessoDomicilio("Pavimento") { Codigo = 89 },
                  new Models.TipoAcessoDomicilio("Chão Batido") { Codigo = 90 },
                  new Models.TipoAcessoDomicilio("Fluvial") { Codigo = 91 },
                  new Models.TipoAcessoDomicilio("Outro") { Codigo = 92 },
            });
        }
    }

    class DAOCondicaoDePosseEUsoDaTerra : DAO<Models.CondicaoPosseUsoTerra> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.CondicaoPosseUsoTerra>() {
                  new Models.CondicaoPosseUsoTerra("Proprietário") { Codigo = 101 },
                  new Models.CondicaoPosseUsoTerra("Parceiro(a) / Meeiro(a)") { Codigo = 102 },
                  new Models.CondicaoPosseUsoTerra("Assentado(a)") { Codigo = 103 },
                  new Models.CondicaoPosseUsoTerra("Posseiro") { Codigo = 104 },
                  new Models.CondicaoPosseUsoTerra("Arrendatário(a)") { Codigo = 105 },
                  new Models.CondicaoPosseUsoTerra("Comodatário(a)") { Codigo = 106 },
                  new Models.CondicaoPosseUsoTerra("Beneficiário(a) do banco da terra") { Codigo = 107 },
                  new Models.CondicaoPosseUsoTerra("Não se aplica") { Codigo = 108 },
            });
        }
    }

    class DAOMaterialPredominanteNaConstrucao : DAO<Models.MaterialPredominanteConstrucaoParedesExternasDomicilio> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.MaterialPredominanteConstrucaoParedesExternasDomicilio>() {
                  new Models.MaterialPredominanteConstrucaoParedesExternasDomicilio("Alvenaria com revestimento") { Codigo = 109 },
                  new Models.MaterialPredominanteConstrucaoParedesExternasDomicilio("Alvenaria sem revestimento") { Codigo = 110 },
                  new Models.MaterialPredominanteConstrucaoParedesExternasDomicilio("Taipa com revestimento") { Codigo = 111 },
                  new Models.MaterialPredominanteConstrucaoParedesExternasDomicilio("Taipa sem revestimento") { Codigo = 112 },
                  new Models.MaterialPredominanteConstrucaoParedesExternasDomicilio("Madeira emparelhada") { Codigo = 113 },
                  new Models.MaterialPredominanteConstrucaoParedesExternasDomicilio("Material aproveitado") { Codigo = 114 },
                  new Models.MaterialPredominanteConstrucaoParedesExternasDomicilio("Palha") { Codigo = 115 },
                  new Models.MaterialPredominanteConstrucaoParedesExternasDomicilio("Outro material") { Codigo = 116 },
            });
        }
    }

    class DAOAbastecimentoDeAgua : DAO<Models.AbastecimentoAgua> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.AbastecimentoAgua>() {
                  new Models.AbastecimentoAgua("Rede encanada até o domicílio") { Codigo = 117 },
                  new Models.AbastecimentoAgua("Poço / Nascente no domicílio") { Codigo = 118 },
                  new Models.AbastecimentoAgua("Cisterna") { Codigo = 119 },
                  new Models.AbastecimentoAgua("Carro pipa") { Codigo = 120 },
                  new Models.AbastecimentoAgua("Outro") { Codigo = 121 },
            });
        }
    }

    class DAOAguaConsumoDomicilio : DAO<Models.AguaConsumoDomicilio> {
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

    class DAOFormaDeEscoamentoDoBanheiroOuSanitario : DAO<Models.FormaEscoamentoBanheiroOuSanitario> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.FormaEscoamentoBanheiroOuSanitario>() {
                  new Models.FormaEscoamentoBanheiroOuSanitario("Rede coletora de esgoto / pluvial") { Codigo = 122 },
                  new Models.FormaEscoamentoBanheiroOuSanitario("Fossa séptica") { Codigo = 123 },
                  new Models.FormaEscoamentoBanheiroOuSanitario("Fossa rudimentar") { Codigo = 124 },
                  new Models.FormaEscoamentoBanheiroOuSanitario("Direto para um rio / lago / mar") { Codigo = 125 },
                  new Models.FormaEscoamentoBanheiroOuSanitario("Céu aberto") { Codigo = 126 },
                  new Models.FormaEscoamentoBanheiroOuSanitario("Outra Forma") { Codigo = 127 },
            });
        }
    }

    class DAODestinoDoLixo : DAO<Models.DestinoLixo> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.DestinoLixo>() {
                  new Models.DestinoLixo("Coletado") { Codigo = 93 },
                  new Models.DestinoLixo("Queimado / Enterrado") { Codigo = 94 },
                  new Models.DestinoLixo("Céu aberto") { Codigo = 95 },
                  new Models.DestinoLixo("Outro") { Codigo = 96 },
            });
        }
    }

    class DAOAnimalNoDomicilio : DAO<Models.AnimaisDomicilio> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.AnimaisDomicilio>() {
                  new Models.AnimaisDomicilio("Gato") { Codigo = 128 },
                  new Models.AnimaisDomicilio("Cachorro") { Codigo = 129 },
                  new Models.AnimaisDomicilio("Pássaro") { Codigo = 130 },
                  new Models.AnimaisDomicilio("Outros") { Codigo = 132 },
            });
        }
    }

    class DAORendaFamiliar : DAO<Models.RendaFamiliar> {
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

    //Ficha Atendimento Individual
    class DAOTurno : DAO<Models.Turno> {
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

    class DAOLocalAtendimento : DAO<Models.LocalDeAtendimento> {
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

    class DAOTipoAtendimento : DAO<Models.TipoDeAtendimento> {
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

    class DAOAtencaoDomiciliar : DAO<Models.AtencaoDomiciliar> {
        public override int? CreateTable() {
            if (base.TableExists()) return 0;

            base.CreateTable();
            return base.Insert(new List<Models.AtencaoDomiciliar>() {
                  new Models.AtencaoDomiciliar("AD1") { Codigo = 1 },
                  new Models.AtencaoDomiciliar("AD2") { Codigo = 2 },
                  new Models.AtencaoDomiciliar("AD3") { Codigo = 3 },
                  new Models.AtencaoDomiciliar("Inelegível") { Codigo = 4 },
            });
        }
    }

    class DAORacionalidadeSaude : DAO<Models.RacionalidadeSaude> {
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

    class DAOAleitamentoMaterno : DAO<Models.AleitamentoMaterno> {
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

}
