using System.Runtime.CompilerServices;

namespace ECF_Quai_Antique.Data
{
    public class Period
    {
        private int Id { get; set; }

        private int Service { get; set; }

        private decimal Open { get; set; }

        private decimal Close { get; set; }

        public Period(int id, int service, decimal open, decimal close)
        {
            Id = id;
            Service = service;
            Open = open;
            Close = close;
        }
    }
}
