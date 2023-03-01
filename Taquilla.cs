using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_LC
{
    public class Taquilla
    {
        static void Main(string[] args)
        {
            string exit = string.Empty;
            while (exit == "")
            {
                Console.WriteLine("¡Bienvenido!");
                Console.WriteLine(@"Por favor ingrese la ruta donde se encuentran los archivos de invitados: "); // C:\Users\maria\source\repos\Parcial1_LC\Archivos_parcial1
                string filePath = Console.ReadLine();

                ManejoArchivos objManejo = new ManejoArchivos();
                List<string> dataList = objManejo.ReadFile(@filePath); //llevar archivo seleccionado a una lista

                Console.WriteLine(@"Por favor ingrese el correo electronico del asistente: ");
                string email = Console.ReadLine();

                Validador invitado = new Validador();
                invitado.ListInvitados = objManejo.GetListaInvitados(dataList);

                bool existe = invitado.ValidarExistencia(email);
               
                if (existe)
                {
                    bool mayorEdad = invitado.ValidarEdad(email);
                    if (mayorEdad)
                    {
                        bool formatoEmailCorrecto = invitado.ValidarEmail(email);
                        if (formatoEmailCorrecto)
                        {
                            Console.WriteLine("El asistente cumple con todas las condiciones de validación, es un invitado.");
                        }
                    }
                }
                Console.WriteLine("Para salir del programa oprima el caracter 'S' y luego la tecla Enter, sino, solo oprima la tecla Enter y podrá realizar una nueva búsqueda.");
                exit = Console.ReadLine();
            }
            Console.WriteLine("Programa finalizado...");
        }
    }
}
