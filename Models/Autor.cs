namespace ApiLibro.Models
{
    public class Autor
    {
        public Autor()
        {
            Sexo = new Sexo();
            Pais = new Pais();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Sexo Sexo { get; set; }
        public Pais Pais { get; set; }
        public bool estado { get; set; }
    }
}
