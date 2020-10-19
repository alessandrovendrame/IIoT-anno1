using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Vendrame.Esame.Finale
{
    public partial class Form1 : Form
    {
        public static string codiceBiglietto;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMacelleria_Click(object sender, EventArgs e)
        {
            List<Biglietto> biglietti = new List<Biglietto>();
            var client = new System.Net.WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var result = client.DownloadString("https://localhost:44305/api/Biglietti/M");
            biglietti = JsonConvert.DeserializeObject<IEnumerable<Biglietto>>(result, new JsonSerializerSettings()).ToList();

            var numero = biglietti.LastOrDefault().IndexCode;

            numero += 1;

            Biglietto b = new Biglietto();

            b.SectionCode = "M";
            b.IndexCode = numero;

            var dati = JsonConvert.SerializeObject(b);

            client.UploadString("https://localhost:44305/api/Biglietti", "POST", dati);

            codiceBiglietto = "M" + numero;

            Form2 form2 = new Form2();
            form2.Show();
        }

        private void btnFrutta_Click(object sender, EventArgs e)
        {
            List<Biglietto> biglietti = new List<Biglietto>();
            var client = new System.Net.WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var result = client.DownloadString("https://localhost:44305/api/Biglietti/F");
            biglietti = JsonConvert.DeserializeObject<IEnumerable<Biglietto>>(result, new JsonSerializerSettings()).ToList();

            var numero = biglietti.LastOrDefault().IndexCode;

            numero += 1;

            Biglietto b = new Biglietto();

            b.SectionCode = "F";
            b.IndexCode = numero;

            codiceBiglietto = "F" + numero;

            var dati = JsonConvert.SerializeObject(b);

            client.UploadString("https://localhost:44305/api/Biglietti", "POST", dati);

            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Biglietto> biglietti = new List<Biglietto>();
            var client = new System.Net.WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var result = client.DownloadString("https://localhost:44305/api/Biglietti/P");
            biglietti = JsonConvert.DeserializeObject<IEnumerable<Biglietto>>(result, new JsonSerializerSettings()).ToList();

            var numero = biglietti.LastOrDefault().IndexCode;

            numero += 1;

            Biglietto b = new Biglietto();

            b.SectionCode = "P";
            b.IndexCode = numero;

            codiceBiglietto = "P" + numero;

            var dati = JsonConvert.SerializeObject(b);

            client.UploadString("https://localhost:44305/api/Biglietti", "POST", dati);

            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
