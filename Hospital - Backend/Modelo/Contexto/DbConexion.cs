 using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    public partial class DbConexion : DbContext
    {
        private DbConexion(string stringConexion) : //Constructor para la conexión con la DB
            base(stringConexion)
        {
            this.Configuration.LazyLoadingEnabled = false; //No se cargan los objetos relacionados entre si
            this.Configuration.ProxyCreationEnabled = false; //Idem 
            this.Database.CommandTimeout = 900; //Tiempo de espera a acceso de DB.(segs)
        }

        public static DbConexion Create() //Método para la creacion de la conexión
        {
            return new DbConexion("name=DbConexion"); 
        }
    }
}
