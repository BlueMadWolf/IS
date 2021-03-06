﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using CLIPSNET;

namespace dragons
{
    public partial class Form1 : Form
    {
        public SortedDictionary<string, string> facts = new SortedDictionary<string, string>();
        public static Dictionary<string, Rule> rules = new Dictionary<string, Rule>();

        public static List<string> findRules(string id, List<string> rep)
        {
            List<string> result = new List<string>();
            foreach (var i in rules){
                if (i.Value.consequence == id && !rep.Contains(i.Key))
                    result.Add(i.Key);
            }
            return result;
        }

        class Node
        {
            public string name;
            public List<Node> parents = new List<Node>();
            public List<Node> children = new List<Node>();
            public bool flag = false;
            public Node() { }
        }

        class AndNode : Node
        {
            public string name;
            public AndNode() { }
            public AndNode(string rule)
            {
                name = rule;
            }
        }

        class OrNode : Node
        {
            public string name;
            public OrNode() { }
            public OrNode(string fact)
            {
                name = fact;
            }
        }

        Certainty_factor factor;

        public Form1()
        {
            InitializeComponent();
            factor = new Certainty_factor();
            facts = get_dictionary("..//..//facts.txt");
            rules = get_rules("..//..//rules.txt");
            load();
        }

        private void resolve(Node n)
        {
            if (n.flag)
                return;
            if (n is AndNode)
                n.flag = n.children.All(c => c.flag == true);

            if (n is OrNode)
                n.flag = n.children.Any(c => c.flag == true);

            if (n.flag)
                foreach (Node p in n.parents)
                    resolve(p);
        }

        public Tuple<bool, List<string>> backward_reasoning(List<string> Facts, string need_right)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();
            List<string> known_facts = new List<string>(Facts);

            List<string> resId = new List<string>();
            List<string> targets = new List<string>();
            foreach (var term in facts.Keys){
                    Dictionary<string, AndNode> and_dict = new Dictionary<string, AndNode>();
                    Dictionary<string, OrNode> or_dict = new Dictionary<string, OrNode>();
                    OrNode root = new OrNode(term);
                    or_dict.Add(term, root);

                    Stack<Node> tree = new Stack<Node>();
                    tree.Push(root);

                    while (tree.Count != 0)
                    {
                        Node current = tree.Pop();
                        if (current is AndNode)
                        {
                            AndNode and_node = current as AndNode;
                            foreach (var f in rules[and_node.name].preconditions)
                                if (or_dict.ContainsKey(f))
                                {
                                    current.children.Add(or_dict[f]);
                                    or_dict[f].parents.Add(current);
                                }
                                else
                                {
                                    or_dict.Add(f, new OrNode(f));
                                    and_node.children.Add(or_dict[f]);
                                    or_dict[f].parents.Add(and_node);
                                    tree.Push(or_dict[f]);
                                }
                        }
                        else // current is OrNode
                        {
                            OrNode or_node = current as OrNode;
                            foreach (var rule in findRules(or_node.name, facts.Keys.ToList()))
                                if (and_dict.ContainsKey(rule))
                                {
                                    current.children.Add(and_dict[rule]);
                                    and_dict[rule].parents.Add(current);
                                }
                                else
                                {
                                    and_dict.Add(rule, new AndNode(rule));
                                    or_node.children.Add(and_dict[rule]);
                                    and_dict[rule].parents.Add(or_node);
                                    tree.Push(and_dict[rule]);
                                }
                        }
                    }

                    int cnt = 0;
                    foreach (var f in or_dict)
                        if (known_facts.Contains(f.Key))
                            ++cnt;

                    foreach (var val in or_dict)
                        if (known_facts.Contains(val.Key))
                        {
                            val.Value.flag = true;
                            foreach (Node p in val.Value.parents)
                                resolve(p);
                        if (root.flag == true)
                        {
                            resId.Add(root.name);
                            if (root.name == need_right)
                                return Tuple.Create(true, resId);
                        }
                    }
                }

            return Tuple.Create(false, resId);
        }

