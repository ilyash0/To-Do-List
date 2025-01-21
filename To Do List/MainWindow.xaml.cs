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
        public List<ToDo> ToDoList { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            ToDoList =
            [
                new ToDo("Поиграть в D&D", new DateTime(2024, 1, 20), "Dangeons And Dragons"),
                new ToDo("Тест задача 2", new DateTime(1970, 1, 1), "Тест описание 2"),
                new ToDo("Тест задача 3", new DateTime(1970, 1, 1), "тест описание 3")
            ];

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
    }
}