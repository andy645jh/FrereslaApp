using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrereslaAplicacionWeb.Models.Menu
{
    public class Permiso
    {
        public Boolean Habilitado { get; set; }
        public int IdPermiso { get; set; }

        public Permiso(int _idPermiso,Boolean _habilitado)
        {
            IdPermiso = _idPermiso;
            Habilitado = _habilitado;
        }
    }
}