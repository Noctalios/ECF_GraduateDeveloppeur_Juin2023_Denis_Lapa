namespace ECF_Quai_Antique.Entities
{
    public class DishType
    {
        private int Id { get; set; }

        private string Name { get; set; }

        public DishType(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}
