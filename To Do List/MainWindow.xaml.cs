using Microsoft.Win32;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
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
        private readonly string jsonFilePath;
        public MainWindow()
        {
            InitializeComponent();
            //listToDo.ItemsSource = ToDoList;

            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;

            string directory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Files");
            if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }
            jsonFilePath = System.IO.Path.Combine(directory, "todo.json");

            if (!File.Exists(jsonFilePath))
            {
                ToDoList.Add(new ToDo("Тест задача 1", new DateTime(1970, 1, 1), "Тест описание 1"));
                ToDoList.Add(new ToDo("Тест задача 2", new DateTime(2025, 2, 19), "Тест описание 2"));
                ToDoList.Add(new ToDo("Тест задача 3", new DateTime(2970, 1, 1), "Тест описание 3"));
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFromJSON();
            UpdateWindow();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            SaveToJSON();
        }

        internal void UpdateWindow()
        {
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = ToDoList;
            EndToDo();
            SaveToJSON();
        }

        private void OpenAddTaskWindow(object sender, ExecutedRoutedEventArgs e)
        {
            AddTaskWindow addTaskWindow = new() { Owner = this };
            addTaskWindow.Show();

            UpdateWindow();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteTask(((Button)sender).DataContext as ToDo);
        }

        private void DeleteTask_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DeleteTask((ToDo)listToDo.SelectedItem);
        }

        private void DeleteTask(ToDo toDo)
        {
            MessageBoxResult result = MessageBox.Show("Вы увверены, что хотите удалить дело?", "Удаление дела", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            ToDoList.Remove(toDo);

            UpdateWindow();
        }

        private void CheckBoxDoing_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
        }

        internal void EndToDo()
        {
            int maxTask = ToDoList.Count;
            int completeTask = ToDoList.Count(item => item.Doing);

            progressBar.Value = completeTask;
            progressBar.Maximum = maxTask;

            textBlockProgressBar.Text = completeTask + "/" + maxTask;
        }

        private void SaveTxtFile(object sender, RoutedEventArgs e)
        {
            if (ToDoList.Count < 1)
            {
                MessageBoxResult result = MessageBox.Show("В списке нет дел", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveFileDialog saveFile = new()
            {
                Filter = "Text File (*.txt) | *.txt",
                OverwritePrompt = true,
                FileName = "Список дел",
                Title = "Сохранить файл"
            };

            StringBuilder stringBuilder = new();
            foreach (ToDo item in ToDoList)
            {
                stringBuilder.Append(item.Doing == true ? "✓" : " ");
                stringBuilder.AppendLine(item.Name);
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine(item.Description);
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine(Convert.ToString(item.Date));
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine("");
            }
            saveFile.ShowDialog();
            string path = saveFile.FileName;

            File.WriteAllText(path, Convert.ToString(stringBuilder));
        }

        private void SaveToJSON()
        {
            JsonSerializerOptions options = new() { WriteIndented = true };
            FileStream stream = new(jsonFilePath, FileMode.Create);
            JsonSerializer.Serialize(stream, ToDoList, options);
            stream.Close();
        }

        private void LoadFromJSON()
        {
            if (File.Exists(jsonFilePath))
            {
                FileStream stream = new(jsonFilePath, FileMode.Open);
                List<ToDo>? loadedList = JsonSerializer.Deserialize<List<ToDo>>(stream);
                stream.Close();
                if (loadedList != null)
                {
                    ToDoList = loadedList;
                }
            }
        }
    }
}