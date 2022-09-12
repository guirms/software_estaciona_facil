using Application.Interfaces;
using Application.Objects.Base;
using Application.Objects.Requests.Usuario;
using AutoMapper;
using Domain.Models;
using Infra.Data.Interfaces;

namespace Application.Services;

public class UsuarioService: IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository; //INJETAR USUARIO REPO
    public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
    }
    
    public ResponseBase<Usuario> SalvarUsuario(UsuarioRequest usuarioRequest)
    {
        var lUsuario = _mapper.Map<Usuario>(usuarioRequest);

        if (usuarioRequest.UsuarioId != 0)
            _usuarioRepository.Update(lUsuario);
        else
            _usuarioRepository.Add(lUsuario);

        return new ResponseBase<Usuario>(true, "Cliente salvo com sucesso");
    }
}