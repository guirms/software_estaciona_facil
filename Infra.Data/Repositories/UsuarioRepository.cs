using Domain.Models;
using Infra.Data.Context;
using Infra.Data.Interfaces;

namespace Infra.Data.Repositories;

public class UsuarioRepository: BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ConfigContext contexto) : base(contexto)
    {
    }
    
    public void SalvarUsuario(Usuario usuarioObj, int usuarioId)
    {
        if (usuarioId != 0)
            Update(usuarioObj);
        else
            Add(usuarioObj);
    }
    
}