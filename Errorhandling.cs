class Error
{
    public static void Unallowedsign(int line)
    {
        Console.WriteLine("Unallowed sign in line: " + line);
    }
    public static void VarNotDeclared(int line, string name)
    {
        Console.WriteLine("Var " + name + " in line: " + line + " not declared");
    }
}