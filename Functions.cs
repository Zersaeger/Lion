using System.Collections;
using System.ComponentModel.Design;

class Function
{
    public static Hashtable functionsLines = new Hashtable();
    public static int function(string cutline, int line)
    {
        int end = 0;
        functionsLines.Add(cutline + "start", line + 1);
        for (int i = line + 1; i < Program.allLines.Count(); i++)
        {
            if (Program.allLines[i] == "end:" + cutline)
            {
                functionsLines.Add(cutline + "end", i);
                end = i;
                i = Program.allLines.Count();
            }
        }
        return end;
    }
    public static void callFunction(string name)
    {
        int startline = (Int32)functionsLines[name + "start"]!;
        int endLine = (Int32)functionsLines[name + "end"]!;
        for (int i = startline; i < endLine; i++)
        {
            Program.Scanner(ref i);
        }
    }
}