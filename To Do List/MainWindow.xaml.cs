using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace To_Do_List
{
    public partial class MainWindow : Window
    {
        public List<ToDo> ToDoList = new();
        public MainWindow()
        {
            InitializeComponent();
            //listToDo.ItemsSource = ToDoList;

            ToDoList.Add(new ToDo("Тест задача 1", new DateTime(1970, 1, 1), "Тест описание 1"));
            ToDoList.Add(new ToDo("Тест задача 2", new DateTime(1970, 1, 1), "Тест описание 2"));
            ToDoList.Add(new ToDo("Тест задача 3", new DateTime(1970, 1, 1), "Тест описание 3"));

            UpdateListToDo();
        }

        public void UpdateListToDo()
        {
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = ToDoList;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow addTaskWindow = new() { Owner = this };
            addTaskWindow.Show();

            UpdateListToDo();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            ToDoList.Remove((ToDo)listToDo.SelectedItem);

            UpdateListToDo();
        }

        private void CheckBoxDoing_Click(object sender, RoutedEventArgs e)
        {
            if (listToDo.SelectedItem == null)
            {
                return;
            }

            ((ToDo)listToDo.SelectedItem).Doing = !((ToDo)listToDo.SelectedItem).Doing;
        }
    }
}