using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esercizio4_Verifica_29042020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnInserisciCliente_Click(object sender, EventArgs e) //Al click del pulsante inserisci si scatena l'evento
        {
            DBClientiOrdini db = new DBClientiOrdini();
            Cliente cliente = new Cliente();

            //Assegnazione dei dati al cliente

            cliente.RagioneSociale = txtRagioneSociale.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Indirizzo = txtIndirizzo.Text;
            cliente.Citta = txtCitta.Text;
            cliente.CAP = txtCAP.Text;
            cliente.Email = txtEmail.Text;

            //Inserimento del cliente nel DB

            db.InserisciCliente(cliente); 
        }

        private void btnInsertOrdine_Click(object sender, EventArgs e)
        {
            DBClientiOrdini db = new DBClientiOrdini();
            Ordine ordine = new Ordine();

            //Assegnazioni dei dati all'ordine

            ordine.DataOrdine = dtDataOrdine.Value;
            ordine.DataSpedizione = dtDataSpedizione.Value;
            ordine.StatoOrdine = txtStatoOrdine.Text;
            ordine.Prodotto = txtProdotto.Text;
            ordine.QuantitaOrdinata = int.Parse(txtQuantita.Text);
            ordine.Prezzo = int.Parse(txtQuantita.Text);
            ordine.IdCliente = int.Parse(txtIDCliente.Text);

            //Inserimento dell'ordine nel DB

            db.InserisciOrdine(ordine);
        }

        private void btnVisualizzaClienti_Click(object sender, EventArgs e)
        {
            DBClientiOrdini db = new DBClientiOrdini();
            List<Cliente> client = db.getClienti();

            GwVisualizzaC.DataSource = client; //In questo modo visualizzo tutti i dati presenti all'interno della tabella clienti
        }

        private void btnOrdini_Click(object sender, EventArgs e)
        {
            DBClientiOrdini db = new DBClientiOrdini();
            List<Ordine> ordini = db.getOrdini();

            GViewOrdini.DataSource = ordini; //In questo modo visualizzo tutti i dati presenti all'interno della tabella ordini
        }
    }
}
