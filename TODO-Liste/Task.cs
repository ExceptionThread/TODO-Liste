using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ToDoListe
{
    internal class Task
    {
        /// <summary>
        /// ID of the task
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Short description of the task
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Detailed description of the task
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Due Date 
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// ID_SERVER for new Tasks
        /// </summary>
        private static int ID_SERVER = 1000;

        /// <summary>
        /// Constructor for a new task (without ID)
        /// </summary>
        /// <param name="description"></param>
        /// <param name="details"></param>
        /// <param name="dueDate"></param>
        public Task(string description, string details, DateTime dueDate)
        {
            Description = description;
            Details = details;
            DueDate = dueDate;
            ID = ID_SERVER;
            ID_SERVER += 10;
        }


        /// <summary>
        /// 
        /// Constructor für a given Task with id
        /// 
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="description"></param>
        /// <param name="details"></param>
        /// <param name="dueDate"></param>
        public Task(int iD, string description, string details, DateTime dueDate)
        {
            ID = iD;
            Description = description;
            Details = details;
            DueDate = dueDate;
        }

        /// <summary>
        /// String representation of the task 
        /// - used for display of list items 
        /// </summary>
        /// <returns>string representation of the task</returns>
        public override string ToString()
        {
            return $"TaskID {ID}: {Description} (due: {DueDate.ToShortDateString()})";
        }
    }
}
