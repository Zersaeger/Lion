class Error
{
    public static void Unallowedsign(int line)
    {
        Console.WriteLine("Unallowed sign in line: " + line);
        Program.run = false;
    }
    public static void VarNotDeclared(int line, string name)
    {
        Console.WriteLine("Var " + name + " in line: " + line + " is not declared");
        Program.run = false;
    }
    public static void SyntaxError(int line)
    {
        Console.WriteLine("Syntax error in line: " + line);
        Program.run = false;
    }
}