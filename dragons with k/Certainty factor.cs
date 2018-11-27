using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dragons
{
    public class Certainty_factor
    {
        public Dictionary<string, string> facts = new Dictionary<string, string>();
        public Dictionary<string, Rule> rules = new Dictionary<string, Rule>();
        public Dictionary<string, double> cert_facts = new Dictionary<string, double>();
        public Dictionary<string, double> cert_rules = new Dictionary<string, double>();

        public string conc = "";
        public List<string> dragons = new List<string>();

        private double limit = 0.2;

        public Certainty_factor() {
            get_facts("..//..//facts.txt");
            get_rules("..//..//rules_with_k.txt");
        }

        private void get_facts(string fname)
        {
            using (StreamReader fs = new StreamReader(fname))
                while (true)
                {
                    string line = fs.ReadLine();
                    if (line == null) break;
                    var temp = line.Split(':');
                    facts[temp[0].Trim(' ').ToString()] = temp[1].Trim(' ');
                }
        }

        //Словарь правил, ключ - идентификатор правила, значение - правило, 
        //в котором посылки и следствие - идентификаторы фактов
        private void get_rules(string fname)
        {
            using (StreamReader fs = new StreamReader(fname))
            {
                string line;
                while ((line = fs.ReadLine()) != null)
                {
                    var temp = line.Split(':');
                    rules[temp[0].Trim(' ').ToString()] = new Rule(temp[1].Trim(' '));
                    cert_rules[rules.Last().Key] = Convert.ToDouble(temp[2].Trim(' '));
                }
            }
        }

        private List<string> agenda(ref List<string> in_f, ref List<string> f)
        {
            List<string> res = new List<string>();
            foreach (var i in rules)
                if (i.Value.compare(in_f) && !f.Contains(i.Key))
                    res.Add(i.Key);
            return res;
        }

        public bool application(ref List<string> in_f, ref List<string> f)
        {
            bool res = false;
            List<string> ag = new List<string>();
            do
            {
                ag = agenda(ref in_f, ref f).OrderByDescending(x => cert_rules[x]).ToList();
                if (ag.Count > 0)
                {
                    string current_rule = ag.First();
                    res = true;
                    f.Add(current_rule);
                    
                    double A = Double.MaxValue;
                    foreach (var i in rules[current_rule].preconditions)
                        A = Math.Min(A, cert_facts[i]);

                    double B = A * cert_rules[current_rule];

                    if (!cert_facts.ContainsKey(rules[current_rule].consequence))
                        cert_facts[rules[current_rule].consequence] = B;
                    else
                        cert_facts[rules[current_rule].consequence] = cert_facts[rules[current_rule].consequence] +
                            B - cert_facts[rules[current_rule].consequence] * B;

                    if (cert_facts[rules[current_rule].consequence] < limit) continue;

                    in_f.Add(rules[current_rule].consequence);

                    foreach (var i in rules[current_rule].preconditions)
                    {
                        conc += facts[i];
                        if (i != rules[current_rule].preconditions.Last())
                            conc += ", ";
                    }
                    conc += " -> " + facts[rules[current_rule].consequence] + " : P = " + 
                        cert_facts[rules[current_rule].consequence] + Environment.NewLine;

                    if (rules[current_rule].consequence[0] == 'F')
                        dragons.Add(rules[current_rule].consequence);
                }

            } while (ag.Count > 0);

            dragons = dragons.Distinct().OrderByDescending(x => cert_facts[x]).Take(5).ToList();

            return res;
        }
    }
}
