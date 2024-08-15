using ApiLibro.Models;
using ApiLibro.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace ApiLibro.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UsuarioServices _usuarioServices;

        public UsuarioController(IConfiguration configuration, UsuarioServices usuarioServices)
        {
            _configuration = configuration;
            _usuarioServices = usuarioServices;

        }

        [HttpPost]
        [Route("Auth")]
        public dynamic AuthClient([FromBody] Login request)
        {
            if (request == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }

            var usuario = _usuarioServices.AuthenticateUser(request.Email, request.Password);
            if (usuario == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }

            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(),ClaimValueTypes.Integer64),
                new Claim("id", usuario.Id.ToString()),
                new Claim("name", usuario.name.ToString()),
                new Claim("lastName", usuario.lastName.ToString()),
                new Claim("email", usuario.email.ToString()),
                new Claim("rol", usuario.Rol.Nombre.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signingCredentials
            );

            return new
            {
                success = true,
                message = "exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        [HttpDelete]
        [Route("Auth/Delet")]
        public dynamic DeletedUser([FromBody] int id)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.ValidarToken(identity, _usuarioServices);

            if (!rToken.success) return rToken;

            Usuario usuario1 = rToken.result;

            var Rol = identity.Claims.FirstOrDefault(x => x.Type == "rol");
            var rol = Rol.Value;
            if (!rol.Equals("Administrador"))
            {
                return new
                {
                    success = false,
                    message = "No estas autorizado para esta accion",
                    result = ""
                };


            }
            _usuarioServices.Eliminar(id);
            return new
            {
                success = true,
                message = "cliente eliminado",
                result = id

            };
        }

        //en esta si le enviamos un token con nivel de administrador puede agregar si no le enviamos token es para registrar
        [HttpPut]
        [Route("RegisterUser")]
        public dynamic addUser(Usuario usuario)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.ValidarToken(identity, _usuarioServices);
            if (usuario.Rol.Id==1)
            {

                if (!rToken.success)
                {
                    return new
                    {
                        success = false,
                        message = "Token no autorizado",
                        result = ""
                    };
                }

                var Rol = identity.Claims.FirstOrDefault(x => x.Type == "rol");
                var rol = Rol.Value;

                if (!rol.Equals("Administrador"))
                {

                    return new
                    {
                        success = false,
                        message = "No tienes permiso para agregar un administrador",
                        result = ""
                    };

                }
            }

            List <Usuario> usuarios = new List<Usuario>();
            var registrado = _usuarioServices.GetAllUser().FirstOrDefault(x => x.email.ToLower() == usuario.email.ToLower());
            if (registrado != null) {
                return new
                {
                    success = false,
                    message = "Email ya registrado ingrese otro distinto",
                    result = usuario
                };
            }


            bool agregar2 = _usuarioServices.addUser(usuario);
            if (agregar2)
            {
                return new
                {
                    success = true,
                    message = "Agregado",
                    result = usuario
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Ocurrio un error no se agrego",
                    result = ""
                };
            }
        }
        [HttpPut]
        [Route("Auth/updateUser")]
        public dynamic upDateUser([FromBody] int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.ValidarToken(identity, _usuarioServices);

            if (!rToken.success)
            {
                return new
                {
                    success = false,
                    message = "Token inválido",
                    result = ""
                };
            }

            Usuario usuario1 = rToken.result;
            var rol = identity.Claims.FirstOrDefault(x => x.Type == "rol")?.Value;

            if (rol != "Administrador")
            {
                return new
                {
                    success = false,
                    message = "No tienes permiso para agregar usuarios",
                    result = id
                };
            }

            bool agregar = _usuarioServices.ActiveUser(id);
            if (agregar)
            {
                return new
                {
                    success = true,
                    message = "actualizado correctamente",
                    result = id
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "No se actualizo el usuario",
                    result = id
                };
            }



        }

        [HttpPost]
        [Route("Auth/AllUser")]
        public dynamic AllUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var rToken = Jwt.ValidarToken(identity, _usuarioServices);
            if (!rToken.success)
            {
                return new
                {
                    success = false,
                    message = "Token no autorizado",
                    result = ""
                };
            }
            var Rol = identity.Claims.FirstOrDefault(x => x.Type == "rol");
            var rol = Rol.Value;
            if (!rol.Equals("Administrador"))
            {
                return new
                {
                    success = false,
                    message = "No tienes permiso para ver la lista de usuarios",
                    result = ""
                };
            }

            List<Usuario> usuarios = _usuarioServices.GetAllUser();

            return new
            {
                success = true,
                message = "Lista de usuarios",
                result = usuarios
            };
        }

    }
}
