using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;
using System.IO;

namespace CAPA_DATOS
{
    class Program
    {
        static void Main()
        {
            try
            {
                string connectionString = "server=HDHVCA;database=SGHRH;User ID=alan;Password=alan;TrustServerCertificate=True";
                string query = "SELECT imagen1 FROM historia_auditoria WHERE dni_paciente = @Id"; // Reemplaza con tu consulta SQL

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", 73381684); // Puedes cambiar el parámetro según sea necesario

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Leer el campo 'imagen1' como un arreglo de bytes
                            byte[] imageData = reader["imagen1"] as byte[];

                            if (imageData != null && imageData.Length > 0)
                            {
                                // Especificar la ruta para guardar la imagen
                                string filePath = "output_image.jpg";

                                // Guardar la imagen como archivo
                                File.WriteAllBytes(filePath, imageData);
                                Console.WriteLine($"Imagen guardada en: {filePath}");
                            }
                            else
                            {
                                Console.WriteLine("La columna 'imagen1' está vacía o no contiene datos.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron registros con el DNI especificado.");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"Error de SQL: {sqlEx.Message}");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"Error de E/S: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
            }
        }
    }
}
