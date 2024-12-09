using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.IO;
using System;

namespace RegistroEpidemiologico.Controllers
{

    public class ImagenController : Controller
    {
        private readonly string _connectionString = "server=HDHVCA;database=SGHRH;User ID=alan;Password=alan;TrustServerCertificate=True";
        // Acción para mostrar la imagen en una vista
        public IActionResult MostrarImagen()
        {
            try
            {
                string query = "SELECT imagen1 FROM historia_auditoria WHERE dni_paciente = '73381684'";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] imageData = reader["imagen1"] as byte[];

                            if (imageData != null && imageData.Length > 0)
                            {
                                string base64Image = Convert.ToBase64String(imageData);
                                return Json(new { Image = base64Image }); // Devolver la imagen como JSON
                            }
                            else
                            {
                                return NotFound("No se encontró la imagen.");
                            }
                        }
                        else
                        {
                            return NotFound("No se encontraron registros con el DNI especificado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
