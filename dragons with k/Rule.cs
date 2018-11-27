using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragons
{
    public class Rule
    {
            public List<string> preconditions;
            public string consequence;

            public Rule(string r)
            {
                preconditions = new List<string>();
                var temp = r.Split('-');
                consequence = temp[1].Trim(' ');
                var lst = temp[0].Split(',');
                foreach (var i in lst)
                    preconditions.Add(i.Trim(' '));
            }

            public bool compare(List<string> f)
            {
                bool res = true;
                foreach (var i in preconditions)
                    res = res && f.Contains(i);
                return res;
            }
    }
}
