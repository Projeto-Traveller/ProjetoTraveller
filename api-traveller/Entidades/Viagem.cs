namespace api_traveller.Entidades
{
    public class Viagem
    {
        public int Id { get; set; }

        public string Tipo { get; set; }

        public string Origem { get; set; }

        public DateTime Data { get; set; }

        public string Destino { get; set; }

        public decimal Preco { get; set; }

    }
}
