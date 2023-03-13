namespace ECF_Quai_Antique.Entities
{
    public class WorkDay
    {
        public Day Day { get; set; }

        public List<Period> Periods { get; set; }

        public WorkDay() { }

        public WorkDay(Day day, List<Period> periods)
        {
            Day = day;
            Periods = periods;
        }
    }
}
