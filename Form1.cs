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

namespace ObjN64Convert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sFileName = "";
            OpenFileDialog loadobj = new OpenFileDialog();
            loadobj.Filter = "Obj Files (*.obj)|*.obj";
            loadobj.FilterIndex = 1;

            if (loadobj.ShowDialog() == DialogResult.OK)
            {
                sFileName = loadobj.FileName;        
            } 
            this.Hide();
            Form2 frm2 = new Form2(loadobj.FileName);
            frm2.ShowDialog();
            this.Close();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
