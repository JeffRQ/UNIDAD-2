class Program
{
    static void Main()
    {
        // Ejercicio 1
        Console.WriteLine("Ejercicio 1: Asignaturas del curso");
        List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        Console.WriteLine("Las asignaturas del curso son:");
        Console.WriteLine(string.Join(", ", asignaturas));
        Console.WriteLine();

        // Ejercicio 2
        Console.WriteLine("Ejercicio 2: Números del 1 al 10 en orden inverso");
        List<int> numeros = Enumerable.Range(1, 10).ToList();
        numeros.Reverse();
        Console.WriteLine("Números en orden inverso: " + string.Join(", ", numeros));
        Console.WriteLine();

        // Ejercicio 3
        Console.WriteLine("Ejercicio 3: Contar vocales en una palabra");
        Console.Write("Introduce una palabra: ");
        string palabra = Console.ReadLine().ToLower();
        Dictionary<char, int> conteoVocales = new Dictionary<char, int>
        {
            { 'a', 0 }, { 'e', 0 }, { 'i', 0 }, { 'o', 0 }, { 'u', 0 }
        };
        foreach (char letra in palabra)
        {
            if (conteoVocales.ContainsKey(letra))
            {
                conteoVocales[letra]++;
            }
        }
        Console.WriteLine("Número de vocales en la palabra:");
        foreach (var kvp in conteoVocales)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        Console.WriteLine();

        // Ejercicio 4
        Console.WriteLine("Ejercicio 4: Menor y mayor precio");
        List<int> precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };
        int menorPrecio = precios.Min();
        int mayorPrecio = precios.Max();
        Console.WriteLine($"Menor precio: {menorPrecio}");
        Console.WriteLine($"Mayor precio: {mayorPrecio}");
        Console.WriteLine();

        // Ejercicio 5
        Console.WriteLine("Ejercicio 5: Producto escalar de vectores");
        List<int> vector1 = new List<int> { 1, 2, 3 };
        List<int> vector2 = new List<int> { -1, 0, 2 };
        int productoEscalar = 0;
        for (int i = 0; i < vector1.Count; i++)
        {
            productoEscalar += vector1[i] * vector2[i];
        }
        Console.WriteLine($"El producto escalar de los vectores es: {productoEscalar}");
        Console.WriteLine();
    }
}

