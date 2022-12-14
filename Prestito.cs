// See https://aka.ms/new-console-template for more information



class Prestito
{
    static int Id { get; set; }
    public Cliente cliente { get; set; }

    public int Ammontare { get; set; }
    public int Rata { get; set; }
    public DateTime DataFine { get; set; }
    public DateTime DataInizio { get; set; }
    public int Durata { get; set; }

    public Prestito(Cliente cliente, int ammontare, int durata, DateTime dataInizio)
    {
        Id++;
        this.cliente = cliente;
        Ammontare = ammontare;
        Durata = durata;
        DataInizio = dataInizio;
        DataFine = dataInizio.AddMonths(durata);
        cliente.PrestitiRicevuti++;
        Rata = ammontare / durata;
    }
}