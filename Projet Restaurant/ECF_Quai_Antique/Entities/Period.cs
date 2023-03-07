namespace ECF_Quai_Antique.Entities
{
    public class Period
    {
        public int Id { get; set; }

        public int Service { get; set; }

        public DateTime? Open { get; set; }

        public DateTime? Close { get; set; }

        public Period() { }

        public Period(int id, int service, DateTime open, DateTime close)
        {
            Id = id;
            Service = service;
            Open = open;
            Close = close;
        }
    }
}
