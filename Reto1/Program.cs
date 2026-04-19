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
            //
            // Usamos el bloque 'using' para devolver el archivo al sistema
            using (StreamWriter sw = new StreamWriter("seguridad.txt", true))
            {
                sw.WriteLine("Atencion: Clave Debil detectada para: " + usuario);
            }
            Console.WriteLine("-->Registro guardado exitosamente en seguridad.txt");
        }

        Console.WriteLine("====== PROCESO FINALIZADO ======");
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }
}