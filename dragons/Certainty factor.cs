using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dragons
{
    class Certainty_factor
    {
        Dictionary<string, string> facts = new Dictionary<string, string>();
        Dictionary<string, Rule> rules = new Dictionary<string, Rule>();
        Dictionary<string, double> cert_facts = new Dictionary<string, double>();
        Dictionary<string, double> cert_rules = new Dictionary<string, double>();

        public Certainty_factor() {
            get_facts("..//..//facts_with_k.txt");
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
                    cert_facts[facts.Last().Key] = Convert.ToDouble(temp[2].Trim(' '));
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

        public string check_work() {
            return "" + facts.First().Key + ':' + facts.First().Value + ':' + cert_facts[facts.First().Key]; 
        }
    }
}
