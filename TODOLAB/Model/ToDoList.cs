using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TODOLAB.Model
{
    public class ToDoList
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? DueDate { get ; set;}
        public  string Assignee { get; set; }

        public int Rating  { get; set; }
    }
} 
