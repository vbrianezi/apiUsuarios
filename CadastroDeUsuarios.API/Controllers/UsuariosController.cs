using CadastroDeUsuarios.API.Interface;
using CadastroDeUsuarios.API.Models;
using CadastroDeUsuarios.API.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        public UsuariosController(IUsuariosRepositorio usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios() 
        {
            return Ok(await _usuariosRepositorio.SelecionarTodos());
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarUsuario(Usuarios usuario)
        {
            _usuariosRepositorio.Incluir(usuario);
            if (await _usuariosRepositorio.SaveAllAsync())
            {
                return Ok("Usuário cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao cadastrar o usuário!");
        }

        [HttpPut]
        public async Task<ActionResult> AlterarUsuario(Usuarios usuario)
        {
            _usuariosRepositorio.Alterar(usuario);
            if (await _usuariosRepositorio.SaveAllAsync())
            {
                return Ok("Usuário alterado com sucesso!");
            }
            return BadRequest("Ocorreu um erro ao alterar o usuário!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCliente(int id)
        {
            var usuario = await _usuariosRepositorio.SelecionarByPk(id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado!");
            }
            
            _usuariosRepositorio.Excluir(usuario);

            if (await _usuariosRepositorio.SaveAllAsync())
            {
                return Ok("Usuário excluído com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao excluir o usuário!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> SelecionarUsuario(int id)
        {
            var usuario = await _usuariosRepositorio.SelecionarByPk(id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            return Ok(usuario);
        }
    }
}
