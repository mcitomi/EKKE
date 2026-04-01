using System.ComponentModel;

namespace Gepkocsik
{

    public partial class Form1 : Form
    {
        private Kereskedes keri = new Kereskedes();

        public Form1()
        {
            InitializeComponent();
            dgv.DataSource = keri.gepkocsik;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            keri.gepkocsik.Clear();
            StreamReader sr = new("Gepkocsik.csv");

            // 0.mező G v. SZ. -> milyen típusú a rekord

            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(';');

                if (line[0] == "G")
                {
                    keri.AddKocsi(new Gepkocsi(
                        line[1],
                        int.Parse(line[2]),
                        int.Parse(line[3]),
                        (AllapotEnum)AllapotEnum.Parse(typeof(AllapotEnum), line[4])
                    ));
                    
                }
                else
                {
                    keri.AddKocsi(new SzemelygepKocsi(
                        line[1],
                        int.Parse(line[2]),
                        int.Parse(line[3]),
                        (AllapotEnum)AllapotEnum.Parse(typeof(AllapotEnum), line[4]),
                        int.Parse(line[5]),
                        bool.Parse(line[6]),
                        (KlimaTipus)KlimaTipus.Parse(typeof(KlimaTipus), line[7])
                        ));
                }
            }

            sr.Close();
            MessageBox.Show("Beolvasva");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();

            if (f.ShowDialog() == DialogResult.OK)
            {
                keri.AddKocsi(f.UjAuto);
            }
        }
    }
}
