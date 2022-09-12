using Application.Objects.Base;
using Application.Objects.Requests.Usuario;
using Domain.Models;

namespace Application.Interfaces;

public interface IUsuarioService
{
    ResponseBase<Usuario> SalvarUsuario(UsuarioRequest usuarioRequest);
}