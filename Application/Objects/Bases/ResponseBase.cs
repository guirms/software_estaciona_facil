using Microsoft.AspNetCore.Mvc;

namespace Application.Objects.Bases;

public class ResponseBase
{
    public static JsonResult ResponderController(bool sucessoOperacao, string msg, object dataOperacao)
    {
        return BigJson(new
        {
            sucesso = sucessoOperacao,
            mensagem = msg,
            data = dataOperacao,
        });
    }
    
    public static JsonResult BigJson(object data)
    {
        return new JsonResult(data);
    }
}