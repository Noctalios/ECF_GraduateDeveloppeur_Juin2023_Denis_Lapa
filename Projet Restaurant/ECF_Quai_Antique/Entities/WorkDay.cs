namespace ECF_Quai_Antique.Entities
{
    public class WorkDay
    {
        public DayOfWeek DayOfWeek { get; set; }

        public List<Period> Periods { get; set; }

        public WorkDay()
        {
        }

        public WorkDay(DayOfWeek dayOfWeek, List<Period> periods)
        {
            DayOfWeek = dayOfWeek;
            Periods = periods;
        }
    }
}
