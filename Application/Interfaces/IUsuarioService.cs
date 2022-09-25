using Application.Objects.Requests.Usuario;
using Application.Objects.Responses.Usuario;

namespace Application.Interfaces;

public interface IUsuarioService
{
    UsuarioResponse SalvarUsuario(UsuarioRequest usuarioRequest);
    string AutenticarUsuario(UsuarioRequest usuarioRequest);
}