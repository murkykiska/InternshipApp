namespace InternshipApp.Models
{
    public class EmployeesByProjects
    {
        public uint ID { get; set; } // ID записи
        public Project Project { get; set; } // Проект
        public Employee Employee { get; set; } // Ссотрудник
    }
}
