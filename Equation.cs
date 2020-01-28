using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;

namespace LaTeX_into_code
{
    class Equation
    {
        public string Latex_equation { get; set; }
        public string Cs_equation { get; set; }

        public string[] latex_operators = { "+", "-", "*", "/", @"\times", "^",  @"\frac", "{", "}", "(", ")", @"\pi", @"\ln()", @"\sin()", @"\cos()", @"\tan()", @"\cot()" };
        
        public List<string> Variables = new List<string>();
        

        public void convert_fraction(string equation)
        {
            string cs_fraction ="";
            string newFrac ="";
            string[] frac_operators = { @"\frac", "{", "}" };
            
            string pattern = @"\b\w+rac\b";
            foreach (Match match in Regex.Matches(equation, pattern))
            {
                newFrac = "";
                int open_brackets_counter = 0;
                int closed_brackets_counter = 0;

                foreach (char c in equation.Substring(match.Index - 1))
                {
                    newFrac += c;

                    if (c == '{')
                    {
                        open_brackets_counter++;
                    }
                    if (c == '}')
                    {
                        closed_brackets_counter++;
                    }
                    if (open_brackets_counter == closed_brackets_counter && open_brackets_counter > 1)
                    {
                        break;
                    }

                }

                cs_fraction = newFrac;
                cs_fraction = cs_fraction.Replace("}{", "/");

                for (int i = 0; i < frac_operators.Length; i++)
                {
                    cs_fraction = cs_fraction.Replace(frac_operators[i], " ");
                }

                cs_fraction = cs_fraction.Trim();
                cs_fraction = "(" + cs_fraction + ")";
                cs_fraction = cs_fraction.Insert(cs_fraction.IndexOf("/"), ")");
                cs_fraction = cs_fraction.Insert(cs_fraction.IndexOf("/")+1, "(");
                

                this.Cs_equation = this.Cs_equation.Replace(newFrac, cs_fraction);
            }
        }

        public void convert_exponentiation(string equation)
        {
            string cs_exp = "";
            string new_exp = "";
            string[] exp_operators = { "^", "{", "}" };
            string my_base;
            string my_exponent;

            List<int> indexes = equation.AllIndexesOf("^");

            for (int i=0; i<indexes.Count; i++)
            {
                int open_brackets_counter = 0;
                int closed_brackets_counter = 0;
                my_base = "";
                my_exponent = "";

                if(equation.Substring(indexes[i]-1,1) == ")")
                {
                    int counter = 1;
                    char c;

                    do
                    {
                        c = Convert.ToChar(equation.Substring(indexes[i] - counter, 1));
                        my_base = c + my_base;

                        if (c == ')')
                        {
                            closed_brackets_counter++;
                        }
                        if (c == '(')
                        {
                            open_brackets_counter++;
                        }

                        counter++;
                    } while (open_brackets_counter != closed_brackets_counter);
                }
                else
                {
                    my_base = equation.Substring(indexes[i] - 1, 1);
                }

                open_brackets_counter = 0;
                closed_brackets_counter = 0;

                foreach (char c in equation.Substring(indexes[i] + 1))
                {
                    my_exponent += c;
                    
                    if (c == '{')
                    {
                        open_brackets_counter++;
                    }
                    if (c == '}')
                    {
                        closed_brackets_counter++;
                    }
                    if (open_brackets_counter == closed_brackets_counter && open_brackets_counter > 0)
                    {
                        break;
                    }
                }

                new_exp = my_base + "^" + my_exponent;

                my_base = my_base.Trim('(');
                my_base = my_base.Trim(')');
                my_exponent = my_exponent.Trim('{');
                my_exponent = my_exponent.Trim('}');

                cs_exp = "Pow(" + my_base + "," + my_exponent + ")";

                this.Cs_equation = this.Cs_equation.Replace(new_exp, cs_exp);
            }
        }

        public void convert_functions(string equation)
        {
            string cs_func = "";
            string new_func = "";
            string[] functions = { @"\sin", @"\cos", @"\tan", @"\cot", @"\ln" };

            foreach(string func in functions)
            {
                List<int> indexes = equation.AllIndexesOf(func);

                for (int i = 0; i < indexes.Count; i++)
                {
                    int open_brackets_counter = 0;
                    int closed_brackets_counter = 0;
                    new_func = "";
                    foreach (char c in equation.Substring(indexes[i]))
                    {
                        new_func += c;

                        if (c == '(')
                        {
                            open_brackets_counter++;
                        }
                        if (c == ')')
                        {
                            closed_brackets_counter++;
                        }
                        if (open_brackets_counter == closed_brackets_counter && open_brackets_counter > 0)
                        {
                            break;
                        }
                    }
                    
                    cs_func = "Math." + StringExtensions.FirstCharToUpper(func.Substring(1));
                    cs_func = new_func.Replace(func, cs_func);
                    if (func == @"\cot")
                    {
                        cs_func = "(1/" + cs_func.Replace("Cot", "Tan") + ")";
                    }
                    if(func == @"\ln")
                    {
                        cs_func = cs_func.Replace("Ln", "Log");
                    }
                    this.Cs_equation = this.Cs_equation.Replace(new_func, cs_func);
                }
            }
        }
        
        public void Latex_to_CS()
        {
            this.convert_fraction(this.Latex_equation);
            this.Cs_equation = this.Cs_equation.Replace(@"\times", "*");
            this.Cs_equation = this.Cs_equation.Replace(@"\pi", "Math.PI");
            this.convert_exponentiation(this.Cs_equation);
            this.convert_functions(this.Cs_equation);

            this.Cs_equation = Regex.Replace(this.Cs_equation, @"\s", "");
            MessageBox.Show(Cs_equation);
        }

        
    }

    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }

}
