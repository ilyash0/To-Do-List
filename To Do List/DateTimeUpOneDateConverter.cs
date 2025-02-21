using System;
using System.Globalization;
using System.Windows.Data;

namespace To_Do_List
{
    internal class DateTimeUpOneDateConverter : IValueConverter
    {
        public object Convert(object value,
            Type targetType, object parameter, CultureInfo culture)
        {
            var d = value as DateTime?;
            if (d != null)
            {
                return DateTime.Now.Date.AddDays(1) == d.Value;
            }
            return false;
        }

        public object ConvertBack(object value,
            Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
