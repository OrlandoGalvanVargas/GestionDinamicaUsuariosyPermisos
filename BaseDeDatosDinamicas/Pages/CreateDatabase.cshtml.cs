using BaseDeDatosDinamicas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace BaseDeDatosDinamicas.Pages
{
    public class CreateDatabaseModel : PageModel
    {
        private readonly IConfiguration _configuration;

        [BindProperty]
        public DatabaseCreationModel DatabaseModel { get; set; }

        // Inyectar IConfiguration en el constructor
        public CreateDatabaseModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("CrearBaseDeDatosDinamica", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NombreDB", DatabaseModel.NombreDB);
                    command.Parameters.AddWithValue("@RutaMDF", DatabaseModel.RutaMDF);
                    command.Parameters.AddWithValue("@TamanioInicialMDF", DatabaseModel.TamanioInicialMDF);
                    command.Parameters.AddWithValue("@CrecimientoMDF", DatabaseModel.CrecimientoMDF);
                    command.Parameters.AddWithValue("@RutaLDF", DatabaseModel.RutaLDF);
                    command.Parameters.AddWithValue("@TamanioInicialLDF", DatabaseModel.TamanioInicialLDF);
                    command.Parameters.AddWithValue("@CrecimientoLDF", DatabaseModel.CrecimientoLDF);

                    command.ExecuteNonQuery();
                }
            }

            TempData["Message"] = "Base de datos creada exitosamente.";
            return RedirectToPage("CreateDatabase");
        }
    }
}