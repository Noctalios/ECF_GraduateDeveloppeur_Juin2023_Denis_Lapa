namespace ECF_Quai_Antique.Entities
{
    public class WorkDay
    {
        private DayOfWeek DayOfWeek { get; set; }

        private List<Period> periods { get; set; }

        public WorkDay(DayOfWeek dayOfWeek, List<Period> periods)
        {
            this.DayOfWeek = dayOfWeek;
            this.periods = periods;
        }
    }
}
