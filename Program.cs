using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SplitFile
{
    class Program
    {
        /// <summary>
        /// Read input file with file names
        /// with 3 possible extensions (.c , .cpp , .cs)
        /// Create 3 files, one for each extension.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //string filename = Console.ReadLine();
            string filename = "data.txt";

            if (string.IsNullOrWhiteSpace(filename))
                return;

            string filename_c = "c_" + filename;
            string filename_cs = "cs_" + filename;
            string filename_cpp = "cpp_" + filename;

            using (StreamWriter sw_c = new StreamWriter(filename_c))
            using (StreamWriter sw_cs = new StreamWriter(filename_cs))
            using (StreamWriter sw_cpp = new StreamWriter(filename_cpp))
            using (var sr = new StreamReader(filename))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();

                    if (line.Length < 2)
                        continue;

                    string ext = line.Substring(line.Length-2);
                    if (ext == ".c")
                    {
                        sw_c.WriteLine(line);
                    }
                    else {
                        if (line.Length < 3)
                            continue;

                        ext = line.Substring(line.Length - 3);
                        if (ext == ".cs")
                        {
                            sw_cs.WriteLine(line);
                        }
                        else {
                            if (line.Length < 4)
                                continue;

                            ext = line.Substring(line.Length - 4);
                            if (ext == ".cpp")
                            {
                                sw_cpp.WriteLine(line);
                            }
                        }
                    }

                }
            }


        }



    }
}
