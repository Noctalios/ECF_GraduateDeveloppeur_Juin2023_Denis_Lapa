namespace ECF_Quai_Antique.Entities
{
    public class DishType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DishType(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}
