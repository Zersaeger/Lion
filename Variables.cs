using System.Collections;
class Variables
{
    public static Hashtable variables = new Hashtable();
    public static void addInt(string token, int line)
    {
        if (token.EndsWith('!'))
        {
            token.Trim('!');
            variables.Add(token, null);
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
            variables.Add(token, null);
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
        if (token.EndsWith('!'))
        {
            token.Trim('!');
            variables.Add(token, null);
        }
        else
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
}