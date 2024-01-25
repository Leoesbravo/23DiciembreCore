using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            ApellidoPaterno = apellidoPaterno;
            Nombre = nombre;
            ApellidoMaterno = "";
        }
        public Usuario(int idusuario, string nombre, string apellidoPaterno, string apellidoMaterno, int edad)
        {
            IdUsuario = idusuario;
            Nombre = nombre;
            ApellidoMaterno = apellidoMaterno;
            ApellidoPaterno = apellidoPaterno;
            Edad = edad;
        }
        public Usuario(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public bool Status { get; set; }
        public byte[] Imagen { get; set; }
        public List<object> Usuarios { get; set; }

        //Propiedad de navegacion
        //Navegar entre clases
        public ML.Rol Rol { get; set; }
        public ML.Direccion Direccion { get; set; }
    }
}