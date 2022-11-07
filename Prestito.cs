// See https://aka.ms/new-console-template for more information



class Prestito
{
    public int Id { get; set; }
    public Cliente cliente { get; set; }

    public double Ammontare { get; set; }
    public double Rata { get; set; }
    public string DataInizio { get; set; }
    public string DataFine { get; set; }

    public Prestito(int id, Cliente cliente, double ammontare, double rata, string dataInizio, string dataFine)
    {
        Id = id;
        this.cliente = cliente;
        Ammontare = ammontare;
        Rata = rata;
        DataInizio = dataInizio;
        DataFine = dataFine;
    }
}