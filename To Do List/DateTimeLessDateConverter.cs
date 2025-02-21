﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace To_Do_List
{
    public class DateTimeLessDateConverter : IValueConverter
    {
        public object Convert(object value, 
            Type targetType, object parameter, CultureInfo culture)
        {
            var d = value as DateTime?;
            if (d != null)
            {
                return DateTime.Now > d.Value;
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
