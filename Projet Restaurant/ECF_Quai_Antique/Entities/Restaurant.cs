namespace ECF_Quai_Antique.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Guest { get; set; }

        public List<WorkDay> WorkDays { get; set; } 

    }
}
