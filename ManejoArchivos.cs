using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_LC
{
    public class ManejoArchivos
    {
       
        public List<Invitado> GetListaInvitados(List<string> dataList)
        {
            List<Invitado> dataListInv = new List<Invitado>(); //lista vacía

            dataList.RemoveAt(0); //elimino el encabezado
            foreach (string data in dataList) //iterar en dataList
            {
                var dataClean = data.Replace("\t", ",").Replace("**", ","); // reemplazar "\t" y "**" por ","
                string[] currentData = dataClean.Split(",");
                //retorna arreglo currentData = ["Adel", "45196682", "y3l-UUolINBgDN.com", "81"] -> asignar por posiciones a currentInvitado

                Invitado currentInvitado = new Invitado(); //asignar atributos 
                currentInvitado.Nombre = currentData[0];
                currentInvitado.Id = int.Parse(currentData[1]); //convertir a entero
                currentInvitado.Email = currentData[2];
                currentInvitado.Edad = int.Parse(currentData[3]);

                dataListInv.Add(currentInvitado); //agregar cada currentInvitado a la lista vacía
            }
            return dataListInv; // [{Nombre="Adel",  Id=45196682, Email="y3l-UUolINBgDN.com", Edad=81 }, info de otros invitados]
            //lista con datos ya separados
        }

       
        public List<string> ReadFile(string filepath)
        {
            //string randomFilePath = SelectRandomFileFromDirectory(filepath); //seleccionar archivo al azar dentro de la carpeta
            string extension = Path.GetExtension(filepath).ToLower(); // obtener la extension del archivo
            List<string> dataList = ReadFileToList(filepath, extension); //leer archivo y llevarlo a la lista

            Console.WriteLine(@"El archivo seleccionado es:" + filepath);
            Console.WriteLine(@"Los datos del archivo son:");

            foreach (string data in dataList) //iterar para mostrar datos
            {
                Console.WriteLine(data);
            }
            return dataList;

        }

        //public string SelectRandomFileFromDirectory(string directorypath)
        
            //Random random = new Random(); //inicializar obj
            //string[] file = Directory.GetFiles(directorypath); //lista de archivos [file1, file2]
            //string randomFilePath = file[random.Next(file.Length)]; //ruta del archivo random
            //return randomFilePath; //retornar ruta 
        

        public List<string> ReadFileToList(string filepath, string extension)
        {
            switch (extension)
            {
                case ".txt":
                    return File.ReadAllLines(filepath).ToList(); //De texto a lista de datos
                case ".csv":
                    return File.ReadAllLines(filepath).ToList(); //De texto a lista de datos
                default:
                    throw new Exception("Formato del archivo no es compatible"); //lanzar una excepción si el formato del archivo no es compatible
            }
        }
    }
}
