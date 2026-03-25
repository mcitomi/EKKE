using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepkocsik
{
    public class Form2 : Form
    {
        TextBox txtRendszam, txtEvjarat, txtAr, txtKor, txtExtra;
        ComboBox cmbAllapot;
        Button btnMentes;

        public Gepkocsi UjAuto { get; private set; }

        public Form2()
        {
            this.Text = "Új autó";
            this.Size = new Size(300, 350);

            Label l1 = new Label() { Text = "Rendszám", Location = new Point(10, 20) };
            txtRendszam = new TextBox() { Location = new Point(120, 20) };

            Label l2 = new Label() { Text = "Évjárat", Location = new Point(10, 50) };
            txtEvjarat = new TextBox() { Location = new Point(120, 50) };

            Label l3 = new Label() { Text = "Ár", Location = new Point(10, 80) };
            txtAr = new TextBox() { Location = new Point(120, 80) };

            Label l4 = new Label() { Text = "Kor", Location = new Point(10, 110) };
            txtKor = new TextBox() { Location = new Point(120, 110) };

            Label l5 = new Label() { Text = "Extra ár", Location = new Point(10, 140) };
            txtExtra = new TextBox() { Location = new Point(120, 140) };

            Label l6 = new Label() { Text = "Állapot", Location = new Point(10, 170) };
            cmbAllapot = new ComboBox()
            {
                Location = new Point(120, 170),
                DataSource = Enum.GetValues(typeof(AllapotEnum))
            };

            btnMentes = new Button()
            {
                Text = "Mentés",
                Location = new Point(100, 220)
            };

            btnMentes.Click += BtnMentes_Click;

            this.Controls.Add(l1);
            this.Controls.Add(txtRendszam);
            this.Controls.Add(l2);
            this.Controls.Add(txtEvjarat);
            this.Controls.Add(l3);
            this.Controls.Add(txtAr);
            this.Controls.Add(l4);
            this.Controls.Add(txtKor);
            this.Controls.Add(l5);
            this.Controls.Add(txtExtra);
            this.Controls.Add(l6);
            this.Controls.Add(cmbAllapot);
            this.Controls.Add(btnMentes);
        }

        private void BtnMentes_Click(object sender, EventArgs e)
        {
            try
            {
                UjAuto = new Gepkocsi(
                    txtRendszam.Text,
                    int.Parse(txtEvjarat.Text),
                    int.Parse(txtAr.Text),
                    int.Parse(txtKor.Text),
                    int.Parse(txtExtra.Text),
                    (AllapotEnum)cmbAllapot.SelectedItem
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Hibás adat!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


}
