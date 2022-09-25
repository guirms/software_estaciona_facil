using Application.Objects.Requests.Token;
using Application.Objects.Requests.Usuario;
using Application.Objects.Responses.Usuario;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper;

public class AutoMapper: Profile
{
    public AutoMapper()
    {
        // ViewModel to domain
        #region Cliente

        CreateMap<UsuarioRequest, Usuario>().ReverseMap();
        CreateMap<TokenRequest, Usuario>().ReverseMap();

        #endregion
        
        // Domain to ViewModel
        #region Cliente

        CreateMap<Usuario, UsuarioResponse>().ReverseMap();

        #endregion
    }
}