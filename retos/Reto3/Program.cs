using System;
using System.IO;

class Program
{
    static void Main()
    {
        string rutaCarpeta = Directory.GetCurrentDirectory();
        
        Console.WriteLine("--- Iniciando limpieza de archivos pesados en la carpeta ---");
        
        string[] archivos = Directory.GetFiles(rutaCarpeta);

        foreach (string ruta in archivos)
        {
            FileInfo info = new FileInfo(ruta);

            
            if (info.Length > 5120)
            {
                
                if (info.Name != "program.cs" && !info.Name.EndsWith(".exe"))
                {
                    File.Delete(ruta);
                    Console.WriteLine("eliminado: " + info.Name + " (" + info.Length + " bytes)");
                }
            }
            else 
            {
                Console.WriteLine("conservado: " + info.Name + " (Peso OK)");
            }
        }

        Console.WriteLine("=== limpieza terminada ===");
        Console.WriteLine("Presione una tecla para salir");
        Console.ReadKey();
    }
}