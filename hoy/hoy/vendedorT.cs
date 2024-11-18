using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polimorfismo
{
    internal class vendedorT : vendedor
    {
        public vendedorT(string nombre, decimal ventasTotales) : base(nombre, ventasTotales) 
        { 

        }

        public override decimal calcularComision()
        {
            return ventasTotales = 0.10m;
        }
    }
}
