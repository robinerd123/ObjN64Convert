using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjN64Convert
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string c1;
            string c2;
            string c3;
            string b1;
            string b2;
            string b3;
            using (var reader = new System.IO.StreamReader(System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/p.tmp")))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line.StartsWith("vn "))
                    {

                        c1 = line.Split(' ', ' ')[1];
                        b1 = c1.Replace(".", "");
                        b1 = string.Concat(b1.Reverse().Skip(4).Reverse());
                        c2 = line.Split(' ', ' ')[2];
                        b2 = c2.Replace(".", "");
                        b2 = string.Concat(b2.Reverse().Skip(4).Reverse());
                        c3 = line.Split(' ', ' ')[3];
                        b3 = c3.Replace(".", "");
                        b3 = string.Concat(b3.Reverse().Skip(4).Reverse());
                        MessageBox.Show(b1 + ", " + b2 + ", " + b3 + "");
                    }
                }

                reader.Close();
            }
        }
    }
}
