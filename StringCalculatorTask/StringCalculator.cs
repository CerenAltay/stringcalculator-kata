using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTask
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if(String.IsNullOrEmpty(numbers))
            {
                return 0;
            }
        
            int sum = numbers.Split(',','\n').Sum(x => int.Parse(x));

            return sum;
        }
    }
}
 