namespace ECF_Quai_Antique.Entities
{
    public class Restaurant
    {
        private int Id { get; set; }

        private string Name { get; set; }

        private int Guest { get; set; }

        private List<WorkDay> WorkDays { get; set; } 

    }
}
