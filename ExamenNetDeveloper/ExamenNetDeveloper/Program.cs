using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNetDeveloper
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangeString changeString = new ChangeString();
            changeString.build("123 abcd*3");


            OrderRange orderRange = new OrderRange();
            int[] numeros = { 58, 60, 55, 48, 57, 73 };            
            orderRange.build(numeros.ToList());


            MoneyParts moneyParts = new MoneyParts();
            moneyParts.build(0.5);


            Console.ReadKey();
        }
    }
}
