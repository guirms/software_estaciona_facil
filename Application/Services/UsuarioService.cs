using Application.Interfaces;
using Application.Objects.Dtos;
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
    
    public UsuarioResponse CadastrarUsuario(UsuarioRequest usuarioRequest)
    {
        var lUsuario = _mapper.Map<Usuario>(usuarioRequest);
        
        if (lUsuario == null)
            throw new NullReferenceException("Usuário nulo");
        
        var usuarioCadastrado = _usuarioRepository.SalvarUsuario(lUsuario, lUsuario.UsuarioId);
        
        if (usuarioCadastrado == 0) 
            throw new NullReferenceException("Erro ao salvar usuário");
        
        var tokenSessaoUsuario = _tokenService.GerarTokenSessao(lUsuario);

        if (tokenSessaoUsuario == null) 
            throw new NullReferenceException("Erro ao gerar token de usuário");
        
        var lUsuarioDto = _mapper.Map<UsuarioDto>(lUsuario);

        return _mapper.Map<UsuarioResponse>(lUsuarioDto);
    }

    public string AutenticarUsuario(UsuarioRequest usuarioRequest)
    {
        var usuarioLogado = _usuarioRepository.GetAll().FirstOrDefault(x => x.Email == usuarioRequest.Email);
        
        var lUsuario = _mapper.Map<Usuario>(usuarioRequest);

        if (usuarioLogado != null) 
            return _tokenService.GerarTokenSessao(lUsuario);
        
        return String.Empty; 
    }
}