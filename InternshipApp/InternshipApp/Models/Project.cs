using System;

namespace InternshipApp.Models
{
    public class Project
    {
        public uint ID { get; set; } // ID проекта 
        public string Name { get; set; } // Название проекта
        public string CustomerCompany { get; set; } // Компания заказчик
        public string PerformingCompany { get; set; } // Компания исполнитель
        public DateTime BegDate { get; set; } // Дата начала
        public DateTime EndDate { get ; set; } // Дата окончания
        public Employee Supervisor { get; set; } // Руководитель
        public uint Priority { get; set; } // Приоритет проекта
    }
}
