using System.Globalization;
class Program
{
    public static bool run = true;
    public static void Main()
    {
        //var watch = new System.Diagnostics.Stopwatch();
        //watch.Start();

        while (run)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            string[] allLines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "main.lio"));

            for (int i = 0; i < allLines.Count(); i++)
            {

                string[] cutline = allLines[i].Split(':');
                switch (cutline[0])
                {
                    case "out":
                        ConsoleInteraction.Out(cutline[1], i + 1);
                        break;
                    case "outln":
                        ConsoleInteraction.LnOut(cutline[1], i + 1);
                        break;
                    case "in":
                        ConsoleInteraction.input(cutline[1], i + 1);
                        break;
                    case "int":
                        Variables.addInt(cutline[1], i + 1);
                        break;
                    case "int[]":
                        Variables.NewIntArr(cutline[1], i + 1);
                        break;
                    case "double":
                        Variables.addDouble(cutline[1], i + 1);
                        break;
                    case "double[]":
                        Variables.NewDoubleArr(cutline[1], i + 1);
                        break;
                    case "string":
                        Variables.addString(cutline[1], i + 1);
                        break;
                    case "string[]":
                        Variables.NewStringArray(cutline[1], i + 1);
                        break;
                    case "yeet":
                        if (Variables.Yeet(cutline[1], i + 1))
                        {
                            continue;
                        }
                        break;
                    case "//":
                        continue;
                    case "/*":
                        i = MultiLineComments(i, 0, allLines);
                        break;
                    default:
                        try
                        {
                            string[] cutline2 = allLines[i].Split('=');
                            string value = "";
                            string name = "";
                            try
                            {
                                value = cutline2[1].Trim(' ');
                                name = cutline2[0].Trim(' ');
                            }
                            catch
                            {
                                value = cutline2[1];
                                name = cutline2[0];
                            }
                            Variables.changeValue(name, value);
                        }
                        catch
                        {
                            Console.WriteLine("Undefindable error in line: " + i + 1);
                        }
                        break;
                }
            }
            run = false;
            //watch.Stop();
            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }

    public static int MultiLineComments(int startLine, int endLine, string[] allLines)
    {
        for (int i = startLine; i < allLines.Count(); i++)
        {
            if (allLines[i].EndsWith("*/"))
            {
                endLine = i;
            }
        }
        return endLine;
    }
}