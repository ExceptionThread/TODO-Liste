using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace TODO_Liste
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void lstTasks_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Überprüfen, ob ein Listenelement ausgewählt wurde
            if (lstTasks.SelectedItem != null)
            {
                // Zuweisung des ausgewählten Listenelements an eine Instanz der Klasse "Task"
                Task selectedTask = (Task)lstTasks.SelectedItem;

                // Setzen der Werte der ausgewählten Aufgabe in die entsprechenden Felder
                txtDescription.Text = selectedTask.Description;
                txtNewDescription.Text = selectedTask.Description;
                txtNewDetails.Text = selectedTask.Details;
                dpNewDueDate.SelectedDate = selectedTask.DueDate;
            }
        }

    }
}
