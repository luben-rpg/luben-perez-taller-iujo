using System;
using System.IO; 

class Program
{
    static void Main()
    {
        
        string registro = "usuario; ClaveSegura123";

        string[] partes = registro.Split(';');
        string usuario = partes[0].Trim();
        string clave = partes[1].Trim();

        if (clave.Contains("123"))
        {

            using (StreamWriter sw = new StreamWriter("seguridad.txt", true))
            {
                sw.WriteLine("atencion: clave debil detectada para: " + usuario);
            }
            Console.WriteLine("-->  Registro guardado exitosamente en seguridad.txt");
        }

        Console.WriteLine("====== PROCESO FINALIZADO ======");
        Console.WriteLine("presione cualquier tecla para salir");
        Console.ReadKey();
    }
}