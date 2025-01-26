// Clase que representa un vehículo
class Vehiculo
{
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Anio { get; set; }
    public decimal Precio { get; set; }
    public Vehiculo Siguiente { get; set; } // Nodo siguiente en la lista enlazada

    public Vehiculo(string placa, string marca, string modelo, int anio, decimal precio)
    {
        Placa = placa;
        Marca = marca;
        Modelo = modelo;
        Anio = anio;
        Precio = precio;
        Siguiente = null;
    }
}

// Clase para la lista enlazada
class ListaVehiculos
{
    private Vehiculo cabeza;

    // Agregar un vehículo
    public void AgregarVehiculo(string placa, string marca, string modelo, int anio, decimal precio)
    {
        Vehiculo nuevo = new Vehiculo(placa, marca, modelo, anio, precio);
        nuevo.Siguiente = cabeza;
        cabeza = nuevo;
        Console.WriteLine("Vehículo agregado.");
    }

    // Buscar vehículo por placa
    public void BuscarVehiculo(string placa)
    {
        Vehiculo actual = cabeza;
        while (actual != null)
        {
            if (actual.Placa == placa)
            {
                Console.WriteLine($"Encontrado: {actual.Placa}, {actual.Marca}, {actual.Modelo}, {actual.Anio}, {actual.Precio:C}");
                return;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine("Vehículo no encontrado.");
    }

    // Ver todos los vehículos
    public void VerTodosLosVehiculos()
    {
        Vehiculo actual = cabeza;
        if (actual == null)
        {
            Console.WriteLine("No hay vehículos registrados.");
            return;
        }
        while (actual != null)
        {
            Console.WriteLine($"{actual.Placa}, {actual.Marca}, {actual.Modelo}, {actual.Anio}, {actual.Precio:C}");
            actual = actual.Siguiente;
        }
    }

    // Eliminar vehículo por placa
    public void EliminarVehiculo(string placa)
    {
        if (cabeza == null)
        {
            Console.WriteLine("No hay vehículos registrados.");
            return;
        }
        if (cabeza.Placa == placa)
        {
            cabeza = cabeza.Siguiente;
            Console.WriteLine("Vehículo eliminado.");
            return;
        }
        Vehiculo actual = cabeza;
        while (actual.Siguiente != null && actual.Siguiente.Placa != placa)
        {
            actual = actual.Siguiente;
        }
        if (actual.Siguiente != null)
        {
            actual.Siguiente = actual.Siguiente.Siguiente;
            Console.WriteLine("Vehículo eliminado.");
        }
        else
        {
            Console.WriteLine("Vehículo no encontrado.");
        }
    }
}

class Program
{
    static void Main()
    {
        ListaVehiculos lista = new ListaVehiculos();
        int opcion;
        do
        {
            Console.WriteLine("\n1. Agregar vehículo\n2. Buscar vehículo\n3. Ver todos los vehículos\n4. Eliminar vehículo\n5. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Placa: ");
                    string placa = Console.ReadLine();
                    Console.Write("Marca: ");
                    string marca = Console.ReadLine();
                    Console.Write("Modelo: ");
                    string modelo = Console.ReadLine();
                    Console.Write("Año: ");
                    int anio = int.Parse(Console.ReadLine());
                    Console.Write("Precio: ");
                    decimal precio = decimal.Parse(Console.ReadLine());
                    lista.AgregarVehiculo(placa, marca, modelo, anio, precio);
                    break;

                case 2:
                    Console.Write("Placa a buscar: ");
                    string placaBuscar = Console.ReadLine();
                    lista.BuscarVehiculo(placaBuscar);
                    break;

                case 3:
                    lista.VerTodosLosVehiculos();
                    break;

                case 4:
                    Console.Write("Placa a eliminar: ");
                    string placaEliminar = Console.ReadLine();
                    lista.EliminarVehiculo(placaEliminar);
                    break;

                case 5:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 5);
    }
}


