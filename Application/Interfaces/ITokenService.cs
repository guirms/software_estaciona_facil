using Domain.Models;

namespace Application.Interfaces;

public interface ITokenService
{
    string GerarToken(Usuario usuario);
}