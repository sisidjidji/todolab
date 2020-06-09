using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOLAB.Model.DTO
{
    public class ToDoListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
