namespace Application.Objects.Dtos;

public class UsuarioDto
{
    public int UsuarioId { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string TokenSessaoUsuario { get; set; }
}