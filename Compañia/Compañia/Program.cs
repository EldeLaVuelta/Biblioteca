// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Bienvenidos al sistema de Gestión para convercion de su Salario");
Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");
{
    Console.WriteLine("Ingrese su salario: ");
    double pesos = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");


    //Convercion a dolar
    Console.WriteLine("Ingrese el cambio en dolar: ");
    double cambioDolar = Convert.ToDouble(Console.ReadLine());
    double dolar = pesos / cambioDolar;
    Console.WriteLine($"Su salario en dolar es: {dolar}");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");

    //Convercion a euros
    Console.WriteLine("Ingrese el cambio a euros: ");
    double cambioEuro = Convert.ToDouble(Console.ReadLine());
    double euros = pesos / cambioEuro;
    Console.WriteLine($"Su salario en euros es: {euros}");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");

    Console.WriteLine("Programa creado por Juan Daniel Muñoz, Ingeniero de sistemas de Google, Inc");
    Console.WriteLine("Derechos reservados por el mismo");
}
