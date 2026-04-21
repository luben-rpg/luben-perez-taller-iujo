using System;
using System.IO; // Necesario para trabajar con entrada y salida de archivos (StreamWriter)

class Program
{
    static void Main()
    {
        // Definición de una cadena simulando un registro de entrada
        string registro = "usuario ; ClaveSegura123";

        // Divide la cadena en un array utilizando el punto y coma como separador
        // partes[0] tendrá "usuario" y partes[1] tendrá " ClaveSegura123"
        string[] partes = registro.Split(';');

        // .Trim() elimina los espacios en blanco accidentales al inicio o al final
        string usuario = partes[0].Trim();
        string clave = partes[1].Trim();

        // Validación: Verifica si la contraseña contiene la secuencia débil "123"
        if (clave.Contains("123"))
        {
            // Bloque 'using' asegura que el archivo se cierre y libere correctamente al terminar
            // El parámetro 'true' en StreamWriter indica que se hará un "Append" (añadir al final)
            // en lugar de sobrescribir el archivo existente.
            using (StreamWriter sw = new StreamWriter("seguridad.txt", true))
            {
                // Escribe una línea de advertencia en el archivo de texto
                sw.WriteLine("atencion: clave debil detectada para: " + usuario);
            }

            // Informa al usuario por consola que se ha generado la alerta
            Console.WriteLine("-->  Registro guardado exitosamente en seguridad.txt");
        }

        // Mensajes de cierre de la aplicación
        Console.WriteLine("====== PROCESO FINALIZADO ======");
        Console.WriteLine("presione cualquier tecla para salir");
        
        // Detiene la ejecución hasta que el usuario presione una tecla
        Console.ReadKey();
    }
}