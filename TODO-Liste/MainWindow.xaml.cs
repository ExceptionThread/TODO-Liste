using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace TODO_Liste
{
    public partial class MainWindow : Window
    {
        private double originalWidth;
        private double originalHeight;
        private ToDos todos;

        public MainWindow()
        {
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
            todos = (ToDos)this.DataContext;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            detailBorder.Visibility = Visibility.Collapsed;
            this.Width = lstTasks.Width + 30; // Adjust width to fit only the left panel initially
            btnToggle.Content = "+";
        }

        private void lstTasks_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                Task selectedTask = (Task)lstTasks.SelectedItem;
                SetTaskDetails(selectedTask);
            }
        }

        private void SetTaskDetails(Task task)
        {
            txtDescription.Text = task.Description;
            txtNewDescription.Text = task.Description;
            txtNewDetails.Text = task.Details;
            dpNewDueDate.SelectedDate = task.DueDate;
            lblTaskId.Content = task.ID.ToString();
        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {
            if (detailBorder.Visibility == Visibility.Visible)
            {
                detailBorder.Visibility = Visibility.Collapsed;
                btnToggle.Content = "+";
                this.Width = lstTasks.Width + 30; // Adjust width to fit only the left panel
            }
            else
            {
                detailBorder.Visibility = Visibility.Visible;
                btnToggle.Content = "-";
                this.Width = originalWidth; // Restore original width
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                Task selectedTask = (Task)lstTasks.SelectedItem;
                selectedTask.Description = txtNewDescription.Text;
                selectedTask.Details = txtNewDetails.Text;
                selectedTask.DueDate = dpNewDueDate.SelectedDate ?? selectedTask.DueDate;
            }
            else
            {
                Task newTask = new Task
                {
                    Description = txtNewDescription.Text,
                    Details = txtNewDetails.Text,
                    DueDate = dpNewDueDate.SelectedDate ?? DateTime.Now
                };
                todos.Taskliste.Add(newTask);
            }

            lstTasks.Items.Refresh(); // Refresh the ListBox to show updated data
            ClearTaskDetails();
        }

        private void ClearTaskDetails()
        {
            lblTaskId.Content = lstTasks.SelectedItem != null ? ((Task)lstTasks.SelectedItem).ID.ToString() : "new";
            txtNewDescription.Text = string.Empty;
            txtNewDetails.Text = string.Empty;
            dpNewDueDate.SelectedDate = null;
        }

        private void lstTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                Task selectedTask = (Task)lstTasks.SelectedItem;
                SetTaskDetails(selectedTask);
            }
            else
            {
                lblTaskId.Content = "new"; // Wenn kein Element ausgewählt ist, setzen wir "new" als ID
                ClearTaskDetails();
            }
        }
    }
}
