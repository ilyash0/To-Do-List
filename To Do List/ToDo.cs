using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    public class ToDo
    {
        private string _name;
        private DateTime _date;
        private string _description;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public DateTime Date
        {
            get => _date; 
            set => _date = value;
        }
        public string Description
        {
            get => _description; 
            set => _description = value; 
        }

        public ToDo()
        {
            _name = null;
            _date = DateTime.Now;
            _description = "Нет описания";
        }

        public ToDo(string name, DateTime date, string description)
        {
            Name = name;
            Date = date;
            Description = description;
        }
    }
}
