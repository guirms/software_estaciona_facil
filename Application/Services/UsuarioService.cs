﻿using System.ComponentModel.DataAnnotations;
using Application.Interfaces;
using Application.Objects.Requests.Usuario;
using Application.Objects.Responses.Usuario;
using AutoMapper;
using Domain.Models;
using Infra.Data.Interfaces;

namespace Application.Services;

public class UsuarioService: IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository; 
    private readonly ITokenService _tokenService; 
    
    public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository, ITokenService tokenService)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
        _tokenService = tokenService;
    }

    public UsuarioResponse CadastrarUsuario(UsuarioRequest usuarioRequest)
    {
        var usuarioJaExiste = _usuarioRepository.GetUsuarioByEmail(usuarioRequest.Email);
        
        if (usuarioJaExiste != null)
            throw new Exception("Já existe um usuário com esse e-mail no sistema");

        if (!EmailValido(usuarioRequest.Email))
            throw new Exception("Email inválido");

        var lUsuario = _mapper.Map<Usuario>(usuarioRequest);

        if (lUsuario == null)
            throw new NullReferenceException("Usuário nulo");

        var usuarioCadastrado = _usuarioRepository.SalvarUsuario(lUsuario, lUsuario.UsuarioId);

        if (usuarioCadastrado == 0)
            throw new Exception("Erro ao salvar usuário");

        var tokenSessaoUsuario = _tokenService.GerarTokenSessao(lUsuario);

        if (tokenSessaoUsuario == null)
            throw new Exception("Erro ao gerar token de usuário");

        var lUsuarioResponse = _mapper.Map<UsuarioResponse>(lUsuario);

        lUsuarioResponse.TokenSessaoUsuario = tokenSessaoUsuario;

        return lUsuarioResponse;
    }

    private bool EmailValido(string email)
    {
        if(new EmailAddressAttribute().IsValid(email))
        {
            return true;
        }
        
        return false;
    }
}