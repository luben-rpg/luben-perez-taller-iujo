using System;
using System.IO; // Espacio de nombres fundamental para manejar archivos y flujos

class Program
{
    static void Main()
    {
        // Definición de las rutas de los archivos
        string origen = "avatar.jpg"; // se busca este archivo dentro de donde se ejecuta nuestro proyecto
        string destino = "respaldo.jpg";// se 
        

        // Validación de existencia: Evita que el programa truene si el archivo no existe
        if (!File.Exists(origen))
        {
            Console.WriteLine("Error: No se encuentra el archivo 'avatar.jpg'");
            Console.WriteLine("asegurate de que la imagen este en la carpeta Reto2");
            return; // Finaliza la ejecución del Main
        }

        Console.WriteLine("iniciando copia ");

        // 'using' asegura que los flujos se cierren y liberen automáticamente al terminar
        // fsLectura: Abre el archivo origen solo para lectura
        // fsEscritura: Crea el archivo destino (si ya existe, lo sobrescribe) solo para escritura
        using (FileStream fsLectura = new FileStream(origen, FileMode.Open, FileAccess.Read))
        using (FileStream fsEscritura = new FileStream(destino, FileMode.Create, FileAccess.Write))
        {
            // El buffer es un "balde" de 1024 bytes (1 KB) para mover datos por partes
            byte[] buffer = new byte[1024];
            int bytesLeidos;

            // El ciclo continúa mientras haya datos que leer en el origen
            // Read devuelve la cantidad de bytes leídos realmente
            while ((bytesLeidos = fsLectura.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Escribe en el destino exactamente la cantidad de bytes que se leyeron del origen
                fsEscritura.Write(buffer, 0, bytesLeidos);
            }
        } // Aquí se cierran ambos FileStreams automáticamente

        Console.WriteLine("> ¡Copia exitosa! El archivo 'respaldo.jpg' ha sido creado.");
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}