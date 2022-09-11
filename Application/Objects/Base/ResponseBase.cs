using Microsoft.AspNetCore.Mvc;

namespace Application.Objects.Base;

public class ResponseBase<T> where T: class 
{
    public bool Sucesso;
    public string Mensagem;
    public T? JsonRetorno;
    
    public  ResponseBase(bool sucesso, string mensagem, T? jsonRetorno = default)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
        JsonRetorno = jsonRetorno;
    }
    
    public static JsonResult Responder(bool sucesso, string msg, object data)
    {
        return BigJson(new
        {
            sucesso = sucesso,
            mensagem = msg,
            data = data,
        });
    }
    
    public static JsonResult BigJson(object data)
    {
        return new JsonResult(data);
    }
}