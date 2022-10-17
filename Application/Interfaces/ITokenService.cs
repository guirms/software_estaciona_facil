using Domain.Models;

namespace Application.Interfaces;

public interface ITokenService
{
    string GerarTokenSessao(Usuario usuario);
}