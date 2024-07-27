using ApiLibro.Services;
using System;
using System.Linq;
using System.Security.Claims;

namespace ApiLibro.Models
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public static dynamic ValidarToken(ClaimsIdentity token, UsuarioServices usuarioService)
        {
            if (token.Claims.Count() == 0)
            {
                return new
                {
                    success = false,
                    message = "Token no autorizado",
                    result = token
                };
            } 
            try
            {
                

                var idClaim = token.Claims.FirstOrDefault(x => x.Type == "id");
                if (idClaim == null)
                {
                    return new
                    {
                        success = false,
                        message = "ID no recibido",
                        result = ""
                    };
                }

                if (!int.TryParse(idClaim.Value, out int userId))
                {
                    return new
                    {
                        success = false,
                        message = "ID de Token no válido",
                        result = ""
                    };
                }

                Usuario usuario = usuarioService.UserById(userId);
                if (usuario == null)
                {
                    return new
                    {
                        success = false,
                        message = "Usuario no encontrado",
                        result = ""
                    };
                }

                return new
                {
                    success = true,
                    message = "Authorize",
                    result = usuario
                };
            }
            catch (Exception e)
            {
                return new
                {
                    success = false,
                    message = "Error: " + e.Message,
                    result = ""
                };
            }
        }
    }
}