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
        public AddTaskWindow()
        {
            InitializeComponent();

            dateToDo.SelectedDate = new DateTime(2024, 1, 10);
            descriptionToDo.Text = "Нет описания";
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            ToDo task = new ToDo(
                titleToDo.Text,
                dateToDo.SelectedDate.Value,
                descriptionToDo.Text
            );
            ((MainWindow)Owner).ToDoList.Add(task);

            ((MainWindow)Owner).UpdateListToDo();
            this.Close();
        }


    }
}
