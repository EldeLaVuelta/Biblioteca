// See https://aka.ms/new-console-template for more information
Console.WriteLine("Bienvenidos");
{
    string clave = "juan";
    string acceso = "";

    do
    {
        Console.WriteLine("Ingrese la clave: ");
        acceso = Console.ReadLine();
        if (!clave.Equals(acceso,StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Constraseña incorrecta");
        }
    }
    while (!clave.Equals(acceso,StringComparison.OrdinalIgnoreCase));
    {
        Console.WriteLine("Bienvenido al sistema");
    }
        
    
}
