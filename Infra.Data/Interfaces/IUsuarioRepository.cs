using Domain.Models;

namespace Infra.Data.Interfaces;

public interface IUsuarioRepository: IBaseRepository<Usuario>
{
    void SalvarUsuario(Usuario usuarioRequest, int usuarioId);
}