using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio4_Verifica_29042020
{
    class DBClientiOrdini
    {
        public string Errore { get; set; }
        public string StringaDiConnessione { get; set; }

        public DBClientiOrdini()
        {
            Errore = "";
            StringaDiConnessione = ConfigurationSettings.AppSettings["StringaDiConnessione"];
        }

        public int InserisciCliente(Cliente cliente)
        {
            int n = 0;
            try
            {
                //Creazione della connessione con il db e inserimento del cliente
                using (SqlConnection con = new SqlConnection(StringaDiConnessione))
                {
                    con.Open();
                    string query = "INSERT INTO Clienti(RagioneSociale, Telefono, Indirizzo, Citta, CAP, Email) " + //Creazione della query
                        "VALUES(@ragioneSociale,@telefono,@indirizzo,@citta,@cap,@email)";
                    SqlCommand cmd = new SqlCommand(query, con); //esecuzione della query
                    cmd.Parameters.AddWithValue("@ragioneSociale", cliente.RagioneSociale);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@indirizzo", cliente.Indirizzo);
                    cmd.Parameters.AddWithValue("@citta", cliente.Citta);
                    cmd.Parameters.AddWithValue("@cap", cliente.CAP);
                    cmd.Parameters.AddWithValue("@email", cliente.Email);
                    n = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Errore = ex.Message;
            }
            return n;
        }

        public int InserisciOrdine(Ordine ordine)
        {
            int n = 0;
            try
            {
                //Creazione della connessione al db per inserire l'ordine
                using (SqlConnection con = new SqlConnection(StringaDiConnessione))
                {
                    con.Open();
                    string query = "INSERT INTO Ordini(DataOrdine, DataSpedizione, StatoOrdine, Prodotto, QuantitaOrdinata, Prezzo, IdCliente) " +
                        "VALUES(@dataordine,@dataspedizione,@statoordine,@prodotto,@quantitaordinata,@prezzo, @idcliente)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dataordine", ordine.DataOrdine);
                    cmd.Parameters.AddWithValue("@dataspedizione", ordine.DataSpedizione);
                    cmd.Parameters.AddWithValue("@statoordine", ordine.StatoOrdine);
                    cmd.Parameters.AddWithValue("@prodotto", ordine.Prodotto);
                    cmd.Parameters.AddWithValue("@quantitaordinata", ordine.QuantitaOrdinata);
                    cmd.Parameters.AddWithValue("@prezzo", ordine.Prezzo);
                    cmd.Parameters.AddWithValue("@idcliente", ordine.IdCliente);
                    n = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Errore = ex.Message;
            }
            return n;
        }

        public List<Cliente> getClienti()
        {
            List<Cliente> clienti = new List<Cliente>();
            try
            {
                using (SqlConnection con = new SqlConnection(StringaDiConnessione))
                {
                    con.Open(); //connessione al db
                    string query = "SELECT * FROM Clienti"; //creazione della query
                    SqlCommand cmd = new SqlCommand(query, con); //esecuzione della query
                    SqlDataReader reader = cmd.ExecuteReader(); //il reader legge tutti i valori estratti dalla query

                    Cliente c;

                    while (reader.Read()) //Inserimento dei dati presi dal db in una lista di clienti
                    {
                        c = new Cliente();

                        c.IdCliente = (int)reader["IdCliente"];
                        c.RagioneSociale = (string)reader["RagioneSociale"];
                        c.Telefono = (string)reader["Telefono"];
                        c.Indirizzo = (string)reader["Indirizzo"];
                        c.Citta = (string)reader["citta"];
                        c.CAP = (string)reader["CAP"];
                        c.Email = (string)reader["Email"];

                        clienti.Add(c);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Errore = ex.Message;
                Console.Write(ex.Message);
            }

            return clienti; //restituzione della lista di clienti che verrà poi visualizzata nel form.
        }

        public List<Ordine> getOrdini()
        {
            List<Ordine> ordini = new List<Ordine>();
            try
            {
                using (SqlConnection con = new SqlConnection(StringaDiConnessione))
                {
                    con.Open();
                    string query = "SELECT * FROM Ordini";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Ordine o;

                    while (reader.Read())
                    {
                        o = new Ordine();

                        o.IdOrdine = (int)reader["IdOrdine"];
                        o.DataOrdine = (DateTime)reader["DataOrdine"];
                        o.DataSpedizione = (DateTime)reader["DataSpedizione"];
                        o.StatoOrdine = (string)reader["StatoOrdine"];
                        o.Prodotto = (string)reader["Prodotto"];
                        o.QuantitaOrdinata = (int)reader["QuantitaOrdinata"];
                        o.Prezzo = (int)reader["Prezzo"];
                        o.IdCliente = (int)reader["IdCliente"];

                        ordini.Add(o);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Errore = ex.Message;
                Console.Write(ex.Message);
            }

            return ordini;
        }


    }
}
