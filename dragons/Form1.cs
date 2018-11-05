using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dragons
{
    public partial class Form1 : Form
    {
        public SortedDictionary<string, string> facts = new SortedDictionary<string, string>();
        Dictionary<string, Rule> rules = new Dictionary<string, Rule>();
        public Form1()
        {
            InitializeComponent();

            facts = get_dictionary("..//..//facts.txt");
            rules = get_rules("..//..//rules.txt");
            foreach (var item in facts.Keys)
            {
                if (item.First() == 'T')
                    checkedListBoxT.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'S')
                    checkedListBoxS.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'P')
                    checkedListBoxP.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'Z')
                    checkedListBoxZ.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'C')
                    checkedListBoxС.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'W')
                    checkedListBoxW.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'F')
                    checkedListBoxF.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'O')
                    checkedListBoxO.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'G')
                    checkedListBoxG.Items.Add("" + item + ": " + facts[item]);
            }
        }

        private SortedDictionary<string, string> get_dictionary(string fname)
        {
            SortedDictionary<string, string> d = new SortedDictionary<string, string>();
            using (StreamReader fs = new StreamReader(fname))
            {
                while (true){
                    string temp = fs.ReadLine();
                    if (temp == null) break;
                    string[] strs = temp.Split(':');
                    d.Add(strs[0].Trim(' '), strs[1]);
                }
            }
            return d;
        }

        public class Rule {
            public List<string> preconditions;
            public string consequence;
            
            public Rule(string r) {
                preconditions = new List<string>();
                var temp = r.Split('-');
                consequence = temp[1].Trim(' ');
                var lst = temp[0].Split(',');
                foreach (var i in lst)
                    preconditions.Add(i.Trim(' '));
            }

            public bool compare(List<string> f) {
                bool res = true;
                foreach (var i in preconditions)
                    res = res && f.Contains(i);
                return res;
            }

           public string forward_print() {
                Form1 _form = new Form1();
                string res = "";
                foreach (var i in preconditions) {
                    res += _form.facts[i];
                    if (i != preconditions.Last())
                        res += " , ";
                }
                res += "->" + _form.facts[consequence];
                return res;
            }

           public string return_print(){
               Form1 _form = new Form1();
               string res = "" + _form.facts[consequence] + " -> ";
               foreach (var t in preconditions)
                   if (t != preconditions.Last())
                       res += _form.facts[t] + ", ";
                   else
                       res += _form.facts[t];
               return res;
           } 

           public string isDragon() {
               Form1 _form = new Form1();
               string res = "";
               if(consequence[0] == 'F')
                   res = _form.facts[consequence]; 
               return res;
           }
        }

        //Словарь правил, ключ - идентификатор правила, значение - правило, 
        //в котором посылки и следствие - идентификаторы фактов
        private Dictionary<string, Rule> get_rules(string fname)
        {
            Dictionary<string, Rule> d = new Dictionary<string, Rule>();
            using (StreamReader fs = new StreamReader(fname))
            {
                string line;
                while ((line = fs.ReadLine()) != null){
                    var temp = line.Split(':');
                    temp[1] = temp[1].Trim(' ');
                    d[temp[0]] = new Rule(temp[1]);
                }
            }
            return d;
        }

        private void checkedListBoxT_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxT.SelectedItem);
            checkedListBoxT.Items.Remove(checkedListBoxT.SelectedItem);
        }
        private void checkedListBoxS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxS.SelectedItem);
            checkedListBoxS.Items.Remove(checkedListBoxS.SelectedItem);
        }
        private void checkedListBoxP_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxP.SelectedItem);
            checkedListBoxP.Items.Remove(checkedListBoxP.SelectedItem);
        }
        private void checkedListBoxZ_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxZ.SelectedItem);
            checkedListBoxZ.Items.Remove(checkedListBoxZ.SelectedItem);
        }
        private void checkedListBoxC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxС.SelectedItem);
            checkedListBoxС.Items.Remove(checkedListBoxС.SelectedItem);
        }
        private void checkedListBoxF_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxF.SelectedItem);
            checkedListBoxF.Items.Remove(checkedListBoxF.SelectedItem);
        }
        private void checkedListBoxW_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxW.SelectedItem);
            checkedListBoxW.Items.Remove(checkedListBoxW.SelectedItem);
        }
        private void checkedListBoxO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxO.SelectedItem);
            checkedListBoxO.Items.Remove(checkedListBoxO.SelectedItem);
        }
        private void checkedListBoxG_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxG.SelectedItem);
            checkedListBoxG.Items.Remove(checkedListBoxG.SelectedItem);
        }

        private void summary_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var rem = summary.SelectedItem.ToString()[0];
            switch (rem) { 
                case 'T':
                    checkedListBoxT.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    break;
                case 'S':
                    checkedListBoxS.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    break;
                case 'P':
                    checkedListBoxP.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    break;
                case 'Z':
                    checkedListBoxZ.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    break;
                case 'C':
                    checkedListBoxС.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    break;
                case 'F':
                    checkedListBoxF.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    break;
                case 'W':
                    checkedListBoxW.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    break;
                case 'O':
                    checkedListBoxO.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    break;
                case 'G':
                    checkedListBoxG.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    break;
                default:
                    break;
            }
        }

        private bool agenda(ref Dictionary<string, Rule> w, ref List<string> f)
        {
            bool res = false;
            foreach (var i in w)
                if (i.Value.compare(f)) {
                    var ft = i.Value.consequence;
                    if (!f.Contains(ft)) {
                        f.Add(i.Value.consequence);
                        res = true;
                        textBox2.Text += i.Value.forward_print() + Environment.NewLine;
                        string dr = i.Value.isDragon();
                        if (dr != "")
                            listBox1.Items.Add(dr);
                    }
                }
            return res;
        }

        private bool ret_agenda(ref Dictionary<string, Rule> w, ref List<string> f)
        {
            bool res = false;
            foreach (var i in w)
                if (f.Contains(i.Value.consequence)){
                    res = true;
                    foreach (var j in i.Value.preconditions) 
                        if (!f.Contains(j)) 
                            f.Add(j);
                    textBox2.Text += i.Value.return_print() + Environment.NewLine;
                }
            return res;
        }

        private void start_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            List<string> in_fact = new List<string>();
            foreach (var i in summary.Items)
                in_fact.Add(i.ToString().Split(':')[0].Trim(' '));
            if (!checkBox1.Checked)
                while (agenda(ref rules, ref in_fact)) { }
            else
                while (ret_agenda(ref rules, ref in_fact)) { }   
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            summary.Items.Clear();
            textBox2.Text = "";
            if (checkBox1.Checked){
                label4.Visible = false;
                listBox1.Visible = false;
                checkedListBoxT.Enabled = false;
                checkedListBoxS.Enabled = false;
                checkedListBoxP.Enabled = false;
                checkedListBoxZ.Enabled = false;
                checkedListBoxС.Enabled = false;
                checkedListBoxW.Enabled = false;
                checkedListBoxO.Enabled = false;
                checkedListBoxG.Enabled = false;
            }
            else{
                label4.Visible = true;
                listBox1.Visible = true;
                checkedListBoxT.Enabled = true;
                checkedListBoxS.Enabled = true;
                checkedListBoxP.Enabled = true;
                checkedListBoxZ.Enabled = true;
                checkedListBoxС.Enabled = true;
                checkedListBoxW.Enabled = true;
                checkedListBoxO.Enabled = true;
                checkedListBoxG.Enabled = true;
            
            }
        } 
    }
}
