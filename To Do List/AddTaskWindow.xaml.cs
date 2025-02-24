using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace To_Do_List
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        public static readonly RoutedCommand AddToDoCommand = new RoutedCommand();
        public AddTaskWindow()
        {
            InitializeComponent();

            dateToDo.SelectedDate = DateTime.Now.Date;
            descriptionToDo.Text = "Нет описания";
        }

        private void SaveTask(object sender, ExecutedRoutedEventArgs e)
        {
            ToDo task = new ToDo(
                titleToDo.Text,
                dateToDo.SelectedDate.Value,
                descriptionToDo.Text
            );
            ((MainWindow)Owner).ToDoList.Add(task);

            ((MainWindow)Owner).UpdateWindow();
            this.Close();
        }


    }
}
