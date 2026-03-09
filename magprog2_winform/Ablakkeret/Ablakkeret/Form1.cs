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
using WindowsShop; // Be kell hívni

namespace Ablakkeret
{
    public partial class Form1 : Form
    {
        BindingList<Window> WindowStore;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Demó app";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            StreamReader input = new StreamReader("ablakok.csv");

            while (!input.EndOfStream)
            {
                string line = input.ReadLine();

                listBox1.Items.Add(line);
            }
            input.Close();

            MessageBox.Show("Betöltve!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowStore = new BindingList<Window>();
            StreamReader sr = new StreamReader("ablakok.csv");

            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(';');
                WindowStore.Add(new Window(
                    line[0],
                    int.Parse(line[1]),
                    int.Parse(line[2]),
                    int.Parse(line[3])
                ));
            }

            sr.Close();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = WindowStore;

            MessageBox.Show("Ablakok betörve!");

        }
    }
}
