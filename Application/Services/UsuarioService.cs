using Application.Interfaces;
using Application.Objects.Requests.Usuario;
using Application.Objects.Responses.Usuario;
using AutoMapper;
using Domain.Models;
using Infra.Data.Interfaces;

namespace Application.Services;

public class UsuarioService: IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository; 
    private readonly ITokenService _tokenService; 
    
    public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository, ITokenService tokenService)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
        _tokenService = tokenService;
    }
    
    public UsuarioResponse CadastrarUsuario(Usuario lUsuario)
    {
        if (lUsuario == null)
            throw new NullReferenceException("Usuário nulo");
        
        var usuarioCadastrado = _usuarioRepository.SalvarUsuario(lUsuario, lUsuario.Id);
        
        if (usuarioCadastrado == 0) 
            throw new NullReferenceException("Erro ao cadastrar usuário");

        lUsuario.Id = usuarioCadastrado;
        
        return _mapper.Map<UsuarioResponse>(lUsuario);
    }

    public string AutenticarUsuario(UsuarioRequest usuarioRequest)
    {
        var usuarioLogado = _usuarioRepository.GetAll().FirstOrDefault(x => x.Email == usuarioRequest.Email);
        
        var lUsuario = _mapper.Map<Usuario>(usuarioRequest);

        if (usuarioLogado != null) return _tokenService.GerarToken(lUsuario);
        
        return String.Empty; 
    }
}