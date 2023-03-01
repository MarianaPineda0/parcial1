using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parcial1_LC
{
    public class Validador
    {
        public List<Invitado> ListInvitados { get; set; }
        public bool ValidarExistencia(string email)
        {
            bool existe = true;
            var existAsistente = ListInvitados.Find(x => x.Email == email);  //verificar que el email ingresado está en los datos

            if (existAsistente ==  null)
            {
                existe = false;
                Console.WriteLine("El asistente con correo electrónico: " + email + " no existe en la lista de invitados");
            }
            return existe;
        }

        public bool ValidarEdad(string email)
        {
            bool mayorEdad = true;
            var mayorAsistente = ListInvitados.Find(x => x.Email == email && x.Edad >= 18); //Verificar email en la lista y si es mayor de edad

            if (mayorAsistente == null)
            {
                mayorEdad = false;
                Console.WriteLine("El invitado con correo electrónico: " + email + " no es mayor de edad.");
                Console.WriteLine("¿Desea llamar a Hackerman?");
            }
            return mayorEdad;
        }

        public bool ValidarEmail(string email)
        {
            //V1. Caracter Alfabético
            Regex regex = new Regex("^[a-zA-Z]"); // compiladores/expresión regular de A a Z en min y may 
            if (!regex.IsMatch(email))
            {
                Console.WriteLine("El correo electrónico: " + email + " no es válido. Verificar que el correo comience con un carácter alfabético.");
                Console.WriteLine("¿Desea llamar a Hackerman?");
                return false;
            }

            //V2. Conector @
            if (email.Split('@').Length != 2) //si hay más de 2 @
            {
                Console.WriteLine("El correo electrónico: " + email + " no es válido. Verificar que el correo tenga el conector @.");
                Console.WriteLine("¿Desea llamar a Hackerman?");
                return false;
            }

            //V3. Dominio
            string dominio = email.Split('@')[1].Split('.')[0];
            string[] dominiosValidos = { "gmail", "hotmail", "live" };
            if (Array.IndexOf(dominiosValidos, dominio) == -1)
            {
                Console.WriteLine("El correo electrónico: " + email + " no es válido. Los dominios válidos son: (gmail, hotmail, live)");
                Console.WriteLine("¿Desea llamar a Hackerman?");
                return false;
            }

            //V4. Terminación
            string patron = @"\.([a-zA-Z]{2,5})$";
            Match match = Regex.Match(email, patron);

            if (match.Success)
            {
                string terminacion = match.Groups[1].Value;
                // Lista de terminaciones permitidas
                string[] terminacionesPermitidas = { ".com", ".co", ".edu.co", ".org" };
                return Array.IndexOf(terminacionesPermitidas, terminacion) != -1;
            }
            else
            {
                Console.WriteLine("El correo electrónico: " + email + " no es válido. Las terminaciones válidas son: (.com, .co, .edu.co, .org)");
                Console.WriteLine("¿Desea llamar a Hackerman?");
                return false;
            }

            Console.WriteLine("El correo electrónico: " + email + " es válido.");

            // Si todas las condiciones son verdaderas, entonces el correo electrónico es válido.
            return true;
        }
    }
}
