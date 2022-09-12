using Application.Objects.Requests.Usuario;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper;

public class AutoMapper: Profile
{
    public AutoMapper()
    {
        #region Cliente

        CreateMap<UsuarioRequest, Usuario>();

        #endregion
    }
}