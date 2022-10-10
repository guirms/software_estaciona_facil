using Application.Objects.Requests.Usuario;
using Application.Objects.Responses.Usuario;
using Domain.Models;

namespace Application.Interfaces;

public interface IUsuarioService
{
    UsuarioResponse CadastrarUsuario(Usuario usuarioRequest);
    string AutenticarUsuario(UsuarioRequest usuarioRequest);
}