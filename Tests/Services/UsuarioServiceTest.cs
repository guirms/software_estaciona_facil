using Application.Interfaces;
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
    
    
    // será implementado
    // [Fact]
    // public void CadastrarUsuario_EnviandoUsuarioJaExistente_NAOSEIOQDEVERETORNAR()
    // {
    //     Assert.Throws<NullReferenceException>(() => _usuarioService.CadastrarUsuario(null!));
    // }
}
