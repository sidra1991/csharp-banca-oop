// See https://aka.ms/new-console-template for more information
class Banca
{
    public string NomeBanca { get; set; }
    public List<Cliente> clienti;
    public List<Prestito> prestiti;

    public Banca(string nomeBanca)
    {
        NomeBanca = nomeBanca;
        clienti = new List<Cliente>();
        prestiti = new List<Prestito>();    
    }

    public Cliente CercaCliente()
    {
        Console.WriteLine("ricerca il cliente");
        string ricerca = Convert.ToString(Console.ReadLine());
        List<Cliente> trovati = new List<Cliente>();

        for (int i = 0; i < clienti.Count; i++)
        {
            if (clienti[i].Nome == ricerca|| clienti[i].CodiceFiscale == ricerca)
            {
                trovati.Add(clienti[i]);
            }
        }

        Cliente cliente;
        
        if(trovati.Count > 1)
        {
            Console.WriteLine("scegli quale cliente vuoi modificare");
            for (int i = 0; i < trovati.Count; i++)
            {
                Console.WriteLine("cliente " + i);
                Console.WriteLine("nome " + trovati[i].Nome);
                Console.WriteLine("cognome " + trovati[i].Cognome);
                Console.WriteLine("codice fiscale " + trovati[i].CodiceFiscale);
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine("inserisci l'indicce del cliente scelto");
            int indice = Convert.ToInt32( Console.ReadLine());

            cliente = clienti[indice - 1];
        }else if ( clienti.Count == 1)
        {
            cliente = clienti[0];
        }
        else
        {
            Console.WriteLine("cliente non trovato cercare ancora?");
            if ( Convert.ToString(Console.ReadLine()) == "si")
            {
                cliente = CercaCliente();
            }else
            {
                cliente = null;
            }
        }
        return cliente;
    }
}
