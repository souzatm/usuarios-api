﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }


        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            await _usuarioService.Cadastra(dto);
            return Ok("Usuário cadastrado.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.LoginAsync(dto);
            return Ok(token);
        }
    }
}
