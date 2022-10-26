using InternshipApp.Enums;

namespace InternshipApp.Models
{
    public class Problem
    {
        public uint ID { get; set; } // ID задачи
        public string Name { get; set; } // Название задачи
        public Employee Author { get; set; } // Автор задачи
        public Employee Performer { get; set; } // Исполнитель задачи
        public ProblemStatus ProblemStatus { get; set; } // Статус задачи
        public string Comment { get; set; } // Комментарий
        public uint Priority { get; set; } // Приоритет задачи
    }
}
