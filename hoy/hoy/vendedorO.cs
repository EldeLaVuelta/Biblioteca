using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polimorfismo
{
    internal class vendedorO : vendedor
    {
        public vendedorO(string nombre, decimal ventasTotal) : base(nombre, ventasTotal)
        {

        }

        public override decimal calcularComision()
        {
            return ventasTotales = 0.15m;
        }
    }
}
