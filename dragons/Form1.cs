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

        public Form1()
        {
            InitializeComponent();
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
                if (item.First() == 'Z')
                    checkedListBoxZ.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'C')
                    checkedListBoxС.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'W')
                    checkedListBoxW.Items.Add("" + item + ": " + facts[item]);
                if (item.First() == 'F'){
                    checkedListBoxF.Items.Add("" + item + ": " + facts[item]);
                    comboBox1.Items.Add("" + item + ": " + facts[item]);
                }
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
                        textBox2.Text += i.Value.forward_print() + Environment.NewLine;
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

        private void start_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            List<string> in_fact = new List<string>();
            foreach (var i in summary.Items)
                in_fact.Add(i.ToString().Split(':')[0].Trim(' '));
            if (!checkBox1.Checked)
                while (agenda(ref rules, ref in_fact)) { }
            else{
                var r = ret_agenda(rules);
                textBox2.Text = "Можно вывести дракона? " + (r.Item1 ? "Да" : "Нет");

                if (r.Item1)
                foreach (var id in r.Item2.Distinct().OrderByDescending(s => s).ToList())
                    textBox2.Text += Environment.NewLine + facts[id];
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            summary.Items.Clear();
            textBox2.Text = "";
            if (checkBox1.Checked){
                label4.Text = "Выберите финальный факт";
                listBox1.Visible = false;
                comboBox1.Visible = true;
                checkedListBoxF.Enabled = false;
            }
            else{
                label4.Text = "Выведенные драконы";
                listBox1.Visible = true;
                comboBox1.Visible = false;
                checkedListBoxF.Enabled = true;
            }
        }

        private void reload() {
            checkedListBoxT.Items.Clear();
            checkedListBoxS.Items.Clear();
            checkedListBoxP.Items.Clear();
            checkedListBoxZ.Items.Clear();
            checkedListBoxС.Items.Clear();
            checkedListBoxW.Items.Clear();
            checkedListBoxF.Items.Clear();
            checkedListBoxO.Items.Clear();
            checkedListBoxG.Items.Clear();
            summary.Items.Clear();
            listBox1.Items.Clear();
            textBox2.Text = "";
            load();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reload();
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

        private void return_facts(char rem)
        {
            switch (rem)
            {
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

        private void summary_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var rem = summary.SelectedItem.ToString()[0];
            return_facts(rem);
        }
    }
}
