using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Actividad2_Superheroes
{
    class ConverterBackGround : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                return (bool)value ? Brushes.PaleGreen : Brushes.IndianRed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
