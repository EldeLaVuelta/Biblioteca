// See https://aka.ms/new-console-template for more information
Console.WriteLine("Bienvenidos a la gestión de Seguridad y Movilidad");
{
    Random random = new Random();
    int velocidadCaptada = random.Next(0, 120);
    string zona;
    int velocidadMaxima;

    if (velocidadCaptada <= 30)
    {
        zona = "Zona Escolar";
        velocidadMaxima = 30;
    }
    else if (velocidadCaptada <= 60)
    {
        zona = "Vias Urbanas";
        velocidadMaxima = 60;
    }
    else if (velocidadCaptada <= 80)
    {
        zona = "Vias Rurales";
        velocidadMaxima = 80;
    }
    else
    {
        zona = "Rutas Nacionales";
        velocidadMaxima = 100;
    }
    Console.WriteLine("Fecha y hora e la lectura ", DateTime.Now);
    Console.WriteLine("Estás transitando en {0} a una velocidad de {1} km/h", zona, velocidadCaptada);
    Console.WriteLine("La velocidad máxima permitida en esta zona es de {0} km/h", velocidadMaxima);
}
