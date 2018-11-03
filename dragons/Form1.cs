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
        public Form1()
        {
            InitializeComponent();

            SortedDictionary<string, string> d = get_dictionary("..//..//facts.txt");

            foreach (var item in d.Keys)
            {
                if (item.First() == 'T')
                {
                    checkedListBoxT.Items.Add("" + item + ": " + d[item]);
                }
                if (item.First() == 'S')
                {
                    checkedListBoxS.Items.Add("" + item + ": " + d[item]);
                }
                if (item.First() == 'P')
                {
                    checkedListBoxP.Items.Add("" + item + ": " + d[item]);
                }
                if (item.First() == 'Z')
                {
                    checkedListBoxZ.Items.Add("" + item + ": " + d[item]);
                }
                if (item.First() == 'C')
                {
                    checkedListBoxС.Items.Add("" + item + ": " + d[item]);
                }
                if (item.First() == 'W')
                {
                    checkedListBoxW.Items.Add("" + item + ": " + d[item]);
                }
                if (item.First() == 'F')
                {
                    checkedListBoxF.Items.Add("" + item + ": " + d[item]);
                }
                if (item.First() == 'O')
                {
                    checkedListBoxO.Items.Add("" + item + ": " + d[item]);
                }
                if (item.First() == 'G')
                {
                    checkedListBoxG.Items.Add("" + item + ": " + d[item]);
                }
            }
        }

        private SortedDictionary<string, string> get_dictionary(string fname)
        {
          
            SortedDictionary<string, string> d = new SortedDictionary<string, string>();
            using (StreamReader fs = new StreamReader(fname))
            {
                while (true)
                {
                    string temp = fs.ReadLine();

                    if (temp == null) break;

                    string[] strs = temp.Split(':');
                    d.Add(strs[0], strs[1]);
                }
            }
            return d;
        }        
    }
}
