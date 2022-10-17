using Domain.Models;
using Infra.Data.Context;
using Infra.Data.Interfaces;

namespace Infra.Data.Repositories;

public class UsuarioRepository: BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ConfigContext contexto) : base(contexto)
    {
    }
    
    public int SalvarUsuario(Usuario lUsuario, int usuarioId)
    {
        if (usuarioId != 0)
           return Update(lUsuario);
        
        return Add(lUsuario);
    }

    public Usuario? GetUsuarioByEmail(string email)
    {
        return Contexto.Set<Usuario>().SingleOrDefault(u => u.Email == email);
    }
}