// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

{
    Console.WriteLine("Bienvenidos");
    //declarar variablses
    double ventaMed = 1000;
    double ventaBog = 128643.4778;
    double ventaCal = 1500;
    double ventaTot = 0;
    double promedio = 0;

    //operaciones
    DateTime fecha = DateTime.Now;
    DateTime fechaHoy = DateTime.Today;
    DateTime formatoCorto = DateTime.Today;
    
    ventaTot = ventaMed + ventaBog + ventaCal;
    promedio = ventaTot / 3;
    Console.WriteLine($"La venta total es: { ventaTot:N2}");
    Console.WriteLine($"El promedio es: { promedio:c}");


    //salidas
    Console.WriteLine("La venta máxima entre medelin y bogotá es: " + Math.Max(ventaCal, ventaMed));
    Console.WriteLine("La venta mínima entre medelin y bogotá es: " + Math.Min(ventaCal, ventaMed));
    Console.WriteLine("La fecha actual con Now es: " + fecha);
    Console.WriteLine("La fecha de hoy con Today es: " + fechaHoy);
    Console.WriteLine("La fecha actual con ToString es: " + formatoCorto.ToString("dd-MM-yyyy"));
    Console.WriteLine("Cargando...");
    Thread.Sleep(6000);
    Console.Beep(10000, 6000);

    //redondear
    Console.WriteLine("El valor de la venta redondeado con Ceiling: " + Math.Ceiling(ventaTot));
    Console.WriteLine("El valor de la venta redondeado con Floor: " + Math.Floor(ventaTot));
    Console.WriteLine("El valor de la venta redondeado con Round: " + Math.Round(ventaTot));

}
