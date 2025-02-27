using System;
using System.Globalization;
using System.Windows.Data;

/*
 * Автор: Илья Шмырёв
 * Версия: 1.0
 * Дата последнего изменения: 26.02.2025
 * Назначение: Конвертер для проверки, равна ли указанная дата завтрашней дате.
 */
namespace ToDoListApp
{
    internal class DateTimeUpOneDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                return DateTime.Today.AddDays(1) == date.Date;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
