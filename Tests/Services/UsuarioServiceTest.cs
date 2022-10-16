using Application.Objects.Requests.Usuario;
using Application.Services;
using Domain.Models;
using Tests.Setup;
using Xunit;

namespace Tests.Services;

public class UsuarioServiceTest: TestsSetup
{
    private UsuarioService _usuarioService;
    public UsuarioServiceTest()
    {
        _usuarioService = new UsuarioService(AutoMapperMock, 
            UsuarioRepositoryMock.Object,
            TokenServiceMock.Object);
    }

    [Fact]
    public void CadastrarUsuario_EnviandoUsuarioNulo_DeveRetornarUsuarioNulo()
    {
        var chamadaMetodo = Assert.Throws<NullReferenceException>(() => _usuarioService.CadastrarUsuario(null!));
        
        Assert.Equal("Usuário nulo", chamadaMetodo.Message);
    }
    
    [Fact]
    public void CadastrarUsuario_EnviandoEmailIncorreto_DeveRetornarEmailInvalido()
    {
        var usuarioTeste = new UsuarioRequest
        {
            Email = "emailinvalido", 
            Senha = "teste123"
        };
        var chamadaMetodo = Assert.Throws<Exception>(() => _usuarioService.CadastrarUsuario(usuarioTeste));
        
        Assert.Equal("Email inválido", chamadaMetodo.Message);

    }
    
     [Fact]
     public void CadastrarUsuario_EnviandoEmailNulo_DeveRetornarEmailNulo()
     {
         var usuarioTeste = new UsuarioRequest
         {
             Email = "",
             Senha = "teste"
         };
         
         var chamadaMetodo = Assert.Throws<Exception>(() => _usuarioService.CadastrarUsuario(usuarioTeste));
        
         Assert.Equal("Email inválido", chamadaMetodo.Message);
     }
     
     [Fact]
     public void CadastrarUsuario_EnviandoSenhaNula_DeveRetornarSenhaNula()
     {
         var usuarioTeste = new UsuarioRequest
         {
             Email = "testeunitario@teste.com",
             Senha = ""
         };
         
         var chamadaMetodo = Assert.Throws<NullReferenceException>(() => _usuarioService.CadastrarUsuario(usuarioTeste));
        
         Assert.Equal("Senha nula é inválida", chamadaMetodo.Message);
     }
     
     [Fact]
     public void CadastrarUsuario_EnviandoUsuarioJaExistente_DeveRetornarUsuarioExistente()
     {
         var usuarioTeste = new UsuarioRequest
         {
             Email = "teste@teste.com",
             Senha = "teste"
         };
         
         UsuarioRepositoryMock.Setup(x => x.GetUsuarioByEmail(usuarioTeste.Email)).Returns(new Usuario());
         
         _usuarioService = new UsuarioService(AutoMapperMock, UsuarioRepositoryMock.Object, TokenServiceMock.Object);
         
         var chamadaMetodo = Assert.Throws<Exception>(() => _usuarioService.CadastrarUsuario(usuarioTeste));
        
         Assert.Equal("Usuário já cadastrado no sistema", chamadaMetodo.Message);
     }
}
