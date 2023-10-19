namespace IBoss.View_Model
{
    public class AttendanceReport
    {
        public string EmployeeName { get; set; }
        //public DateTime MonthName { get; set; }
        public string MonthName { get; set; }
        public double PayableSalary { get; set; } = 0;
        public int TotalPresent { get; set; } = 0;
        public int TotalAbsent { get; set; } = 0;
        public int TotalOffday { get; set; } = 0;
    }
}
