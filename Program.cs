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


    int scelta = testNumero();


    switch (scelta)
    {
        case 1:
            AggiungiCliente();
            break;
        case 2:
            Cliente cliente = banca.CercaCliente();

            if (cliente != null)
            {
                ModificaDatiCliente(cliente);
            }
            MenuIniziale();
            break;
        case 3:
            Cliente clienteRicercato = banca.CercaCliente();

            Console.WriteLine(clienteRicercato.Nome + " " + clienteRicercato + " " + clienteRicercato.CodiceFiscale + " " + clienteRicercato.Stipendio);

            MenuIniziale();
            break;

        case 4:
            NuovoPrestito();

            MenuIniziale();
            break;

    }
}

void NuovoPrestito()
{
    Console.WriteLine("quale cliente ne usufruisce?");
    Cliente cliente = banca.CercaCliente();


    //TODO: da implementare con i centesimi e relativi controlli
    Console.WriteLine("inserire cifra prestata?  (senza inserire centesimi)");
    int ammontare = testNumero();

    Console.WriteLine("inserire mesi durata prestito");
    int durata = testNumero();

    Console.WriteLine("inserire una data di inizio diversa da quella odierna?");
    DateTime data;
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
        string gg = "PM";
        if(ora < 12)
        {
            gg = "AM";
        }


         data = new DateTime(anno, giorno, mese,ora, gg,0 );

    }

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