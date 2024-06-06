using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace TODO_Liste
{
    public partial class MainWindow : Window
    {
        private double originalWidth;
        private double originalHeight;

        public MainWindow()
        {
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            detailBorder.Visibility = Visibility.Collapsed;
            this.Width = lstTasks.Width + 30; // Adjust width to fit only the left panel initially
            btnToggle.Content = "+";
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

                lstTasks.Items.Refresh(); // Refresh the ListBox to show updated data
            }
        }
    }
}
