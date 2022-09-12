using Domain.Models;
using Infra.Context;
using Infra.Interfaces;

namespace Infra.Repositories;

public class UsuarioRepository: BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ConfigContext contexto) : base(contexto)
    {
    }
}