using System.Collections;
using System.Diagnostics.Contracts;

class Variables
{
    public static Hashtable variables = new Hashtable();
    public static void addInt(string token, int line)
    {
        if (token.EndsWith('!'))
        {
            token.Trim('!');
            variables.Add(token, 0);
        }
        else
        {
            string[] seperate = token.Split('=');
            string name = seperate[0];
            name = name.Trim(' ');
            int value = 0;
            try
            {
                value = Int32.Parse(seperate[1]);
            }
            catch
            {
                Error.Unallowedsign(line);
            }
            variables.Add(name, value);
        }

    }
    public static void addDouble(string token, int line)
    {
        if (token.EndsWith('!'))
        {
            token.Trim('!');
            variables.Add(token, 0.0);
        }
        else
        {
            string[] seperate = token.Split('=');
            string name = seperate[0];
            name = name.Trim(' ');
            double value = 0;
            try
            {
                value = Double.Parse(seperate[1]);
            }
            catch
            {
                Error.Unallowedsign(line);
            }
            variables.Add(name, value);
        }

    }
    public static void addString(string token, int line)
    {
        string[] seperate = token.Split('=');
        string name = seperate[0];
        name = name.Trim(' ');
        string prevalue = seperate[1].Trim(' ');
        string value = prevalue.Trim('"');
        try
        {
            variables.Add(name, value);
        }
        catch
        {
            Error.Unallowedsign(line);
        }
    }
    public static bool Yeet(string vars, int line)
    {
        List<string> FinalAllVars = new List<string>();
        try
        {
            string[] allVars = vars.Split(',');
            for (int i = 0; i < allVars.Count(); i++)
            {
                FinalAllVars.Add(allVars[i].Trim(' '));
            }
            for (int i = 0; i < FinalAllVars.Count(); i++)
            {
                if (variables.ContainsKey(FinalAllVars[i]))
                {
                    variables.Remove(FinalAllVars[i]);
                }
                else
                {
                    Console.WriteLine("Variable does not exist: " + FinalAllVars[i]);
                    return false;
                }
            }
        }
        catch
        {
            if (variables.ContainsKey(vars))
            {
                variables.Remove(vars);
            }
            else
            {
                Console.WriteLine("Variable does not exist: " + vars);
            }
        }
        return true;
    }

    public static void NewStringArray(string cutline, int line)
    {
        string[] tokens = cutline.Split('=');
        string name = "";
        int size = 0;
        try
        {
            string presize = tokens[1].Trim(' ');
            string presize2 = presize.Trim('[');
            string presize3 = presize2.Trim(']');
            size = Int32.Parse(presize3);
        }
        catch
        {
            try
            {
                string presize2 = tokens[1].Trim('[');
                string presize3 = presize2.Trim(']');
                size = Int32.Parse(presize3);
            }
            catch
            {
                Error.SyntaxError(line);
                return;
            }
        }
        try
        {
            name = tokens[0].Trim(' ');
        }
        catch
        {
            name = tokens[0];
        }
        for (int i = 0; i < size; i++)
        {
            name += $"[{i.ToString()}]";
            variables.Add(name, "");
        }
    }
    public static void NewIntArr(string cutline, int line)
    {
        string[] tokens = cutline.Split('=');
        string name = "";
        int size = 0;
        try
        {
            string presize = tokens[1].Trim(' ');
            string presize2 = presize.Trim('[');
            string presize3 = presize2.Trim(']');
            size = Int32.Parse(presize3);
        }
        catch
        {
            try
            {
                string presize2 = tokens[1].Trim('[');
                string presize3 = presize2.Trim(']');
                size = Int32.Parse(presize3);
            }
            catch
            {
                Error.SyntaxError(line);
                return;
            }
        }
        try
        {
            name = tokens[0].Trim(' ');
        }
        catch
        {
            name = tokens[0];
        }
        for (int i = 0; i < size; i++)
        {
            name += $"[{i.ToString()}]";
            variables.Add(name, 0);
        }
    }
    public static void NewDoubleArr(string cutline, int line)
    {
        string[] tokens = cutline.Split('=');
        string name = "";
        int size = 0;
        try
        {
            string presize = tokens[1].Trim(' ');
            string presize2 = presize.Trim('[');
            string presize3 = presize2.Trim(']');
            size = Int32.Parse(presize3);
        }
        catch
        {
            try
            {
                string presize2 = tokens[1].Trim('[');
                string presize3 = presize2.Trim(']');
                size = Int32.Parse(presize3);
            }
            catch
            {
                Error.SyntaxError(line);
                return;
            }
        }
        try
        {
            name = tokens[0].Trim(' ');
        }
        catch
        {
            name = tokens[0];
        }
        for (int i = 0; i < size; i++)
        {
            name += $"[{i.ToString()}]";
            variables.Add(name, 0.0);
        }
    }
}