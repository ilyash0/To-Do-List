using System;
using System.Globalization;
using System.Windows.Data;

/*
 * Автор: Илья Шмырёв
 * Версия: 1.0
 * Дата последнего изменения: 26.02.2025
 * Назначение: Конвертер для проверки, наступила ли указанная дата (т.е. прошла ли дата)
 */
namespace ToDoListApp
{
    public class DateTimeLessDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                return DateTime.Now > date;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
