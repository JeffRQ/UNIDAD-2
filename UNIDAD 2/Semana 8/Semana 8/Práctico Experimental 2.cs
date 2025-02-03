class Asiento
{
    public int Numero { get; private set; } 
    public bool Ocupado { get; private set; }

    public Asiento(int numero)
    {
        Numero = numero;
        Ocupado = false;
    }

    public void Asignar()
    {
        Ocupado = true;
    }
}

class Atraccion
{
    private Queue<string> colaEspera;
    private List<Asiento> asientos;
    
    public Atraccion(int totalAsientos)
    {
        colaEspera = new Queue<string>();
        asientos = new List<Asiento>();
        
        for (int i = 1; i <= totalAsientos; i++)
        {
            asientos.Add(new Asiento(i));
        }
    }
    
    public void AgregarPersona(string nombre)
    {
        if (colaEspera.Count < asientos.Count)
        {
            colaEspera.Enqueue(nombre);
            Console.WriteLine($"{nombre} ha sido agregado a la cola.");
        }
        else
        {
            Console.WriteLine($"Lo sentimos, {nombre}. No hay asientos disponibles.");
        }
    }
    
    public void AsignarAsientos()
    {
        for (int i = 0; i < asientos.Count && colaEspera.Count > 0; i++)
        {
            if (!asientos[i].Ocupado)
            {
                string persona = colaEspera.Dequeue();
                asientos[i].Asignar();
                Console.WriteLine($"{persona} ha tomado el asiento #{asientos[i].Numero}.");
            }
        }
    }

    public void MostrarEstado()
    {
        Console.WriteLine("Estado de los asientos:");
        foreach (var asiento in asientos)
        {
            Console.WriteLine($"Asiento {asiento.Numero}: {(asiento.Ocupado ? "Ocupado" : "Libre")}");
        }
    }
}

class Program
{
    static void Main()
    {
        Atraccion atraccion = new Atraccion(30);
        
        atraccion.AgregarPersona("Juan");
        atraccion.AgregarPersona("Maria");
        atraccion.AgregarPersona("Carlos");
        
        atraccion.AsignarAsientos();
        atraccion.MostrarEstado();
    }
}