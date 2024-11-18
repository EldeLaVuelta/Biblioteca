using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polimorfismo
{
    abstract class vendedor
    {
        public string nombre  { get; set; }
        public decimal ventasTotales {  get; set; }

        protected vendedor(string nombre, decimal ventasTotales)
        {
            this.nombre = nombre;
            this.ventasTotales = ventasTotales;
        }

        public abstract decimal calcularComision();
    }
}
