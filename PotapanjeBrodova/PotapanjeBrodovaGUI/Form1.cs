using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PotapanjeBrodova;


namespace PotapanjeBrodovaGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void NacrtajMrezu()
        {
            mreza = new Mreža(retci, stupci);
            if (poljaPrikaz != null)
            {
                foreach (PictureBox i in poljaPrikaz)
                {
                    glavniPanel.Controls.Remove(i);
                }
                foreach (Label i in labelContainer)
                {
                    glavniPanel.Controls.Remove(i);
                }
                labelContainer.Clear();
            }
            poljaPrikaz = new PictureBox[retci, stupci];
            labelContainer = new Stack<Label>();
            xPozicijaPolja = defaultX;
            yPozicijaPolja = defaultY;
            foreach (Polje i in mreza.polja)
            {
                DodajPoljeNaMrežu(i.Redak, i.Stupac);
                DodajBrojRetkaiStupcaNaMrežu(i.Redak, i.Stupac);

                if (i.Stupac < stupci - 1)
                {
                    xPozicijaPolja += offsetPolja;
                }
                else
                {
                    xPozicijaPolja = defaultX;
                    yPozicijaPolja += offsetPolja;
                }
            }
            porukeLabel.Text = "Mreža veličine " + retci + " x " + stupci + " iscratana";
            porukeLabel.Visible = true;

        }
        private void DodajPoljeNaMrežu(int redak, int stupac)
        {
            poljaPrikaz[redak, stupac] = new PictureBox();
            poljaPrikaz[redak, stupac].Size = velicinaPolja;
            poljaPrikaz[redak, stupac].Location = new Point(xPozicijaPolja, yPozicijaPolja);
            poljaPrikaz[redak, stupac].BackColor = Color.RoyalBlue;
            poljaPrikaz[redak, stupac].BringToFront();
            poljaPrikaz[redak, stupac].Visible = true;
            glavniPanel.Controls.Add(poljaPrikaz[redak, stupac]);
        }
        private void DodajBrojRetkaiStupcaNaMrežu(int redak, int stupac)
        {
            Label number = new Label();
            number.Size = velicinaPolja;
            if (redak == 0)
            {
                if (stupac == 0)
                {
                    Label left = new Label();
                    left.Size = velicinaPolja;
                    left.Location = new Point(xPozicijaPolja - offsetPolja, yPozicijaPolja);
                    left.Text = (redak + 1).ToString();
                    PostavkeLabele(left);
                }
                number.Location = new Point(xPozicijaPolja, defaultY - offsetPolja);
                number.Text = (stupac + 1).ToString();
            }
            else
            {
                number.Location = new Point(defaultX - offsetPolja, yPozicijaPolja);
                number.Text = (redak + 1).ToString();
            }
            PostavkeLabele(number);
        }
        private void PostavkeLabele(Label name)
        {
            name.TextAlign = ContentAlignment.MiddleCenter;
            name.BringToFront();
            name.Visible = true;
            glavniPanel.Controls.Add(name);
            labelContainer.Push(name);

        }
        private void Nacrtajbrodove()
        {
            brodograditelj = new Brodograditelj();
            IEnumerable<int> duljinaBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            flota = brodograditelj.SloziFlotu(mreza, duljinaBrodova);
            if (flota == null)
            {
                porukeLabel.Text = "Flotu nije moguće složiti u trenutačnu veličinu mreže!";
                porukeLabel.Visible = true;
                brodograditelj = null;
                return;
            }

            foreach (Brod brod in flota.brodovi)
            {
                IEnumerable<Polje> polja = brod.Polja;
                foreach (Polje polje in polja)
                {
                    poljaPrikaz[polje.Redak, polje.Stupac].BackColor = Color.ForestGreen;
                }
                 
            }
            postaviBrodoveButton.Enabled = false;
            porukeLabel.Text = "Flota postavljena!";
            porukeLabel.Visible = true;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            porukeLabel.Visible = false;
            stupci = (int)brojStupacaOdabir.Value;
            retci = (int)brojRedakaOdabir.Value;
            NacrtajMrezu();
            postaviBrodoveButton.Enabled = true;          
        }

        private void postaviBrodoveButton_Click(object sender, EventArgs e)
        {
            Nacrtajbrodove();
        }

        Mreža mreza;
        Brodograditelj brodograditelj;
        Flota flota;
        Size velicinaPolja = new Size(40, 40);
        int retci;
        int stupci;
        int offsetPolja = 41;
        int xPozicijaPolja;
        int yPozicijaPolja;
        int defaultX = 45;
        int defaultY = 45;
        private PictureBox[,] poljaPrikaz;
        private Stack<Label> labelContainer;

    }
}
