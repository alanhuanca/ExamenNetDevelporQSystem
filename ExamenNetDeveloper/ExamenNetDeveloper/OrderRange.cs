using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNetDeveloper
{
    public class OrderRange
    {
        public void build(List<int> numerosList)
        {

            var pares = numerosList.Where(x => x % 2 == 0).OrderBy(x=>x).ToList();
            var impares = numerosList.Where(x => x % 2 != 0).OrderBy(x => x).ToList();
            
        }
    }
}
