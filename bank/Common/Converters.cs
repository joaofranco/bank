using Bank.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace bank.Converter
{
    class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool normal = true;
            if(parameter is string)
            {
                normal = ! parameter.ToString().ToLower().Equals("reverse");
            }
            if (value is Boolean && (bool)value)
            {
                return normal ? Visibility.Visible : Visibility.Collapsed;
            }
            return normal ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Visibility && (Visibility)value == Visibility.Visible)
            {
                return true;
            }
            return false;
        }
    }

    public class ValueToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            BillStatus state = (BillStatus)Enum.Parse(typeof(BillStatus), (string)parameter);
            return value.Equals(state) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }


    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is BillStatus)
            {
                var billStatus = (BillStatus)value;
                if(billStatus == BillStatus.Closed)
                    return new SolidColorBrush(Color.FromArgb(255, 229, 97, 92));
                if (billStatus == BillStatus.Future)
                    return new SolidColorBrush(Color.FromArgb(255, 245, 166, 35));
                if (billStatus == BillStatus.Open)
                    return new SolidColorBrush(Color.FromArgb(255, 64, 170, 185));
                //if (billStatus == BillStatus.Overdue)
                return new SolidColorBrush(Color.FromArgb(255, 126, 211, 33));
            }
            else
                return new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                /*
            if (value == null)
                return new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

            if (value is Color)
                return new SolidColorBrush((Color)value);

            if (value is string)
                return new SolidColorBrush(Parse((string)value));

            throw new NotSupportedException("ColorToBurshConverter only supports converting from Color and String");
                 */
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }

        
    }
}
