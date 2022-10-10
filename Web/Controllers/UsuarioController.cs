using Application.Interfaces;
using Application.Objects.Base;
using Application.Objects.Requests.Usuario;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("Usuario")]
public class UsuarioController: ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public UsuarioController(IUsuarioService usuarioService, ITokenService tokenService, IMapper mapper)
    {
        _usuarioService = usuarioService;
        _tokenService = tokenService;
        _mapper = mapper;
    }
    
    [HttpPost("CadastrarUsuario")]
    public JsonResult CadastrarUsuario([FromBody] UsuarioRequest usuarioRequest)
    {
        try
        {
            var lUsuario = _mapper.Map<Usuario>(usuarioRequest);

            var tokenUsuario = _tokenService.GerarToken(lUsuario);
            
            _usuarioService.CadastrarUsuario(lUsuario);
        
            return ResponseBase.ResponderController(true, $"Usuário cadastrado com sucesso", tokenUsuario);
        }
        catch (Exception e)
        {
            return ResponseBase.ResponderController(false, "Erro ao salvar usuário", e.Message);
        }
    }
}