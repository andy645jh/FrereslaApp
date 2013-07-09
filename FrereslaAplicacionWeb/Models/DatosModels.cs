using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace FrereslaAplicacionWeb.Models
{
    public class DatosModels
    {
        //static public MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["freresdb"].ToString());

      
        public static bool UsuarioValido(string user, string pass)
        {
            //LoginModel usuario = new LoginModel();
/*
            bool autenticado = false;
            string query = string.Format("select NombreUsuario,Password,NombreCompleto from usuarios where NombreUsuario='{0}' and Password='{1}'", user, pass);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader datosLeidos = cmd.ExecuteReader();
            autenticado = datosLeidos.HasRows;

            datosLeidos.Read();
            usuario.NombreCompleto= datosLeidos["NombreCompleto"].ToString();
            usuario.UserName = datosLeidos["NombreUsuario"].ToString();
            
            conn.Close(); */
           
            return false;        

        }
    }
}