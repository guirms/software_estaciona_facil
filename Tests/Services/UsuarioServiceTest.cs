using Application.Interfaces;
using Application.Objects.Requests.Usuario;
using Application.Services;
using AutoMapper;
using Infra.Data.Interfaces;
using Moq;
using Xunit;

namespace Tests.Services;

public class UsuarioServiceTest
{
    private UsuarioService _usuarioService;

    public UsuarioServiceTest()
    {
        _usuarioService = new UsuarioService(new Mock<IMapper>().Object, new Mock<IUsuarioRepository>().Object,
            new Mock<ITokenService>().Object);
    }

    [Fact]
    public void CadastrarUsuario_EnviandoUsuarioNulo_DeveRetornarException()
    {
        Assert.Throws<NullReferenceException>(() => _usuarioService.CadastrarUsuario(null!));
    }
    
    [Fact]
    public void CadastrarUsuario_EnviandoEmailIncorreto_DeveRetornarException()
    {
        var usuarioTeste = new UsuarioRequest { Email = "emailinvalido" };
        var chamdaMetodo = Assert.Throws<Exception>(() => _usuarioService.CadastrarUsuario(usuarioTeste));
        
        Assert.Equal("Email inválido", chamdaMetodo.Message);

    }
    
    // será implementado
    // [Fact]
    // public void CadastrarUsuario_EnviandoUsuarioJaExistente_NAOSEIOQDEVERETORNAR()
    // {
    //     Assert.Throws<NullReferenceException>(() => _usuarioService.CadastrarUsuario(null!));
    // }
}
