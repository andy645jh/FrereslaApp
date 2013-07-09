using FrereslaAplicacionWeb.Models.Menu;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FrereslaAplicacionWeb.Models
{
    public class MenuLateralModels
    {
        public bool VerAdministrativas { get ; set; }
        public bool VerParametros { get; set; }
        public bool VerUsuarios { get; set; }        
        public List<Permiso> listaPermisos { get; set; }

        public MenuLateralModels(string name)
        {
            VerParametros = false;
            VerAdministrativas = false;
            VerUsuarios = false;
            var conn = LoginModel.conn;

            var SqlUserName = string.Format("Select NombreCompleto, idUsuarios From usuarios Where NombreUsuario ='{0}'", name);           
            MySqlCommand cmd = new MySqlCommand(SqlUserName, LoginModel.conn);
            conn.Open();
            MySqlDataReader datosLeidos = cmd.ExecuteReader();           

            datosLeidos.Read();
            var IdUsuario = datosLeidos["idUsuarios"];
            conn.Close(); 

            //consultar permisos
            var sqlPermisos = string.Format("Select idPermisos,Habilitado From permisos Where idUsuario={0} ",IdUsuario);
            cmd=new MySqlCommand(sqlPermisos,conn);
            conn.Open();
            MySqlDataReader permisos = cmd.ExecuteReader();

            //inicializar la lista
            listaPermisos = new List<Permiso>();

            //recorremos los registros
            while (permisos.Read())
            {
                int idPermisos=Convert.ToInt32(permisos["idPermisos"]);
                bool habilitado = Convert.ToBoolean(permisos["Habilitado"]);

                //agregamos los datos a la lista
                var permiso = new Permiso(idPermisos, habilitado);
                listaPermisos.Add(permiso);

                if ( idPermisos== 11 || idPermisos == 13 || idPermisos == 15)
                {
                    // Seccion de Administracion
                    if (habilitado == true)
                    {
                        VerAdministrativas = true;
                    }
                } 

                if (idPermisos == 1 || idPermisos == 3 || idPermisos == 5 || idPermisos == 17)
                {
                    // Seccion de Parametros
                    if (habilitado == true)
                    {
                        VerParametros = true;
                    }
                }

                if (idPermisos == 7 || idPermisos == 8 || idPermisos == 9)
                {
                    // Seccion de Usuarios
                    if (habilitado == true)
                    {
                        VerUsuarios = true;
                    }
                }
            }

            conn.Close();         
        }
    }

}