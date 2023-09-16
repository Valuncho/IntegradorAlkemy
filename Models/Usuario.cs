using System.Security.Cryptography;
using System.Text;

namespace Integrador.Models
{
    public class Usuario
    {
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public int Tipo { get; set; }
        private string ContraseñaHash { get; set; }

        public Usuario(int codUsuario, string nombre, int dni, int tipo, string contraseña)
        {
            CodUsuario = codUsuario;
            Nombre = nombre;
            DNI = dni;
            Tipo = tipo;
            ContraseñaHash = EncriptarContraseña(contraseña);
        }

        public bool ValidarContraseña(string contraseña)
        {
            string contraseñaIngresadaHash = EncriptarContraseña(contraseña);
            return contraseñaIngresadaHash == ContraseñaHash;
        }

        private string EncriptarContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] contraseñaBytes = Encoding.UTF8.GetBytes(contraseña);
                byte[] hashBytes = sha256.ComputeHash(contraseñaBytes);
                StringBuilder stringBuilder = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
