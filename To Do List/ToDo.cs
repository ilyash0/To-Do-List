using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Автор: Илья Шмырёв
 * Версия: 1.0
 * Дата последнего изменения: 26.02.2025
 * Назначение: Класс, описывающий задачу в списке дел.
 */
namespace ToDoListApp
{
    public class ToDo
    {   
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Doing { get; set; }



        public ToDo()
        {
            Name = "";
            Date = DateTime.Now;
            Description = "Нет описания";
            Doing = false;
        }

        public ToDo(string name, DateTime date, string description)
        {
            Name = name;
            Date = date;
            Description = description;
            Doing = false;
        }
    }
}
