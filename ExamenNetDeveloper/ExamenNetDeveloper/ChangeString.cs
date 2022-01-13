using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNetDeveloper
{
    public class ChangeString
    {
        public string build(string original)
        {
            var destinoList = original.ToList();
            for (int i = 0; i < original.Length; i++)
            {
                var ascci = Char.ConvertToUtf32(original, i);
                if ((ascci>96 && ascci<123) || (ascci > 64 && ascci < 91))
                {
                    destinoList[i] = (char)(Char.ConvertToUtf32(original, i) + 1);
                }
            }
            StringBuilder builder = new StringBuilder();
            foreach (var item in destinoList)
            {
                builder.Append(item);
            }

            Console.WriteLine(builder.ToString());

            return builder.ToString();
        }
    }
}
