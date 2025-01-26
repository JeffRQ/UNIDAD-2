class Program
{
    static void Main()
    {
        // Fórmula matemática a verificar
        string expresion = "{3*(4+5)-[6/(1+2)]+(7*8)}";

        // Imprime la fórmula ingresada
        Console.WriteLine($"Fórmula: {expresion}");

        // Verifica si la fórmula está balanceada e imprime el resultado
        Console.WriteLine(VerificarBalance(expresion) 
            ? "Resultado: Fórmula balanceada."
            : "Resultado: Fórmula no balanceada.");
    }

    // Método para verificar si los paréntesis, corchetes y llaves están balanceados
    static bool VerificarBalance(string exp)
    {
        var pila = new Stack<char>(); // Pila para almacenar caracteres de apertura

        foreach (char c in exp)
        {
            // Si el carácter es un símbolo de apertura, lo apilamos
            if ("({[".Contains(c)) pila.Push(c);

            // Si el carácter es un símbolo de cierre, verificamos balanceo
            if (")}]".Contains(c) && (pila.Count == 0 || !"(){}[]".Contains($"{pila.Pop()}{c}")))
                return false; // Si no coincide o la pila está vacía, no está balanceado
        }

        // Si la pila está vacía al final, todos los símbolos están balanceados
        return pila.Count == 0;
    }
}
