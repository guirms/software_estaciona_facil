using Application.Interfaces;
using Application.Objects.Base;
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
    
    [HttpPost("SalvarUsuario")]
    public JsonResult SalvarUsuario([FromBody] UsuarioRequest usuarioRequest)
    {
        try
        {
            var salvarUsuario = _usuarioService.SalvarUsuario(usuarioRequest);
        
            return ResponseBase.ResponderController(true, $"Usuário {(salvarUsuario.UsuarioId == 0 ? "inserido" : "alterado")} com sucesso", salvarUsuario);
        }
        catch (Exception e)
        {
            return ResponseBase.ResponderController(false, "Erro ao salvar usuário", e.Message);
        }
    }
}