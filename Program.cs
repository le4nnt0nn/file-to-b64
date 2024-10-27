using System;
using System.Data.SqlClient;
using System.IO;

class Program
{
    static void Main()
    {
        // Ruta del archivo físico
        string filePath = @"C:\temp\chispis.jpg";

        // Leer y convertir el archivo a base64
        string base64String = ConvertFileToBase64(filePath);

        Console.WriteLine(base64String);
    }

    static string ConvertFileToBase64(string filePath)
    {
        // Leer el archivo como bytes
        byte[] fileBytes = File.ReadAllBytes(filePath);

        // Convertir a base64
        return Convert.ToBase64String(fileBytes);
    }
}
