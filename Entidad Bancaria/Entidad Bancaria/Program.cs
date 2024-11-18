// See https://aka.ms/new-console-template for more information
Console.WriteLine("Bienvenido a Bancolombia");
{
    int option = 0;
    bool isValidationOption = false;

    //crear menú
    while (!isValidationOption)
    {
        Console.WriteLine("Menú de opciones: ");
        Console.WriteLine("1. Servicio de caja");
        Console.WriteLine("2. Servicio al cliente");
        Console.WriteLine("3. Pago de impuestos");
        Console.WriteLine("4. Crédito hipotecario");
        Console.WriteLine("5. Operaciones con targeta de crédito");
        Console.WriteLine("Ingrese la opción: ");
        string input = Console.ReadLine();

        //verifica si el input es un numero valido y si está ente 1 y 5
        if (int.TryParse(input, out option) && option >= 1 && option <= 5)
        {
            isValidationOption = true;
        }
        else
        {
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción entre 1 y 5");
        }
    }
    Random random = new Random();
    int ticketNumber = random.Next(100000, 999999);
    int branchId = 1234; //asigna el id de la sucursal correcto

    string service = string.Empty;
    switch (option)
    {
        case 1:
            service = "Servicio de caja";
            break;
        case 2:
            service = "Servicio al cliente";
            break;
        case 3:
            service = "Pago de impuestos";
            break;
        case 4:
            service = "Crédito hipotecario";
            break;
        case 5:
            service = "Operaciones con targeta de crédito";
            break;
    }

    DateTime currentDate = DateTime.Now;

    Console.WriteLine($"Ticket: {ticketNumber}");
    Console.WriteLine($"ID de sucursal {branchId}");
    Console.WriteLine($"Servicio seleccionado: {service}");
    Console.WriteLine($"Fecha y hora: {currentDate}");
}
