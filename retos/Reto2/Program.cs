using System;
using System.IO;

class Program
{
    static void Main()
    {
        string origen = "avatar.jpg";
        string destino = "respaldo.jpg";

        if (!File.Exists(origen))
        {
            Console.WriteLine("Error: No se encuentra el archivo 'avatar.jpg'");
            Console.WriteLine("asegurate de que la imagen este en la carpeta Reto2");
            return;
        }

        Console.WriteLine("iniciando copia ");

        using (FileStream fsLectura = new FileStream(origen, FileMode.Open, FileAccess.Read))
        using (FileStream fsEscritura = new FileStream(destino, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[1024];
            int bytesLeidos;

            while ((bytesLeidos = fsLectura.Read(buffer, 0, buffer.Length)) > 0)
            {
                fsEscritura.Write(buffer, 0, bytesLeidos);
            }
        }

        Console.WriteLine("> ¡Copia exitosa! El archivo 'respaldo.jpg' ha sido creado.");
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}