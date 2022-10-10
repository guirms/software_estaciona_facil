using Application.Interfaces;
using Application.Objects.Base;
using Application.Objects.Requests.Token;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("Token")]
public class TokenController: ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    
    public TokenController(ITokenService tokenService, IMapper mapper)
    {
        _mapper = mapper;
        _tokenService = tokenService;
    }
    
    [HttpPost("GerarToken")]
    public JsonResult GerarToken(TokenRequest tokenRequest)
    {
        try
        {
            var lUsuario = _mapper.Map<Usuario>(tokenRequest);
            
            var token = _tokenService.GerarToken(lUsuario);
         
            return ResponseBase.ResponderController(true, "Token gerado com sucesso", token);
        }
        catch (Exception e)
        {
            return ResponseBase.ResponderController(false, "Erro ao gerar token", e.Message);
        }
    }
}