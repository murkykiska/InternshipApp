namespace InternshipApp.Models
{
    public class TasksByProjects
    {
        public int ID { get; set; } // ID записи
        public Project Project { get; set; } // Проект
        public Problem Problem { get; set; } // Задача
    }
}
