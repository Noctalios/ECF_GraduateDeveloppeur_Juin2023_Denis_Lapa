namespace ECF_Quai_Antique.Data
{
    public class Booking
    {
        private int Id { get; set; }
     
        private DateTime Date { get; set; }
        
        private int ClientId { get; set; }
        
        private int Guest { get; set; }

        private List<Allergie> Allergens { get; set; }

        public Booking(DateTime date, int clientId, int guest, List<Allergie> allergens)
        {
            this.Date = date;
            this.ClientId = clientId;
            this.Guest = guest;
            this.Allergens = allergens;
        }
    }
}
