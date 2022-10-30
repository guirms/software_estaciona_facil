namespace Application.Objects.Requests.Usuario;

public class UsuarioCadastroRequest
{ 
    public string Email { get; set; }
    public string Senha { get; set; }
    public string ConfirmacaoSenha { get; set; }
}