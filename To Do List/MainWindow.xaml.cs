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

            ClearGroupBoxToDo();
            UpdateListToDo();
        }

        private void ClearGroupBoxToDo()
        {
            titleToDo.Text = null;
            dateToDo.SelectedDate = new DateTime(2024, 1, 10);
            descriptionToDo.Text = "Нет описания";
        }

        private void UpdateListToDo()
        {
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = ToDoList;
        }

        private void CheckBoxNewTask_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxNewTask.IsChecked == true)
            {
                groupBoxToDo.Visibility = Visibility.Visible;
            }
            else
            {
                groupBoxToDo.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ToDo task = new ToDo(
            titleToDo.Text,
            dateToDo.SelectedDate.Value,
            descriptionToDo.Text
            );
            ToDoList.Add(task);

            ClearGroupBoxToDo();
            UpdateListToDo();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            ToDoList.Remove(listToDo.SelectedItem as ToDo);

            UpdateListToDo();
        }
    }
}