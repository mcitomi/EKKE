using System.ComponentModel;

namespace Gepkocsik
{

    public partial class Form1 : Form
    {
        private BindingList<Gepkocsi> lista = new BindingList<Gepkocsi>();

        public Form1()
        {
            InitializeComponent();
            dgv.DataSource = lista;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lista.Clear();
            StreamReader sr = new("Gepkocsik.csv");

            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(';');

                lista.Add(new Gepkocsi(
                    line[0],
                    int.Parse(line[1]),
                    int.Parse(line[2]),
                    int.Parse(line[3]),
                    int.Parse(line[4]),
                    (AllapotEnum)Enum.Parse(typeof(AllapotEnum), line[5])
                ));
            }

            sr.Close();
            MessageBox.Show("Beolvasva");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();

            if (f.ShowDialog() == DialogResult.OK)
            {
                lista.Add(f.UjAuto);
            }
        }
    }
}
