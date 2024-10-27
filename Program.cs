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

        // Guardar el resultado en SQL Server
        SaveBase64ToDatabase("chispis.jpg", base64String);

        Console.WriteLine(base64String);
    }

    static string ConvertFileToBase64(string filePath)
    {
        // Leer el archivo como bytes
        byte[] fileBytes = File.ReadAllBytes(filePath);

        // Convertir a base64
        return Convert.ToBase64String(fileBytes);
    }

    static void SaveBase64ToDatabase(string fileName, string base64Content)
    {
        // Cadena de conexión a SQL Server
        string connectionString = "Server=;Database=;User Id=;Password=;";

        // Consulta de inserción
        string query = "INSERT INTO ArchivosBase64 (NombreArchivo, Base64Contenido) VALUES (@FileName, @Base64Content)";

        // Conectar y ejecutar la consulta
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@FileName", fileName);
            command.Parameters.AddWithValue("@Base64Content", base64Content);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        Console.WriteLine("Archivo guardado en la base de datos exitosamente.");
    }
}
