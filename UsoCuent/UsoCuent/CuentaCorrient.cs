using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsoCuent
{
    internal class CuentaCorrient
    {
        private double saldo;
        private string nombreTitular;
        private long numeroCuenta;

        public CuentaCorrient(string nombreTitular, double saldo)
        {
            this.saldo = saldo;
            this.nombreTitular = nombreTitular;

            Random rnd = new Random();
            numeroCuenta = Math.Abs(rnd.Next());
        }
        public void setIngreso(double ingreso){
            if (ingreso < 0)
                Console.WriteLine("No se permiten ingresos negativos");
            else
                saldo += ingreso;
        }

        public void setReintegro(double reintegro)
        {
            saldo -= reintegro;
        }

        protected string getSaldo()
        {
            return "El saldo de la cuenta es: " + saldo;
        }

        public static void Transferencia(CuentaCorrient titul1, CuentaCorrient titul2, double cantidad)
        {
            if (titul1 != null && titul2 != null)
            {
                if (titul1.saldo >= cantidad)
                {
                    titul1.saldo -= cantidad;
                    titul2.saldo += cantidad;
                    Console.WriteLine("¡Transferencia exitosa!");
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente en la cuenta del titular 1");
                }
            }
            else
            {
                Console.WriteLine("Una o ambas cuentas no existen");
            }
        }

        public string getDatosCuenta()
        {
            return "Titular: " + nombreTitular + "\n" + "No cuenta: " + numeroCuenta + "\n" + "Saldo: " + saldo;

        }
    }
}
