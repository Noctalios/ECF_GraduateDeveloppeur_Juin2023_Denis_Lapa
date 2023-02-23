namespace ECF_Quai_Antique.Entities
{
    public class Booking
    {
        private int Id { get; set; }
     
        private DateTime Date { get; set; }
        
        private string ClientName { get; set; }
        
        private int Guest { get; set; } 

        private List<Allergie> Allergens { get; set; }

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
