namespace ApiLibro.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string name {  get; set; }
        public string lastName { get; set; }
 
        public string email { get; set; }
        public string password { get; set; }
        public bool estado { get; set;}
        public Rol Rol { get; set; }
        public Sexo Sexo { get; set; }
    }
}
