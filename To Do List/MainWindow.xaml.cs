using Microsoft.Win32;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
 * Автор: Илья Шмырёв
 * Версия: 1.0
 * Дата последнего изменения: 26.02.2025
 * Назначение: Основное окно приложения для списка дел
 */
namespace ToDoListApp
{
    public partial class MainWindow : Window
    {
        public List<ToDo> ToDoItems { get; private set; } = new();
        private readonly string _saveFilePath;
        public MainWindow()
        {
            InitializeComponent();

            // Подписка на события загрузки и закрытия окна
            Loaded += OnMainWindowLoaded;
            Closed += OnMainWindowClosed;

            // Создание директории для хранения файла, если она отсутствует
            string directory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Files");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            _saveFilePath = System.IO.Path.Combine(directory, "todo.json");
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            ToDoItems = DataManager.LoadFromJson(_saveFilePath);
            UpdateUI();
        }

        private void OnMainWindowClosed(object? sender, EventArgs e)
        {
            DataManager.SaveToJson(ToDoItems, _saveFilePath);
        }

        private void OnCheckBoxDoingClick(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            DataManager.SaveToJson(ToDoItems, _saveFilePath);
        }

        private void OnButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is ToDo toDo)
            {
                DeleteTodo(toDo);
            }
        }

        private void OnDeleteToDoExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (listToDo.SelectedItem is ToDo toDo)
            {
                DeleteTodo(toDo);
            }
            else
            {
                MessageBox.Show("Не выбрана задача для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenNewToDoWindow(object sender, ExecutedRoutedEventArgs e)
        {
            NewToDoWindow newToDoWindow = new() { Owner = this };
            newToDoWindow.ShowDialog();
        }

        internal void UpdateUI()
        {
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = ToDoItems;
            UpdateProgressBar();
        }

        internal void UpdateProgressBar()
        {
            int totalCount = ToDoItems.Count;
            int completedCount = ToDoItems.Count(toDo => toDo.Doing);

            progressBar.Value = completedCount;
            progressBar.Maximum = totalCount;

            textBlockProgressBar.Text = $"{completedCount}/{totalCount}";
        }

        private void DeleteTodo(ToDo toDo)
        {
            if (toDo == null)
            {
                MessageBox.Show("Задача не выбрана.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Вы увверены, что хотите удалить дело?", "Удаление дела", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            ToDoItems.Remove(toDo);

            UpdateUI();
            DataManager.SaveToJson(ToDoItems, _saveFilePath);
        }

        private void SaveTxtFile(object sender, RoutedEventArgs e)
        {
            if (ToDoItems.Count < 1)
            {
                MessageBoxResult result = MessageBox.Show("В списке нет дел", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Text File (*.txt) | *.txt",
                OverwritePrompt = true,
                FileName = "Список дел",
                Title = "Сохранить файл"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                StringBuilder sb = new();
                foreach (ToDo toDo in ToDoItems)
                {
                    sb.Append(toDo.Doing ? "✓ " : "  ");
                    sb.AppendLine(toDo.Name);
                    sb.AppendLine();
                    sb.AppendLine(toDo.Description);
                    sb.AppendLine();
                    sb.AppendLine(toDo.Date.ToString());
                    sb.AppendLine();
                    sb.AppendLine();
                }
                File.WriteAllText(saveFileDialog.FileName, sb.ToString());
            }
        }
    }
}