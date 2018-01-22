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

    public class CursoMaisElevado : Models.EntidadeEnumerador {
        public CursoMaisElevado() { }
        public CursoMaisElevado(string descricao) : base(descricao) { }
    }

    public class RelacaoParentesco : Models.EntidadeEnumerador {
        public RelacaoParentesco() { }
        public RelacaoParentesco(string descricao) : base(descricao) { }
    }

    public class ResponsavelCrianca : Models.EntidadeEnumerador {
        public ResponsavelCrianca() { }
        public ResponsavelCrianca(string descricao) : base(descricao) { }
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

    public class SituacaoMercadoTrabalho : Models.EntidadeEnumerador {
        public SituacaoMercadoTrabalho() { }
        public SituacaoMercadoTrabalho(string descricao) : base(descricao) { }
    }

    public class IdentidadeGeneroCidadao : Models.EntidadeEnumerador {
        public IdentidadeGeneroCidadao() { }
        public IdentidadeGeneroCidadao(string descricao) : base(descricao) { }
    }

    public class ConsideracaoPeso : Models.EntidadeEnumerador {
        public ConsideracaoPeso() { }
        public ConsideracaoPeso(string descricao) : base(descricao) { }
    }

    public class QuantasVezesAlimentacao : Models.EntidadeEnumerador
    {
        public QuantasVezesAlimentacao() { }
        public QuantasVezesAlimentacao(string descricao) : base(descricao) { }
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

    public class AcessoHigiene : Models.EntidadeEnumerador
    {
        public AcessoHigiene() { }
        public AcessoHigiene(string descricao) : base(descricao) { }
    }

    public class DeficienciaCidadao : Models.EntidadeEnumerador
    {
        public DeficienciaCidadao() { }
        public DeficienciaCidadao(string descricao) : base(descricao) { }
    }

    public class TempoSituacaoDeRua : Models.EntidadeEnumerador
    {
        public TempoSituacaoDeRua() { }
        public TempoSituacaoDeRua(string descricao) : base(descricao) { }
    }
    
    //

    //Ficha Cadastro Domiciliar e Territorial

    public class SituacaoDeMoradia : Models.EntidadeEnumerador
    {
        public SituacaoDeMoradia() { }
        public SituacaoDeMoradia(string descricao) : base(descricao) { }
    }

    public class LocalizacaoDaMoradia : Models.EntidadeEnumerador
    {
        public LocalizacaoDaMoradia() { }
        public LocalizacaoDaMoradia(string descricao) : base(descricao) { }
    }

    public class TipoDeDomicilio : Models.EntidadeEnumerador
    {
        public TipoDeDomicilio() { }
        public TipoDeDomicilio(string descricao) : base(descricao) { }
    }

    public class TipoDeAcessoAoDomicilio : Models.EntidadeEnumerador
    {
        public TipoDeAcessoAoDomicilio() { }
        public TipoDeAcessoAoDomicilio(string descricao) : base(descricao) { }
    }

    public class CondicaoDePosseEUsoDaTerra : Models.EntidadeEnumerador
    {
        public CondicaoDePosseEUsoDaTerra() { }
        public CondicaoDePosseEUsoDaTerra(string descricao) : base(descricao) { }
    }

    public class MaterialPredominanteNaConstrucao : Models.EntidadeEnumerador
    {
        public MaterialPredominanteNaConstrucao() { }
        public MaterialPredominanteNaConstrucao(string descricao) : base(descricao) { }
    }

    public class AbastecimentoDeAgua : Models.EntidadeEnumerador
    {
        public AbastecimentoDeAgua() { }
        public AbastecimentoDeAgua(string descricao) : base(descricao) { }
    }

    public class AguaConsumoDomicilio : Models.EntidadeEnumerador
    {
        public AguaConsumoDomicilio() { }
        public AguaConsumoDomicilio(string descricao) : base(descricao) { }
    }

    public class FormaDeEscoamentoDoBanheiroOuSanitario : Models.EntidadeEnumerador
    {
        public FormaDeEscoamentoDoBanheiroOuSanitario() { }
        public FormaDeEscoamentoDoBanheiroOuSanitario(string descricao) : base(descricao) { }
    }

    public class DestinoDoLixo : Models.EntidadeEnumerador
    {
        public DestinoDoLixo() { }
        public DestinoDoLixo(string descricao) : base(descricao) { }
    }

    public class AnimalNoDomicilio : Models.EntidadeEnumerador
    {
        public AnimalNoDomicilio() { }
        public AnimalNoDomicilio(string descricao) : base(descricao) { }
    }

    public class RendaFamiliar : Models.EntidadeEnumerador
    {
        public RendaFamiliar() { }
        public RendaFamiliar(string descricao) : base(descricao) { }
    }
    
    public class TipoDeImovel : Models.EntidadeEnumerador
    {
        public TipoDeImovel() { }
        public TipoDeImovel(string descricao) : base(descricao) { }
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

    public class ModalidadeAD : Models.EntidadeEnumerador
    {
        public ModalidadeAD() { }
        public ModalidadeAD(string descricao) : base(descricao) { }
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

    public class OrigemAlimentacao : Models.EntidadeEnumerador {
        public OrigemAlimentacao() { }
        public OrigemAlimentacao(string descricao) : base(descricao) { }
    }

    public class Nasfs : Models.EntidadeEnumerador
    {
        public Nasfs() { }
        public Nasfs(string descricao) : base(descricao) { }
    }

    public class ListaCiapCondicaoAvaliada : Models.EntidadeCondicaoAvaliada
    {
        public ListaCiapCondicaoAvaliada() { }
        public ListaCiapCondicaoAvaliada(string descricaoAB, string ciap2Relacionada) : base(descricaoAB, ciap2Relacionada) { }
    }

    public class ListaExames : Models.EntidadeExames
    {
        public ListaExames() { }
        public ListaExames(string descricaoAB, string codigoSIGTAP) : base(descricaoAB, codigoSIGTAP) { }
    }

    public class CondutaEncaminhamento : Models.EntidadeDescricaoObservacao
    {
        public CondutaEncaminhamento() { }
        public CondutaEncaminhamento(string descricao) : base(descricao) { }
        public CondutaEncaminhamento(string descricao, string observacao) : base(descricao, observacao) { }
    }

    //

    // Ficha Visita Domiciliar e Territorial

    public class MotivoVisita : Models.EntidadeDescricaoObservacao
    {
        public MotivoVisita() { }
        public MotivoVisita(string descricao) : base(descricao) { }
        public MotivoVisita(string descricao, string observacao) : base(descricao, observacao) { }
    }

    public class Desfecho : Models.EntidadeEnumerador
    {
        public Desfecho() { }
        public Desfecho(string descricao) : base(descricao) { }
    }

    //
}
