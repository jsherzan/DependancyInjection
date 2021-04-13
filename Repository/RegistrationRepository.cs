using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validation.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Validation.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IConfiguration _configuration;
        public RegistrationRepository( IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SaveRegistration(RegistraionModel model)
        {
            string connectionString = _configuration.GetConnectionString("registrationConnection");

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_insert", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("Address", model.Address);
                    cmd.Parameters.AddWithValue("PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("Email", model.Email);
                    cmd.Parameters.AddWithValue("Age", model.Age);
                    cmd.Parameters.AddWithValue("ContactPreference", model.ContactPreference);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
