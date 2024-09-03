using Microsoft.AspNetCore.Mvc;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth/token")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            //autenticação fixa pois não tem tabelas de usuarios do sistema
            if (username == "UsuarioTeste" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Model.Fornecedor());
                return Ok(token);
            }
            return BadRequest("Usuario ou senha inválidos");
        }
    }
}
