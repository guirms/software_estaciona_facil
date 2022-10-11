using Application.Objects.Dtos;
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
        #region Usuario

        CreateMap<UsuarioRequest, Usuario>().ReverseMap();
        CreateMap<UsuarioRequest, UsuarioDto>().ReverseMap();

        #endregion
        
        #region Token
           
        CreateMap<TokenRequest, Usuario>().ReverseMap();
        
        #endregion
        
        // Domain to ViewModel
        #region Usuario

        CreateMap<Usuario, UsuarioDto>().ReverseMap();
        CreateMap<UsuarioDto, UsuarioResponse>().ReverseMap();

        #endregion
    }
}