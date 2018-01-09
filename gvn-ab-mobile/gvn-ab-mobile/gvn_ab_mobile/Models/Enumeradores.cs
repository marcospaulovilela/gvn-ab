using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Models {
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

}
