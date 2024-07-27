using ApiLibro.Conexiones;
using ApiLibro.Models;
using Microsoft.AspNetCore.SignalR;

namespace ApiLibro.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario GetUser(string email, string password);
        Usuario GetUserById(int id);
        string Eliminar(int id);
        bool Activar(int id);
        bool addUser(Usuario usuario);
        List<Usuario> GetAllUser();
    }
}
 