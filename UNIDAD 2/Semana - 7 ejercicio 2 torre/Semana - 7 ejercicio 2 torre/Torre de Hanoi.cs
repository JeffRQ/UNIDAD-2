class Program
{
    // Método para resolver las Torres de Hanói utilizando una pila iterativa
    static void ResolverTorresDeHanoi(int discos, string origen, string destino, string auxiliar)
    {
        // Pila para almacenar el estado de la ejecución (número de discos y los nombres de las torres)
        Stack<Tuple<int, string, string, string>> pila = new Stack<Tuple<int, string, string, string>>();

        // Empujar el estado inicial a la pila
        pila.Push(Tuple.Create(discos, origen, destino, auxiliar));

        // Mientras haya elementos en la pila, procesar cada estado
        while (pila.Count > 0)
        {
            // Sacar el estado actual de la pila
            var estado = pila.Pop();
            int n = estado.Item1; // Número de discos
            string o = estado.Item2; // Torre de origen
            string d = estado.Item3; // Torre de destino
            string a = estado.Item4; // Torre auxiliar

            // Caso base: si hay solo un disco, moverlo directamente
            if (n == 1)
            {
                Console.WriteLine($"Mover disco de {o} a {d}");
            }
            else
            {
                // Caso general: dividir el problema en subproblemas y apilarlos

                // 1. Mover (n-1) discos de la torre auxiliar a la torre de destino
                pila.Push(Tuple.Create(n - 1, a, d, o));

                // 2. Mover el disco más grande de la torre de origen a la torre de destino
                pila.Push(Tuple.Create(1, o, d, a));

                // 3. Mover (n-1) discos de la torre de origen a la torre auxiliar
                pila.Push(Tuple.Create(n - 1, o, a, d));
            }
        }
    }

    // Método principal
    static void Main()
    {
        // Número de discos para resolver el problema
        int discos = 3;

        // Definir las torres de origen, destino y auxiliar
        string origen = "A";
        string destino = "C";
        string auxiliar = "B";

        // Imprimir la solución para el número de discos especificado
        Console.WriteLine($"Solución para {discos} discos:");
        ResolverTorresDeHanoi(discos, origen, destino, auxiliar);
    }
}
