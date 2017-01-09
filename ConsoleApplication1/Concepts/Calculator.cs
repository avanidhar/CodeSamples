using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Concepts
{
    public class Calculator
    {
        public int result { get; set; }

        private char previousOperand;

        private StringBuilder sb;

        public Calculator()
        {
            result = 0;
            this.previousOperand = ' ';
            sb = new StringBuilder();
        }


        public void updateDisplay(string output)
        {
            Console.WriteLine(output);
        }

        public void KeyPressed(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/')
            {
                this.previousOperand = c;
                updateDisplay(this.result.ToString());
                return;
            }

            if (c == '=')
            {
                previousOperand = ' ';
                updateDisplay(this.result.ToString());
                return;
            }

            if (previousOperand == ' ')
            {
                result = result * 10 + c - '0';
                updateDisplay(this.result.ToString());
            }
            else
            {
                updateDisplay(c.ToString());
                switch (previousOperand)
                {
                    case '+':
                        result += c - '0';
                        break;
                    case '-':
                        result -= c - '0';
                        break;
                    case '*':
                        result *= c - '0';
                        break;
                    case '/':
                        result /= c - '0';
                        break;
                }

                // updateDisplay(result.ToString());
                previousOperand = ' ';
            }
        }
    }
}
