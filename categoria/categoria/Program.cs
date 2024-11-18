// See https://aka.ms/new-console-template for more information
Console.WriteLine("Bienvenidos");
{
    Random random = new Random();
    int minimo = 1;
    int maximo = 56;
    int numeroAleatorio = random.Next(1, 56);
    int edad = numeroAleatorio;

    if (edad >= 0 && edad <= 5)
    {
        Console.WriteLine("Pertenece a la categoria Infante");
        Console.WriteLine($"La edad de la persona es: {edad}");
    }
    else if (edad >= 6 && edad <= 10)
    {
        Console.WriteLine("Pertenece a la categoria Niño");
        Console.WriteLine($"La edad de la persona es: {edad}");
    }
    else if (edad >= 11 && edad <= 15)
    {
        Console.WriteLine("Pertenece a la Categoria Pre-adoloscente");
        Console.WriteLine($"La edad de la persona es: {edad}");
    }
    else if (edad >= 16 && edad <= 18)
    {
        Console.WriteLine("Pertenece a la Categoria Adolescente");
        Console.WriteLine($"La edad de la persona es: {edad}");
    }
    else if (edad >= 19 &&  edad <= 25)
    {
        Console.WriteLine("Pertenece a la Categoria Pre-adulto");
        Console.WriteLine($"La edad de la persona es: {edad}");
    }
    else if (edad >= 26 && edad <= 40)
    {
        Console.WriteLine("Pertenece a la Categoria Adulto");
        Console.WriteLine($"La edad de la persona es: {edad}");
    }
    else if (edad >= 41 && edad <= 55)
    {
        Console.WriteLine("Pertenece a la Categoria Pre-anciano");
        Console.WriteLine($"La edad de la persona es: {edad}");
    }
    else
    {
        Console.WriteLine("Pertenece a la Categoria Anciano");
        Console.WriteLine($"La edad de la persona es: {edad}");
    }
}
