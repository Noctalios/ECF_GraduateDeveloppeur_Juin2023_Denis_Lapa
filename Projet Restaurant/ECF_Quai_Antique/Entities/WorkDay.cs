namespace ECF_Quai_Antique.Entities
{
    public class WorkDay
    {
        private DayOfWeek DayOfWeek { get; set; }

        private List<Period> Periods { get; set; }

        public WorkDay(DayOfWeek dayOfWeek, List<Period> periods)
        {
            DayOfWeek = dayOfWeek;
            Periods = periods;
        }
    }
}
