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

/*
 * Автор: Илья Шмырёв
 * Версия: 1.0
 * Дата последнего изменения: 26.02.2025
 * Назначение: Логика взаимодействия для окна добавления нового дела.
 */
namespace ToDoListApp
{
    public partial class NewToDoWindow : Window
    {
        public static readonly RoutedCommand AddToDoCommand = new RoutedCommand();
        public NewToDoWindow()
        {
            InitializeComponent();

            // Инициализация полей по умолчанию
            dateToDo.SelectedDate = DateTime.Now.Date;
            descriptionToDo.Text = "Нет описания";
        }

        private void OnSaveTask(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleToDo.Text))
            {
                MessageBox.Show("Поле 'Название' не должно быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dateToDo.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату для дела.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ToDo newToDo = new ToDo(
                titleToDo.Text,
                dateToDo.SelectedDate.Value,
                descriptionToDo.Text
            );
            if (Owner is MainWindow mainWindow)
            {
                mainWindow.ToDoItems.Add(newToDo);
                mainWindow.UpdateUI();
            }
            this.Close();
        }


    }
}
