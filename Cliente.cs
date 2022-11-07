// See https://aka.ms/new-console-template for more information


class Cliente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string CodiceFiscale { get; set; }
    public int Stipendio { get; set; }

    public List<Prestito> prestiti;

    public Cliente(string nome, string cognome, string codiceFiscale, int stipendio)
    {
        prestiti = new List<Prestito>();
        Nome = nome;
        Cognome = cognome;
        CodiceFiscale = codiceFiscale;
        Stipendio = stipendio;  
    }

    public void ModificaNome( string nuovoNome )
    {
        Nome = nuovoNome;
    }
    public void ModificaCognome(string nuovoCognome)
    {
        Cognome = nuovoCognome;
    }
    public void ModificaCF(string nuovoCF)
    {
        CodiceFiscale = nuovoCF;
    }
    public void ModificaStipendio(int nuovoStipendio)
    {
        Stipendio = nuovoStipendio;
    }
}
