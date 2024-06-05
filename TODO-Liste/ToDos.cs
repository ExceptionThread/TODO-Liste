using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ToDoListe
{
    internal class ToDos
    {
        /// <summary>
        /// The task list to be managed
        /// </summary>
        private List<Task> taskliste;
        public List<Task> Taskliste
        {
            get { return taskliste; }
        }

        /// <summary>
        /// Container for Task
        /// Manages the Tasklist
        /// </summary>
        public ToDos()
        {
            taskliste = new List<Task>();
            AddTestData();
        }

        /// <summary>
        /// Creates a new Task and adds it to the tasklist
        /// </summary>
        /// <param name="description"></param>
        /// <param name="details"></param>
        /// <param name="dueDate"></param>
        public void AddTask(string description, string details, DateTime dueDate)
        {
            if (description == null)
            {
                new ArgumentNullException("No Task without description can be added to the todos.");
            }
            Task newTask = new Task(description, details, dueDate);

            taskliste.Add(newTask);
        }

        /// <summary>
        /// Adds test data to the tasklist 
        /// 
        /// </summary>
        private void AddTestData()
        {
            taskliste.Add(new Task("Aufräumen", "Arbeitszimmer entrümpeln und umräumen", DateTime.Today.AddDays(5)));
            taskliste.Add(new Task("AGC-Teamsaufgaben bearbeiten", "Übung 10 überarbeiten und abgeben", DateTime.Today.AddDays(4)));
            taskliste.Add(new Task("Datensicherung", "Daten von altem Computer sichern", DateTime.Today));
            taskliste.Add(new Task("Einkaufen", "Vorräte auffüllen", DateTime.Today));
        }
    }
}
