using Application.Interfaces;
using Application.Objects.Requests.Usuario;
using AutoMapper;
using Domain.Models;
using Infra.Data.Interfaces;

namespace Application.Services;

public class UsuarioService: IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository; //INJETAR USUARIO REPO
    public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
    }
    
    public UsuarioRequest SalvarUsuario(UsuarioRequest usuarioRequest)
    {
        var lUsuario = _mapper.Map<Usuario>(usuarioRequest);
        
        _usuarioRepository.SalvarUsuario(lUsuario, usuarioRequest.UsuarioId);

        return _mapper.Map<UsuarioRequest>(lUsuario);
    }
}