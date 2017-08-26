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
    public partial class Form2 : Form
    {

        public string objPath;
        public Form2(string obj)
        {
            objPath = obj;
            InitializeComponent();
        }
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 135,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 10, Top = 10, Text = text };
            TextBox textBox = new TextBox() { Left = 10, Top = 35, Width = 265 };
            Button confirmation = new Button() { Text = "OK", Left = 175, Width = 100, Top = 65, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.BackgroundImage = ObjN64Convert.Properties.Resources._2;
            prompt.BackgroundImageLayout = ImageLayout.Stretch;
            textLabel.BackColor = System.Drawing.Color.Transparent;
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            var prompt1 = ShowDialog("Vertex array name", "vertex array name");
            if (prompt1=="") {
                return;
            }
            int a = -1;
            string c1;
            string c2;
            string c3;
            string b1;
            string b2;
            string b3;
            string result = "Vtx " + prompt1 + "__v[] = {";
            int a1;
            int a2;
            int a3;
            string line2;
            string[] lines = System.IO.File.ReadAllLines(objPath);
            foreach (string line in lines)
            {
                a++;
                if (line.StartsWith("vn "))
                { break; }
            }
            foreach (string line in lines)
            {
                ; if (line.StartsWith("v "))
                {
                    c1 = line.Split(' ', ' ')[1];
                    b1 = c1.Replace(".", "");
                    b1 = string.Concat(b1.Reverse().Skip(5).Reverse());
                    while (b1.Length > 2 && b1[0] == '-' && b1[1] == '0')
                    {
                        b1 = b1.Remove(1, 1);
                    }
                    while (b1.Length > 1 && b1[0] == '0')
                    {
                        b1 = b1.Remove(0, 1);
                    }
                    c2 = line.Split(' ', ' ')[2];
                    b2 = c2.Replace(".", "");
                    b2 = string.Concat(b2.Reverse().Skip(5).Reverse());
                    while (b2.Length > 2 && b2[0] == '-' && b2[1] == '0')
                    {
                        b2 = b2.Remove(1, 1);
                    }
                    while (b2.Length > 1 && b2[0] == '0')
                    {
                        b2 = b2.Remove(0, 1);
                    }
                    c3 = line.Split(' ', ' ')[3];
                    b3 = c3.Replace(".", "");
                    b3 = string.Concat(b3.Reverse().Skip(5).Reverse());
                    while (b3.Length > 2 && b3[0] == '-' && b3[1] == '0')
                    {
                        b3 = b3.Remove(1, 1);
                    }
                    while (b3.Length > 1 && b3[0] == '0')
                    {
                        b3 = b3.Remove(0, 1);
                    }
                    string vline = "{" + b1 + "," + b2 + "," + b3 + ",0,0,0,";
                    line2 = lines[a];
                    if (line2.StartsWith("vn "))
                    {

                        c1 = line2.Split(' ', ' ')[1];
                        b1 = c1.Replace(".", "");
                        b1 = string.Concat(b1.Reverse().Skip(2).Reverse());
                        while (b1.Length > 2 && b1[0] == '-' && b1[1] == '0')
                        {
                            b1 = b1.Remove(1, 1);
                        }
                        while (b1.Length > 1 && b1[0] == '0')
                        {
                            b1 = b1.Remove(0, 1);
                        }


                        c2 = line2.Split(' ', ' ')[2];
                        b2 = c2.Replace(".", "");
                        b2 = string.Concat(b2.Reverse().Skip(2).Reverse());
                        while (b2.Length > 2 && b2[0] == '-' && b2[1] == '0')
                        {
                            b2 = b2.Remove(1, 1);
                        }
                        while (b2.Length > 1 && b2[0] == '0')
                        {
                            b2 = b2.Remove(0, 1);
                        }

                        c3 = line2.Split(' ', ' ')[3];
                        b3 = c3.Replace(".", "");
                        b3 = string.Concat(b3.Reverse().Skip(2).Reverse());
                        while (b3.Length > 2 && b3[0] == '-' && b3[1] == '0')
                        {
                            b3 = b3.Remove(1, 1);
                        }
                        while (b3.Length > 1 && b3[0] == '0')
                        {
                            b3 = b3.Remove(0, 1);
                        }
                        vline = vline + b1 + "," + b2 + "," + b3 + ",255},";
                        result = result + "\r\n" + vline;
                        a++;
                    }




                }

            }
            result = result + "\r\n};";
            System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/source.h", result);
            System.Diagnostics.Process.Start("notepad.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/source.h");
            result = "";
            int b = 0;
            int bv = 32;
            foreach (string line in lines)
            {
                if (line.StartsWith("f "))
                {
                    if(b == bv)
                    {
                        result = result + "\r\n" + "";
                    }
                    c1 = line.Split(' ', ' ')[1];
                    c1 = c1.Split('/')[0];
                    a1 = int.Parse(c1) - 1;
                    c1 = a1.ToString();
                    c2 = line.Split(' ', ' ')[2];
                    c2 = c2.Split('/')[0];
                    a2 = int.Parse(c2) - 1;
                    c2 = a2.ToString();
                    c3 = line.Split(' ', ' ')[3];
                    c3 = c3.Split('/')[0];
                    a3 = int.Parse(c3) - 1;
                    c3 = a3.ToString();
                    string vline = "gsSP1Triangle(" + c1 + "," + c2 + "," + c3 + ",0),";
                        result = result + "\r\n" + vline;
                    b++;

                }



            }
            result = result + "\r\n";
            System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/source.c", result);
            System.Diagnostics.Process.Start("notepad.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/source.c");
            System.Diagnostics.Process.GetCurrentProcess().Kill();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int a = -1;
            string c1;
            string c2;
            string c3;
            string b1;
            string b2;
            string b3;
            string result = "Vtx unknown__v[] = {";
            int a1;
            int a2;
            int a3;
            string line2;
            string[] lines = System.IO.File.ReadAllLines(objPath);
            foreach (string line in lines)
            {
                a++;
                if (line.StartsWith("vn "))
                { break; }
            }
            foreach (string line in lines)
            {
                ; if (line.StartsWith("v "))
                {
                    c1 = line.Split(' ', ' ')[1];
                    b1 = c1.Replace(".", "");
                    b1 = string.Concat(b1.Reverse().Skip(5).Reverse());
                    while (b1.Length > 2 && b1[0] == '-' && b1[1] == '0')
                    {
                        b1 = b1.Remove(1, 1);
                    }
                    while (b1.Length > 1 && b1[0] == '0')
                    {
                        b1 = b1.Remove(0, 1);
                    }
                    c2 = line.Split(' ', ' ')[2];
                    b2 = c2.Replace(".", "");
                    b2 = string.Concat(b2.Reverse().Skip(5).Reverse());
                    while (b2.Length > 2 && b2[0] == '-' && b2[1] == '0')
                    {
                        b2 = b2.Remove(1, 1);
                    }
                    while (b2.Length > 1 && b2[0] == '0')
                    {
                        b2 = b2.Remove(0, 1);
                    }
                    c3 = line.Split(' ', ' ')[3];
                    b3 = c3.Replace(".", "");
                    b3 = string.Concat(b3.Reverse().Skip(5).Reverse());
                    while (b3.Length > 2 && b3[0] == '-' && b3[1] == '0')
                    {
                        b3 = b3.Remove(1, 1);
                    }
                    while (b3.Length > 1 && b3[0] == '0')
                    {
                        b3 = b3.Remove(0, 1);
                    }
                    string vline = "{" + b1 + "," + b2 + "," + b3 + ",0,0,0,";
                    line2 = lines[a];
                    if (line2.StartsWith("vn "))
                    {

                        c1 = line2.Split(' ', ' ')[1];
                        b1 = c1.Replace(".", "");
                        b1 = string.Concat(b1.Reverse().Skip(2).Reverse());
                        while (b1.Length > 2 && b1[0] == '-' && b1[1] == '0')
                        {
                            b1 = b1.Remove(1, 1);
                        }
                        while (b1.Length > 1 && b1[0] == '0')
                        {
                            b1 = b1.Remove(0, 1);
                        }


                        c2 = line2.Split(' ', ' ')[2];
                        b2 = c2.Replace(".", "");
                        b2 = string.Concat(b2.Reverse().Skip(2).Reverse());
                        while (b2.Length > 2 && b2[0] == '-' && b2[1] == '0')
                        {
                            b2 = b2.Remove(1, 1);
                        }
                        while (b2.Length > 1 && b2[0] == '0')
                        {
                            b2 = b2.Remove(0, 1);
                        }

                        c3 = line2.Split(' ', ' ')[3];
                        b3 = c3.Replace(".", "");
                        b3 = string.Concat(b3.Reverse().Skip(2).Reverse());
                        while (b3.Length > 2 && b3[0] == '-' && b3[1] == '0')
                        {
                            b3 = b3.Remove(1, 1);
                        }
                        while (b3.Length > 1 && b3[0] == '0')
                        {
                            b3 = b3.Remove(0, 1);
                        }
                        vline = vline + b1 + "," + b2 + "," + b3 + ",255},";
                        result = result + "\r\n" + vline;
                        a++;
                    }




                }

            }
            result = result + "\r\n};";
            System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/source.h", result);
            System.Diagnostics.Process.Start("notepad.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/source.h");
            result = "";
            int b = 0;
            int bv = 32;
            foreach (string line in lines)
            {
                if (line.StartsWith("f "))
                {
                    if (b == bv)
                    {
                        result = result + "\r\n" + "";
                    }
                    c1 = line.Split(' ', ' ')[1];
                    c1 = c1.Split('/')[0];
                    a1 = int.Parse(c1) - 1;
                    c1 = a1.ToString();
                    c2 = line.Split(' ', ' ')[2];
                    c2 = c2.Split('/')[0];
                    a2 = int.Parse(c2) - 1;
                    c2 = a2.ToString();
                    c3 = line.Split(' ', ' ')[3];
                    c3 = c3.Split('/')[0];
                    a3 = int.Parse(c3) - 1;
                    c3 = a3.ToString();
                    string vline = "gsSP1Triangle(" + c1 + "," + c2 + "," + c3 + ",0),";
                    result = result + "\r\n" + vline;
                    b++;

                }



            }
            result = result + "\r\n";
            System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/source.c", result);
            System.Diagnostics.Process.Start("notepad.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/source.c");
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Width = 826;
        }
    }
}