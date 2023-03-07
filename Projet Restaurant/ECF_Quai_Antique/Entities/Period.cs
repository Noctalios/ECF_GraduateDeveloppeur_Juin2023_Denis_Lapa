namespace ECF_Quai_Antique.Entities
{
    public class Period
    {
        public int Id { get; set; }

        public int Service { get; set; }

        public TimeOnly? Open { get; set; }

        public TimeOnly? Close { get; set; }

        public Period(int id, int service, TimeOnly open, TimeOnly close)
        {
            Id = id;
            Service = service;
            Open = open;
            Close = close;
        }
    }
}
