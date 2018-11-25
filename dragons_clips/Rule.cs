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

            public string forward_print()
            {
                Form1 _form = new Form1();
                string res = "";
                foreach (var i in preconditions)
                {
                    res += _form.facts[i];
                    if (i != preconditions.Last())
                        res += " , ";
                }
                res += "->" + _form.facts[consequence];
                return res;
            }

            public string return_print()
            {
                Form1 _form = new Form1();
                string res = "" + _form.facts[consequence] + " -> ";
                foreach (var t in preconditions)
                    if (t != preconditions.Last())
                        res += _form.facts[t] + ", ";
                    else
                        res += _form.facts[t];
                return res;
            }

            public string isDragon()
            {
                Form1 _form = new Form1();
                string res = "";
                if (consequence[0] == 'F')
                    res = _form.facts[consequence];
                return res;
            }
        }
}
