namespace ECF_Quai_Antique.Entities
{
    public class Role
    {
        private int Id { get; set; }

        private string Label { get; set; }

        public Role(int id, string label) 
        {
            Id = id;
            Label = label;
        }
    }
}
