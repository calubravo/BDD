using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioVentas.NewFolder
{
    internal class Vendedor
    {     
        public int Id { get; set; }
        public DateTime  Fecha { get; set;}
        public string Codigo { get; set;} 
        public decimal Venta { get; set; }
        public bool VentaEmpresaGrande { get; set; }
   
    }




}
