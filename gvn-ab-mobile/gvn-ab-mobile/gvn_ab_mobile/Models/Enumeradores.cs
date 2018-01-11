using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Models {

    //Ficha Cadastro Individual
    public class Pais : Models.EntidadeEnumerador {
        public Pais() { }
        public Pais(string descricao) : base(descricao) { }
    }

    public class RacaCor : Models.EntidadeEnumerador {
        public RacaCor() { }
        public RacaCor(string descricao) : base(descricao) { }
    }

    public class Etnia : Models.EntidadeEnumerador {
        public Etnia() { }
        public Etnia(string descricao) : base(descricao) { }
    }

    public class OrientacaoSexual : Models.EntidadeEnumerador {
        public OrientacaoSexual() { }
        public OrientacaoSexual(string descricao) : base(descricao) { }
    }

    public class Curso : Models.EntidadeEnumerador {
        public Curso() { }
        public Curso(string descricao) : base(descricao) { }
    }

    public class RelacaoParentesco : Models.EntidadeEnumerador {
        public RelacaoParentesco() { }
        public RelacaoParentesco(string descricao) : base(descricao) { }
    }

    public class Responsavel : Models.EntidadeEnumerador {
        public Responsavel() { }
        public Responsavel(string descricao) : base(descricao) { }
    }

    public class Sexo : Models.EntidadeEnumerador {
        public Sexo() { }
        public Sexo(string descricao) : base(descricao) { }
    }

    public class MotivoSaida : Models.EntidadeEnumerador {
        public MotivoSaida() { }
        public MotivoSaida(string descricao) : base(descricao) { }
    }

    public class Nacionalidade : Models.EntidadeEnumerador {
        public Nacionalidade() { }
        public Nacionalidade(string descricao) : base(descricao) { }
    }

    public class SituacaoMercado : Models.EntidadeEnumerador {
        public SituacaoMercado() { }
        public SituacaoMercado(string descricao) : base(descricao) { }
    }

    public class IdentidadeGenero : Models.EntidadeEnumerador {
        public IdentidadeGenero() { }
        public IdentidadeGenero(string descricao) : base(descricao) { }
    }

    public class ConsideracaoPeso : Models.EntidadeEnumerador {
        public ConsideracaoPeso() { }
        public ConsideracaoPeso(string descricao) : base(descricao) { }
    }

    public class DoencaCardiaca : Models.EntidadeEnumerador {
        public DoencaCardiaca() { }
        public DoencaCardiaca(string descricao) : base(descricao) { }
    }

    public class ProblemaRins : Models.EntidadeEnumerador {
        public ProblemaRins() { }
        public ProblemaRins(string descricao) : base(descricao) { }
    }

    public class DoencaRespiratoria : Models.EntidadeEnumerador {
        public DoencaRespiratoria() { }
        public DoencaRespiratoria(string descricao) : base(descricao) { }
    }

    //

    //Ficha Cadastro Domiciliar e Territorial

    public class SituacaoMoradiaPosseTerra : Models.EntidadeEnumerador
    {
        public SituacaoMoradiaPosseTerra() { }
        public SituacaoMoradiaPosseTerra(string descricao) : base(descricao) { }
    }

    public class Localizacao : Models.EntidadeEnumerador
    {
        public Localizacao() { }
        public Localizacao(string descricao) : base(descricao) { }
    }

    public class TipoDomicilio : Models.EntidadeEnumerador
    {
        public TipoDomicilio() { }
        public TipoDomicilio(string descricao) : base(descricao) { }
    }

    public class TipoAcessoDomicilio : Models.EntidadeEnumerador
    {
        public TipoAcessoDomicilio() { }
        public TipoAcessoDomicilio(string descricao) : base(descricao) { }
    }

    public class CondicaoPosseUsoTerra : Models.EntidadeEnumerador
    {
        public CondicaoPosseUsoTerra() { }
        public CondicaoPosseUsoTerra(string descricao) : base(descricao) { }
    }

    public class MaterialPredominanteConstrucaoParedesExternasDomicilio : Models.EntidadeEnumerador
    {
        public MaterialPredominanteConstrucaoParedesExternasDomicilio() { }
        public MaterialPredominanteConstrucaoParedesExternasDomicilio(string descricao) : base(descricao) { }
    }

    public class AbastecimentoAgua : Models.EntidadeEnumerador
    {
        public AbastecimentoAgua() { }
        public AbastecimentoAgua(string descricao) : base(descricao) { }
    }

    public class AguaConsumoDomicilio : Models.EntidadeEnumerador
    {
        public AguaConsumoDomicilio() { }
        public AguaConsumoDomicilio(string descricao) : base(descricao) { }
    }

    public class FormaEscoamentoBanheiroOuSanitario : Models.EntidadeEnumerador
    {
        public FormaEscoamentoBanheiroOuSanitario() { }
        public FormaEscoamentoBanheiroOuSanitario(string descricao) : base(descricao) { }
    }

    public class DestinoLixo : Models.EntidadeEnumerador
    {
        public DestinoLixo() { }
        public DestinoLixo(string descricao) : base(descricao) { }
    }

    public class AnimaisDomicilio : Models.EntidadeEnumerador
    {
        public AnimaisDomicilio() { }
        public AnimaisDomicilio(string descricao) : base(descricao) { }
    }

    public class RendaFamiliar : Models.EntidadeEnumerador
    {
        public RendaFamiliar() { }
        public RendaFamiliar(string descricao) : base(descricao) { }
    }

    //

    //Ficha Atendimento Individual

    public class Turno : Models.EntidadeEnumerador
    {
        public Turno() { }
        public Turno(string descricao) : base(descricao) { }
    }

    public class LocalDeAtendimento : Models.EntidadeEnumerador
    {
        public LocalDeAtendimento() { }
        public LocalDeAtendimento(string descricao) : base(descricao) { }
    }

    public class TipoDeAtendimento : Models.EntidadeEnumerador
    {
        public TipoDeAtendimento() { }
        public TipoDeAtendimento(string descricao) : base(descricao) { }
    }

    public class AtencaoDomiciliar : Models.EntidadeEnumerador
    {
        public AtencaoDomiciliar() { }
        public AtencaoDomiciliar(string descricao) : base(descricao) { }
    }

    public class RacionalidadeSaude : Models.EntidadeEnumerador
    {
        public RacionalidadeSaude() { }
        public RacionalidadeSaude(string descricao) : base(descricao) { }
    }

    public class AleitamentoMaterno : Models.EntidadeEnumerador
    {
        public AleitamentoMaterno() { }
        public AleitamentoMaterno(string descricao) : base(descricao) { }
    }

    //

}
