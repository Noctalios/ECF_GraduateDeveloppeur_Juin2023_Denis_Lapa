namespace ECF_Quai_Antique.Entities
{
    public class Booking
    {
        public int Id { get; set; }
     
        public DateTime Date { get; set; }
        
        public string ClientName { get; set; }
        
        public int Guest { get; set; } 

        public List<Allergie> Allergens { get; set; }

        public Booking(int id, DateTime date, string clientName, int guest, List<Allergie> allergens)
        {
            Id = id;
            Date = date;
            ClientName = clientName;
            Guest = guest;
            Allergens = allergens;
        }
    }
}
