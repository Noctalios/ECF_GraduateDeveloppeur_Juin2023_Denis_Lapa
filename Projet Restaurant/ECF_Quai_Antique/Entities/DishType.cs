namespace ECF_Quai_Antique.Entities
{
    public class DishType
    {
        private int Id { get; set; }

        private string Name { get; set; }

        public DishType(string name) 
        {
            this.Name = name;
        }
    }
}
