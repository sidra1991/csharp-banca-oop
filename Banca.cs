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
}
