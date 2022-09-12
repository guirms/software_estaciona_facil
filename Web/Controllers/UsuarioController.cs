using Application.Interfaces;
using Application.Objects.Base;
using Application.Objects.Requests.Usuario;
using Application.Services;
using AutoMapper;
using Domain.Models;
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
    public ResponseBase<Usuario> SalvarUsuario([FromBody] UsuarioRequest usuarioRequest)
    {
        var salvarUsuario = _usuarioService.SalvarUsuario(usuarioRequest);

        return salvarUsuario;
    }
}