using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsoCuent
{
    internal class program
    {
        static void Main(string[] args)
        {
            CuentaCorrient Cuenta1 = new CuentaCorrient("Juan Muñoz", 5000);
            CuentaCorrient Cuenta2 = new CuentaCorrient("Emilly", 2000);

            CuentaCorrient.Transferencia(Cuenta1, Cuenta2, 5000);
            Console.WriteLine(Cuenta1.getDatosCuenta());
            Console.WriteLine(Cuenta2.getDatosCuenta());
        }
    }
}
