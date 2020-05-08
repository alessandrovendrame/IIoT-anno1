using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_20200422
{
    class dbProprietari
    {
        public string Errore { get; set; }
        public string StringaDiConnessione { get; set; }

        public dbProprietari()
        {
            Errore = "";
            StringaDiConnessione = ConfigurationSettings.AppSettings["StringaDiConnessione"];
        }

        public List<Proprietario> RecuperaTutti()
        {
            List<Proprietario> elenco = new List<Proprietario>();

            try
            {
                using (SqlConnection con = new SqlConnection(StringaDiConnessione))
                {
                    con.Open();
                    string query = "SELECT * FROM Proprietari INNER JOIN Automobili" +
                        " ON Proprietari.CodiceFiscale = Automobili.CodiceFiscaleProprietario" +
                        " ORDER BY Proprietari.CodiceFiscale";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Proprietario c = new Proprietario();
                    c.CodiceFiscale = null;

                    string CodiceFiscaleCorrente="";

                    while (reader.Read())
                    {
                        if(CodiceFiscaleCorrente!="")
                        {
                            c.CodiceFiscale = CodiceFiscaleCorrente;
                        }
                        CodiceFiscaleCorrente = (string)reader["CodiceFiscale"];
                        if (!CodiceFiscaleCorrente.Equals(c.CodiceFiscale))
                        {
                            c = new Proprietario();
                            elenco.Add(c);

                            c.CodiceFiscale = (string)reader["CodiceFiscale"];
                            c.Nome = (string)reader["Nome"];
                            c.CittaResidenza = (string)reader["CittaResidenza"];
                            c.AnnoPatente = (int)reader["AnnoPatente"];
                            c.ListaAutomobili = new List<Automobile>();
                        }

                        Automobile a = new Automobile();
                        a.Targa = (string)reader["targa"];
                        a.Modello = (string)reader["Modello"];
                        a.Cilindrata = (int)reader["Cilindrata"];
                        a.CodiceProprietario = (string)reader["CodiceFiscaleProprietario"];
                        a.proprietario = c;

                        c.ListaAutomobili.Add(a);
                    }

                    reader.Close();
                }
            }
            catch(Exception ex)
            {
                Errore = ex.Message;
                Console.Write(ex.Message);
            }

            return elenco;
        }

        public int Aggiungi(Proprietario unProprietario)
        {
            int n = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(StringaDiConnessione))
                {
                    con.Open();
                    string query = "INSERT INTO Proprietari(CodiceFiscale, Nome, CittaResidenza, AnnoPatente) " +
                        "VALUES(@codice,@nome,@citta,@anno)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@codice", unProprietario.CodiceFiscale);
                    cmd.Parameters.AddWithValue("@nome", unProprietario.Nome);
                    cmd.Parameters.AddWithValue("@citta", unProprietario.CittaResidenza);
                    cmd.Parameters.AddWithValue("@anno", unProprietario.AnnoPatente);
                    n = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Errore = ex.Message;
            }
            return n;
        }

    }
}
