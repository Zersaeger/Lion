class ConsoleInteraction
{
    public static void Out(string input, int line)
    {
        char[] tokens = input.ToCharArray();
        int first = -1;
        int last = -1;
        input = input.Trim(' ');
        if (!input.StartsWith("\""))
        {
            if (Variables.variables.Contains(input.Trim(' ')))
            {
                Console.Write(Variables.variables[input.Trim(' ')]);
            }
            else
            {
                Error.VarNotDeclared(line, input.Trim(' '));
                return;
            }
        }
        for (int i = 0; i < tokens.Count(); i++)
        {
            if (tokens[i] == '"')
            {
                if (first == -1)
                {
                    first = i;
                }
                else
                {
                    last = i;
                }
            }
        }
        for (int i = first + 1; i < last; i++)
        {
            Console.Write(tokens[i]);
        }
    }
    public static void LnOut(string input, int line)
    {
        input = input.Trim(' ');
        char[] tokens = input.ToCharArray();
        int first = -1;
        int last = -1;
        if (!input.StartsWith("\""))
        {
            if (Variables.variables.Contains(input.Trim(' ')))
            {
                Console.Write(Variables.variables[input.Trim(' ')]);
            }
            else
            {
                Error.VarNotDeclared(line, input.Trim(' '));
                return;
            }
        }
        for (int i = 0; i < tokens.Count(); i++)
        {
            if (tokens[i] == '"')
            {
                if (first == -1)
                {
                    first = i;
                }
                else
                {
                    last = i;
                }
            }
        }
        for (int i = first + 1; i < last; i++)
        {
            Console.Write(tokens[i]);
        }
        Console.Write("\n");
    }
    public static void input(string var, int line)
    {
        if (!Variables.variables.Contains(var))
        {
            Error.VarNotDeclared(line, var);
        }
        else
        {
            Variables.variables[var] = Console.ReadLine();
        }
    }
}