        private void load() {
            foreach (var item in facts.Keys)
            {
                if (item.First() == 'T')
                    checkedListBoxT.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'S')
                    checkedListBoxS.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'P')
                    checkedListBoxP.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'C')
                    checkedListBoxС.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'W')
                    checkedListBoxW.Items.Add("" + item + ": " + facts[item]);
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

        private bool agenda(ref Dictionary<string, Rule> w, ref List<string> f)
        {
            bool res = false;
            foreach (var i in w)
                if (i.Value.compare(f)) {
                    var ft = i.Value.consequence;
                    if (!f.Contains(ft)) {
                        f.Add(i.Value.consequence);
                        res = true;
                        textBox2.Text += i.Value.forward_print() + System.Environment.NewLine;
                        string dr = i.Value.isDragon();
                        if (dr != "")
                            listBox1.Items.Add(dr);
                    }
                }
            return res;
        }

        private Tuple<bool, List<string>> ret_agenda(Dictionary<string, Rule> w)
        {
            string s = comboBox1.SelectedItem.ToString();
            List<string> list = new List<string>();
            string need_f = comboBox1.SelectedItem.ToString().Split(':')[0].Trim(' ');
            
            List<string> first_facts = new List<string>();
            foreach (var i in summary.Items)
                first_facts.Add(i.ToString().Split(':')[0].Trim(' '));
            var res = backward_reasoning(first_facts, need_f);
            return res;
        }

        private void start_click_old()
        {
            textBox2.Text = "";
            List<string> in_fact = new List<string>();
            foreach (var i in summary.Items)
                in_fact.Add(i.ToString().Split(':')[0].Trim(' '));
            if (!checkBox1.Checked)
                while (agenda(ref rules, ref in_fact)) { }
            else
            {
                var r = ret_agenda(rules);
                textBox2.Text = "Можно вывести дракона? " + (r.Item1 ? "Да" : "Нет");

                if (r.Item1)
                    foreach (var id in r.Item2.Distinct().OrderByDescending(s => s).ToList())
                        textBox2.Text += System.Environment.NewLine + facts[id];
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            //start_click_old()
            start_click_new();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            summary.Items.Clear();
            textBox2.Text = "";
            if (checkBox1.Checked){
                label4.Text = "Выберите финальный факт";
                listBox1.Visible = false;
                comboBox1.Visible = true;
                //checkedListBoxF.Enabled = false;
            }
            else{
                label4.Text = "Выведенные драконы";
                listBox1.Visible = true;
                comboBox1.Visible = false;
                //checkedListBoxF.Enabled = true;
            }
        }

        private void reload_old() {
            checkedListBoxT.Items.Clear();
            checkedListBoxS.Items.Clear();
            checkedListBoxP.Items.Clear();
            checkedListBoxС.Items.Clear();
            checkedListBoxW.Items.Clear();
            //checkedListBoxF.Items.Clear();
            checkedListBoxO.Items.Clear();
            checkedListBoxG.Items.Clear();

            checkedListBoxT.Visible = true;
            checkedListBoxS.Visible = true;
            checkedListBoxP.Visible = true;
            checkedListBoxС.Visible = true;
            checkedListBoxW.Visible = true;
            checkedListBoxO.Visible = true;
            checkedListBoxG.Visible = true;

            summary.Items.Clear();
            listBox1.Items.Clear();
            textBox2.Text = "";
            load();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reload_old();
            reload_new();
        }

        private void checkedListBoxT_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxT.SelectedItem);
            checkedListBoxT.Items.Remove(checkedListBoxT.SelectedItem);
            checkedListBoxT.Visible = false;
        }
        private void checkedListBoxS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxS.SelectedItem);
            checkedListBoxS.Items.Remove(checkedListBoxS.SelectedItem);
            checkedListBoxS.Visible = false;
        }
        private void checkedListBoxP_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxP.SelectedItem);
            checkedListBoxP.Items.Remove(checkedListBoxP.SelectedItem);
            checkedListBoxP.Visible = false;
        }
        private void checkedListBoxC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxС.SelectedItem);
            checkedListBoxС.Items.Remove(checkedListBoxС.SelectedItem);
            checkedListBoxС.Visible = false;
        }
        /*private void checkedListBoxF_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxF.SelectedItem);
            checkedListBoxF.Items.Remove(checkedListBoxF.SelectedItem);
        }*/
        private void checkedListBoxW_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxW.SelectedItem);
            checkedListBoxW.Items.Remove(checkedListBoxW.SelectedItem);
            checkedListBoxW.Visible = false;
        }
        private void checkedListBoxO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxO.SelectedItem);
            checkedListBoxO.Items.Remove(checkedListBoxO.SelectedItem);
            checkedListBoxO.Visible = false;
        }
        private void checkedListBoxG_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            summary.Items.Add(checkedListBoxG.SelectedItem);
            checkedListBoxG.Items.Remove(checkedListBoxG.SelectedItem);
            checkedListBoxG.Visible = false;
        }

        private void return_facts(char rem)
        {
            switch (rem)
            {
                case 'T':
                    checkedListBoxT.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    checkedListBoxT.Visible = true;
                    break;
                case 'S':
                    checkedListBoxS.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    checkedListBoxS.Visible = true;
                    break;
                case 'P':
                    checkedListBoxP.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    checkedListBoxP.Visible = true;
                    break;
                case 'C':
                    checkedListBoxС.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    checkedListBoxС.Visible = true;
                    break;
                /*case 'F':
                    checkedListBoxF.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    break;*/
                case 'W':
                    checkedListBoxW.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    checkedListBoxW.Visible = true;
                    break;
                case 'O':
                    checkedListBoxO.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    checkedListBoxO.Visible = true;
                    break;
                case 'G':
                    checkedListBoxG.Items.Add(summary.SelectedItem);
                    summary.Items.Remove(summary.SelectedItem);
                    checkedListBoxG.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void summary_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var rem = summary.SelectedItem.ToString()[0];
            return_facts(rem);
        }

        private void mode_TextChanged(object sender, EventArgs e)
        {
            //reload_old();
            reload_new();
        }




        private CLIPSNET.Environment clips = new CLIPSNET.Environment();

        private void HandleResponse()
        {
            //  Вытаскиаваем факт из ЭС
            String evalStr = "(find-fact ((?f ioproxy)) TRUE)";
            FactAddressValue fv = (FactAddressValue)((MultifieldValue)clips.Eval(evalStr))[0];

            MultifieldValue damf = (MultifieldValue)fv["messages"];
            MultifieldValue vamf = (MultifieldValue)fv["answers"];

            textBox2.Text += "Новая итерация : " + System.Environment.NewLine;
            for (int i = 0; i < damf.Count; i++)
            {
                LexemeValue da = (LexemeValue)damf[i];
                byte[] bytes = Encoding.Default.GetBytes(da.Value);
                textBox2.Text += Encoding.UTF8.GetString(bytes) + System.Environment.NewLine;
            }

            if (vamf.Count > 0)
            {
                textBox2.Text += "----------------------------------------------------" + System.Environment.NewLine;
                for (int i = 0; i < damf.Count; i++)
                {

                    LexemeValue va = (LexemeValue)vamf[i];
                    textBox2.Text += va.Value + System.Environment.NewLine;
                }
            }

            clips.Eval("(assert (clearmessage))");
        }

        private string add_rule(int num_rule,
            List<string> precond_properties, 
            string property)
        {
            string rule = "";
            rule += "(defrule r" + num_rule.ToString() + System.Environment.NewLine;
            rule += "   (declare(salience 30))" + System.Environment.NewLine;
            rule += "   ?p1 <- (dragon (name ?name1)" + System.Environment.NewLine;

            List<string> pr_values = new List<string>();
            pr_values.Add("(category ?category1");
            pr_values.Add("(color ?color1");
            pr_values.Add("(location ?location1");
            pr_values.Add("(feature ?feature1");
            pr_values.Add("(goal ?goal1");
            pr_values.Add("(weather ?weather1");
            pr_values.Add("(fire ?fire1");

            for (int i = 0; i < precond_properties.Count(); ++i)
            {
                int num_property = -1;
                if (precond_properties[i] != "")
                {
                    string precond_value =
                        facts[precond_properties[i]].Split('\"')[1].Replace(' ', '_');
                    switch (precond_properties[i].First())
                    {
                        case 'T':
                            num_property = 0;
                            //pr_values[0] += "&" + precond_value;
                            break;
                        case 'C':
                            num_property = 1;
                            //pr_values[1] += "&" + precond_value;
                            break;
                        case 'S':
                            num_property = 2;
                            //pr_values[2] += "&" + precond_value;
                            break;
                        case 'O':
                            num_property = 3;
                            //pr_values[3] += "&" + precond_value;
                            break;
                        case 'G':
                            num_property = 4;
                            //pr_values[4] += "&" + precond_value;
                            break;
                        case 'W':
                            num_property = 5;
                            //pr_values[5] += "&" + precond_value;
                            break;
                        case 'P':
                            num_property = 6;
                            //pr_values[6] += "&" + precond_value;
                            break;
                    }
                    if (num_property != -1)
                    {
                        pr_values[num_property] +=
                            ((pr_values[num_property].Last() == '1') ? "&" : "|") +
                            precond_value;
                    }
                }
            }

            for(int i = 0; i < pr_values.Count(); ++i)
            {
                pr_values[i] = "        " + pr_values[i] + ")"
                    + System.Environment.NewLine;
                rule += pr_values[i];
            }

            rule += "   )" + System.Environment.NewLine;
            rule += "   =>" + System.Environment.NewLine;
            rule += "   (assert (dragon" + System.Environment.NewLine;
            
            pr_values.Clear();
            pr_values.Add("     (category ?category1)" + System.Environment.NewLine);
            pr_values.Add("     (color ?color1)" + System.Environment.NewLine);
            pr_values.Add("     (location ?location1)" + System.Environment.NewLine);
            pr_values.Add("     (feature ?feature1)" + System.Environment.NewLine);
            pr_values.Add("     (goal ?goal1)" + System.Environment.NewLine);
            pr_values.Add("     (weather ?weather1)" + System.Environment.NewLine);
            pr_values.Add("     (fire ?fire1)" + System.Environment.NewLine);

            string value = facts[property].Split('\"')[1].Replace(' ', '_');
            switch (property.First())
            {
                case 'F':
                    rule += "       (name " + value + ")))" 
                        + System.Environment.NewLine;
                    rule += ")" + System.Environment.NewLine;
                    return rule;
                case 'T':
                    pr_values[0] = "     (category " + value + ")"
                        + System.Environment.NewLine;
                    break;
                case 'C':
                    pr_values[1] = "     (color " + value + ")"
                        + System.Environment.NewLine;
                    break;
                case 'S':
                    pr_values[2] = "     (location " + value + ")"
                        + System.Environment.NewLine;
                    break;
                case 'O':
                    pr_values[3] = "     (feature " + value + ")"
                        + System.Environment.NewLine;
                    break;
                case 'G':
                    pr_values[4] = "     (goal " + value + ")"
                        + System.Environment.NewLine;
                    break;
                case 'W':
                    pr_values[5] = "     (weather " + value + ")"
                        + System.Environment.NewLine;
                    break;
                case 'P':
                    pr_values[6] = "     (fire " + value + ")"
                        + System.Environment.NewLine;
                    break;
            }

            string end = pr_values.Aggregate((s1, s2) => s1 + s2);
            rule += end;
            rule += "   ))" + System.Environment.NewLine;
            rule += ")" + System.Environment.NewLine;

            return rule;
        }

        private string add_start_values_of_properties(List<string> property)
        {
            string fact = "(defrule add-fact " + System.Environment.NewLine;
            fact += "   (declare (salience 35)) " + System.Environment.NewLine;
            fact += "   => " + System.Environment.NewLine;
            fact += "   (assert (dragon";
            for (int i = 0; i < property.Count(); ++i)
            {
                string value = facts[property[i]];
                value = value.Split('\"')[1].Replace(' ', '_');
                switch (property[i].First())
                {
                    case 'T':
                        fact += " (category " + value + ")";
                        break;
                    case 'C':
                        fact += " (color " + value + ")";
                        break;
                    case 'S':
                        fact += " (location " + value + ")";
                        break;
                    case 'O':
                        fact += " (feature " + value + ")";
                        break;
                    case 'G':
                        fact += " (goal " + value + ")";
                        break;
                    case 'W':
                        fact += " (weather " + value + ")";
                        break;
                    case 'P':
                        fact += " (fire " + value + ")";
                        break;
                }
            }
            fact += ")) " + System.Environment.NewLine;
            fact += ") " + System.Environment.NewLine;
            return fact;
        }

        private string text_to_add()
        {
            string text = "";

            List<string> in_fact_property = new List<string>();
            //List<string> in_fact_value = new List<string>();
            foreach (var i in summary.Items)
            {
                in_fact_property.Add(i.ToString().Split(':')[0].Trim(' '));
                //in_fact_value.Add(i.ToString().Split('\"')[1].Replace(' ', '_'));
            }

            string fact = add_start_values_of_properties(in_fact_property);

            //text += add_rule(1, new List<string>() { "W2", "P4" }, "F1");
            //text += add_rule(2, new List<string>() { "T2", "S4" }, "P4");
            int num_rule = 1;
            foreach (var rule in rules.Values)
            {
                text += add_rule(num_rule, rule.preconditions, rule.consequence);
                ++num_rule;
            }

            text += fact;
            return text;
        }

        private void start_click_new()
        {
            clips.Run();
            HandleResponse();
        }

        

        private void reload_new()
        {
            

            textBox2.Text = "Выполнены команды Clear и Reset." + System.Environment.NewLine;
            //  Здесь сохранение в файл, и потом инициализация через него
            clips.Clear();

            string stroka = System.IO.File.ReadAllText("..//..//dragons.clp");
            string text = text_to_add();
            stroka += text;
            //= codeBox.Text;
            //System.IO.File.WriteAllText("tmp.clp", codeBox.Text);
            //clips.Load("dragons.clp");

            System.IO.File.WriteAllText("..//..//rules_clips.txt", stroka);

            //  Так тоже можно - без промежуточного вывода в файл
            clips.LoadFromString(stroka);

            clips.Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reload_new();
        }

        private void checkedListBoxP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reload_old();
        }
    }
}
