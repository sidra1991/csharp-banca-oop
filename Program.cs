// See https://aka.ms/new-console-template for more information

//funzioni di controllo reciclabili

//controlla se l'utente inserisce un numero in caso contrario richiede nuovamente al utente il numero segnalando l'errore
int testNumero()
{

    int libero;

    string tester = Console.ReadLine();
    int number;

    bool success = int.TryParse(tester, out number);
    if (success)
    {
        libero = Convert.ToInt32(tester);
    }
    else
    {
        Console.WriteLine("mi spiace non è un numero");
        libero = testNumero();
    }


    return libero;
}

//contolla le risposte affermative o negative del utente
bool siOno()
{
    string testo = Convert.ToString(Console.ReadLine());
    if (testo == "si" || testo == "yes" || testo == "y" || testo == "s")
    {
        return true;
    }
    else
    {
        return false;
    }

}


Console.WriteLine("come si chiama la banca?");

string nomeBanca = Convert.ToString(Console.ReadLine());
Banca banca = new Banca( nomeBanca );


void MenuIniziale()
{
    Console.WriteLine("menù iniziale scegli l'operazione");
    Console.WriteLine("");
    Console.WriteLine("1. aggiungi cliente");
    Console.WriteLine("2. modifica dati cliente");
    Console.WriteLine("3. ricerca cliente");
    Console.WriteLine("4. registra prestito");
    Console.WriteLine("5. guarda prestiti");


    int scelta = testNumero();


    switch (scelta)
    {
        case 1:
            AggiungiCliente();
            break;
        case 2:
            Cliente cliente = CercaCliente();

            if (cliente != null)
            {
                ModificaDatiCliente(cliente);
            }
            MenuIniziale();
            break;
        case 3:
            Cliente clienteRicercato = CercaCliente();

            Console.WriteLine(clienteRicercato.Nome + " " + clienteRicercato + " " + clienteRicercato.CodiceFiscale + " " + clienteRicercato.Stipendio);

            MenuIniziale();
            break;

        case 4:
            NuovoPrestito();

            MenuIniziale();
            break;
        case 5:
            Cliente clientePrestiti = CercaCliente();
            Console.WriteLine("il cliente " + clientePrestiti.Nome + " " + clientePrestiti.Cognome);
            Console.WriteLine("a attualmente " + clientePrestiti.PrestitiRicevuti + " prestitti ottenuti");
            Console.WriteLine("vui vedere la lista dei suoi prestiti?");
            if (siOno())
            {
                foreach( Prestito prestito in clientePrestiti.prestiti)
                {
                    Console.WriteLine("ammontare " + prestito.Ammontare);
                    Console.WriteLine("data di inizio " + Convert.ToString(prestito.DataInizio));
                    Console.WriteLine("data di fine " + Convert.ToString(prestito.DataFine));
                    Console.WriteLine("rata " + prestito.Rata);
                    
                    Console.WriteLine("rate mancanti da implementare non sono riuscito" );

                }
            }

            MenuIniziale();
            break;

    }
}

Cliente CercaCliente()
{

    Console.WriteLine("ricerca il cliente");
    string ricerca = Convert.ToString(Console.ReadLine());
    List<Cliente> trovati = new List<Cliente>();

    for (int i = 0; i < banca.clienti.Count; i++)
    {
        if (banca.clienti[i].Nome == ricerca || banca.clienti[i].CodiceFiscale == ricerca)
        {
            trovati.Add(banca.clienti[i]);
        }
    }

    Cliente cliente;

    if (trovati.Count > 1)
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
        int indice = Convert.ToInt32(Console.ReadLine());

        cliente = banca.clienti[indice - 1];
    }
    else if (banca.clienti.Count == 1)
    {
        cliente = banca.clienti[0];
    }
    else
    {
        Console.WriteLine("cliente non trovato cercare ancora?");
        if (Convert.ToString(Console.ReadLine()) == "si")
        {
            cliente = CercaCliente();
        }
        else
        {
            cliente = null;
        }
    }
    return cliente;
}

void NuovoPrestito()
{
    Console.WriteLine("quale cliente ne usufruisce?");
    Cliente cliente = CercaCliente();


    //TODO: da implementare con i centesimi e relativi controlli
    Console.WriteLine("inserire cifra prestata?  (senza inserire centesimi)");
    int ammontare = testNumero();

    Console.WriteLine("inserire mesi durata prestito");
    int durata = testNumero();

    Console.WriteLine("inserire una data di inizio diversa da quella odierna?");
    DateTime dataInizio = new DateTime();
    if (siOno())
    {
        Console.WriteLine("inserire giorno ");
        int giorno = testNumero();
        Console.WriteLine("inserire mese");
        int mese = testNumero();
        Console.WriteLine("inserire anno");
        int anno = testNumero();
        Console.WriteLine("inserire ora, non occorrono i minuti");
        int ora= testNumero();
        dataInizio = new DateTime(anno, giorno, mese,ora, 0,0 );
    }
    else
    {
        dataInizio = DateTime.Today;
    }
    
    Prestito QuestoPrestito = new Prestito( cliente,ammontare,durata,dataInizio );
    cliente.prestiti.Add(QuestoPrestito);
}

void AggiungiCliente()
{
    Console.WriteLine("inserisci il nome del nuovo cliente");
    string nome = Convert.ToString(Console.ReadLine());
    Console.WriteLine("inserisci il cognome del nuovo cliente");
    string cognome = Convert.ToString(Console.ReadLine());

    //TODO: da implementare con i centesimi in double con controllo
    Console.WriteLine("inserisci stipendio netto centesimi esclusi, del nuovo cliente");
    int stipendio = testNumero();
    Console.WriteLine("inserisci il codice fiscale del nuovo cliente");
    string codiceFiscale = Convert.ToString(Console.ReadLine());

    bool successo = true;
    for (int i = 0; i < banca.clienti.Count; i++)
    {
        if (codiceFiscale == banca.clienti[i].CodiceFiscale)
        {
            successo = false;
        }
    }

    if (successo)
    {
        Cliente cliente = new Cliente(nome, cognome, codiceFiscale, stipendio);
        banca.clienti.Add(cliente);
    }
    else
    {
        Console.WriteLine("questo cliente esisgte gia");
    }
    MenuIniziale();
}

void ModificaDatiCliente(Cliente cliente)
{
    Console.WriteLine("nome cliente " + cliente.Nome + " modificare?");
    if (siOno())
    {
        Console.WriteLine("inserisci nuovo nome");
        string nuovoNome = Convert.ToString(Console.ReadLine());
        cliente.ModificaNome(nuovoNome);
    }
    Console.WriteLine("cognome cliente " + cliente.Cognome + " modificare?");
    if (siOno())
    {
        Console.WriteLine("inserisci nuovo cognome");
        string nuovoCognome = Convert.ToString(Console.ReadLine());
        cliente.ModificaCognome(nuovoCognome);
    }
    Console.WriteLine("codice fiscale cliente " + cliente.CodiceFiscale + " modificare?");
    if (siOno())
    {
        Console.WriteLine("inserisci nuovo codice fiscale");
        string nuovoCF = Convert.ToString(Console.ReadLine());
        cliente.ModificaCF(nuovoCF);
    }
    Console.WriteLine("stipendio cliente " + cliente.Stipendio + " modificare?");
    if (siOno())
    {
        Console.WriteLine("inserisci nuovo stipendio");
        int nuovoStipendio = Convert.ToInt32(Console.ReadLine());
        cliente.ModificaStipendio(nuovoStipendio);
    }

}

MenuIniziale();