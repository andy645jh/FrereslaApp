using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FrereslaAplicacionWeb.Models
{
    public class LoginModel
    {
            [Required]
            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            public string NombreCompleto { get; set; }            
            public bool RememberMe { get; set; }
            static public MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["freresdb"].ToString());

            public LoginModel()
            {
                
                 
            }

            public bool validarUsuario(string user,string pass)
            {
                bool autenticado = false;
                string query = string.Format("select NombreUsuario,Password,NombreCompleto from usuarios where NombreUsuario='{0}' and Password='{1}'", user, pass);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader datosLeidos = cmd.ExecuteReader();
                autenticado = datosLeidos.HasRows;

                if (autenticado)
                {
                    datosLeidos.Read();
                    NombreCompleto = datosLeidos["NombreCompleto"].ToString();                    
                    UserName = datosLeidos["NombreUsuario"].ToString();
                }           

                conn.Close();                
                return autenticado;
            }


    }
}