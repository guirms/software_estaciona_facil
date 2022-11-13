namespace Application.Objects.Responses.Usuario;

public class UsuarioResponse
{
    public UsuarioResponse(int usuarioId, string tokenSessaoUsuario)
    {
        UsuarioId = usuarioId;
        TokenSessaoUsuario = tokenSessaoUsuario;
    }

    public int UsuarioId { get; set; }
    public string TokenSessaoUsuario { get; set; }
}