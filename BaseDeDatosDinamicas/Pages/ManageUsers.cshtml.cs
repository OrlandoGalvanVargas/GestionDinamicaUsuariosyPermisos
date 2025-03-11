using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace BaseDeDatosDinamicas.Pages
{
    public class ManageUsersModel : PageModel
    {
        private readonly IConfiguration _configuration;

        [BindProperty]
        public UserModel UserModel { get; set; } = new UserModel();

        public ManageUsersModel(IConfiguration configuration)
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
                using (SqlCommand command = new SqlCommand("GestionarUsuario", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", UserModel.Username);
                    command.Parameters.AddWithValue("@Password", UserModel.Password);
                    command.Parameters.AddWithValue("@DatabaseName", UserModel.DatabaseName);
                    command.Parameters.AddWithValue("@Permissions", UserModel.Permissions);

                    command.ExecuteNonQuery();
                }
            }

            TempData["Message"] = "Usuario creado exitosamente.";
            return RedirectToPage("ManageUsers");
        }
    }

    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public string Permissions { get; set; }
    }
}