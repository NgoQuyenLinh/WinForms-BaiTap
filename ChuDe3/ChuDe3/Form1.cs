using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChuDe3
{
    public partial class frmJSon : Form
    {
        public frmJSon()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void WriteReadText(string filename, string []text)
        {
            File.WriteAllLines(filename, text);
            foreach(string s in File.ReadAllLines(filename))
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }

        private void btnReadJSON_Click(object sender, EventArgs e)
        {

        }
    }
}
