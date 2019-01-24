using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    class Program
    {
        static void Main(string[] args)
        {
            var retry = "y";

            //getting values and theirs length comparison
            var equalsValues = GetValues(out string comp1, out string comp2);

            //if value has different length
            if (!equalsValues)
            {
                retry = string.Empty;

                do
                {
                    //if equalsValues equal false then will show a warning message and try again message 
                    if (retry != "y" || retry != "n")
                    {
                        Console.WriteLine("Warning! Incorecct input value!");
                        Console.WriteLine("Try again? (y/n)");
                    }

                    //getting retry value
                    retry = Console.ReadLine();

                    //if retry then getting values
                    if (retry == "y")
                    {
                        equalsValues = GetValues(out comp1, out comp2);
                    }
                    //else stop loop
                    else if(retry == "n")
                    {
                        equalsValues = true;
                    }
                }
                while ((retry != "y" && retry != "n") || !equalsValues);
            }

            //return result 
            if (retry == "y")
            {
                Console.WriteLine($"XOR result: {StrXOR(comp1, comp2)}");
            }
            else
            {
                Console.WriteLine($"Goodbye:)");
            }

            Console.ReadLine();
        }

        private static string StrXOR(string component1, string component2)
        {
            int length = component1.Length;

            //creating byte array with half components length for saving XOR operation
            byte[] buffer = new byte[length / 2];

            //Going to loop with step 2 and ending when iterator equals components length
            for (int i = 0; i < length; i += 2)
            {
                //getting and converting two chars from components (starting from iterator position) to HEX bytes
                //then XOR operation
                //and save XOR result to buffer
                buffer[i / 2] = (byte)(Convert.ToByte(component1.Substring(i, 2), 16) ^ Convert.ToByte(component2.Substring(i, 2), 16));
            }

            //if should be return 'clear' HEX string then  
            //return BitConverter.ToString(bytes).Replace("-", "");
            return BitConverter.ToString(buffer);
        }

        private static bool GetValues(out string component1, out string component2)
        {
            //getting first value
            Console.WriteLine("Component1");
            component1 = Console.ReadLine();

            //getting second value
            Console.WriteLine("Component2");
            component2 = Console.ReadLine();

            return component1.Length == component2.Length;
        }
    }
}
