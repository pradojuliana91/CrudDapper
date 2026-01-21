using CrudDapper.Dtos;
using CrudDapper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet()]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios();
            if (usuarios.Status == false)
            {
                return NotFound(usuarios);
            }
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarUsuarioPorId(int id)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioPorId(id);
            if (usuario.Status == false)
            {
                return NotFound(usuario);
            }
            return Ok(usuario);
        }

        [HttpPost()]
        public async Task<IActionResult> CriarUsuario(UsuarioCriarDto usuarioCriarDto)
        {
            var novoUsuario = await _usuarioInterface.CriarUsuario(usuarioCriarDto);
            if (novoUsuario.Status == false)
            {
                return BadRequest(novoUsuario);
            }
            return Ok(novoUsuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarUsuario(int id, UsuarioEditarDto usuarioEditarDto)
        {
            var usuarioEditado = await _usuarioInterface.EditarUsuario(id, usuarioEditarDto);
            if (usuarioEditado.Status == false)
            {
                return BadRequest(usuarioEditado);
            }
            return Ok(usuarioEditado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            var usuario = await _usuarioInterface.DeletarUsuario(id);

            if (usuario.Status == false)
            {
                return BadRequest(usuario);
            }
            return Ok(usuario);
        }
    }
}
