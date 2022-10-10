﻿using Domain.Models;

namespace Infra.Data.Interfaces;

public interface IUsuarioRepository: IBaseRepository<Usuario>
{
    int SalvarUsuario(Usuario usuarioRequest, int usuarioId);
}