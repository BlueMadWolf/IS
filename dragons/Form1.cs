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
        }

        private Dictionary<string, string> get_dictionary(string fname)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            using (StreamReader fs = new StreamReader(fname))
            {
                while (true)
                {
                    string temp = fs.ReadLine();

                    if (temp == null) break;

                    string[] strs = temp.Split(':');
                    d[strs[0]] = d[strs[1]];
                }
            }
            return d;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Dictionary<string, string> d = get_dictionary("facts.txt");
        }
    }
}
