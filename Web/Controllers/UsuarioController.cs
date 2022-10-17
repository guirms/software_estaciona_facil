using Application.Interfaces;
using Application.Objects.Bases;
using Application.Objects.Requests.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("Usuario")]
public class UsuarioController: ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpPost("CadastrarUsuario")]
    public JsonResult CadastrarUsuario([FromBody] UsuarioRequest usuarioRequest)
    {
        try
        {
            var cadastrarUsuario = _usuarioService.CadastrarUsuario(usuarioRequest);
        
            return ResponseBase.ResponderController(true, $"Usuário cadastrado com sucesso", cadastrarUsuario);
        }
        catch (Exception e)
        {
            return ResponseBase.ResponderController(false, "Erro ao salvar usuário", e.Message);
        }
    }
}