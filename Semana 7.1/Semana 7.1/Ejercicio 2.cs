class Elemento
{
    public int Valor; // Valor almacenado en el nodo
    public Elemento Siguiente; // Referencia al siguiente nodo en la lista

    // Constructor que inicializa el nodo con un valor y sin siguiente nodo
    public Elemento(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

class ListaNumeros
{
    private Elemento cabeza; // Primer elemento de la lista

    // Método para agregar un nuevo valor al final de la lista
    public void Agregar(int valor)
    {
        Elemento nuevoElemento = new Elemento(valor);
        if (cabeza == null) // Si la lista está vacía
        {
            cabeza = nuevoElemento; // El nuevo elemento se convierte en la cabeza
        }
        else // Si la lista no está vacía
        {
            Elemento actual = cabeza;
            while (actual.Siguiente != null) // Recorrer hasta el último elemento
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoElemento; // Agregar el nuevo elemento al final
        }
    }

    // Método para mostrar todos los valores de la lista
    public void Mostrar()
    {
        Elemento actual = cabeza;
        while (actual != null) // Recorrer la lista hasta el final
        {
            Console.Write(actual.Valor + " "); // Imprimir el valor del elemento actual
            actual = actual.Siguiente;
        }
        Console.WriteLine(); // Línea en blanco al final
    }

    // Método para eliminar elementos fuera de un rango específico
    public void EliminarFueraDeRango(int min, int max)
    {
        // Eliminar elementos al inicio que estén fuera del rango
        while (cabeza != null && (cabeza.Valor < min || cabeza.Valor > max))
        {
            cabeza = cabeza.Siguiente; // Mover la cabeza al siguiente elemento
        }

        // Eliminar elementos en el resto de la lista
        Elemento actual = cabeza;
        while (actual != null && actual.Siguiente != null)
        {
            if (actual.Siguiente.Valor < min || actual.Siguiente.Valor > max)
            {
                // Saltar el elemento que está fuera del rango
                actual.Siguiente = actual.Siguiente.Siguiente;
            }
            else
            {
                actual = actual.Siguiente; // Avanzar al siguiente elemento
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random(); // Generador de números aleatorios
        ListaNumeros lista = new ListaNumeros(); // Crear una nueva lista enlazada

        // Generar 50 números aleatorios entre 1 y 999 y agregarlos a la lista
        for (int i = 0; i < 50; i++)
        {
            lista.Agregar(random.Next(1, 1000));
        }

        // Mostrar la lista original
        Console.WriteLine("Lista original:");
        lista.Mostrar();

        // Pedir al usuario que ingrese los valores mínimo y máximo del rango
        Console.Write("Ingrese el valor mínimo del rango: ");
        int min = int.Parse(Console.ReadLine()); // Leer el valor mínimo

        Console.Write("Ingrese el valor máximo del rango: ");
        int max = int.Parse(Console.ReadLine()); // Leer el valor máximo

        // Eliminar elementos que estén fuera del rango especificado
        lista.EliminarFueraDeRango(min, max);

        // Mostrar la lista después de eliminar los elementos fuera del rango
        Console.WriteLine("Lista después de eliminar elementos fuera del rango:");
        lista.Mostrar();
    }
}
