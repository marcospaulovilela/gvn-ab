using gvn_ab_mobile.Models;

namespace gvn_ab_mobile.ViewModels {
    public class UsuarioViewModel : BaseViewModel {
        public Usuario Usuario { get; set; }
        public UsuarioViewModel(Usuario Usuario = null) {
            Title = Usuario.Nome;
            this.Usuario = Usuario;
        }
    }
}