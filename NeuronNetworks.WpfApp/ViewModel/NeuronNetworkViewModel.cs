using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using PropertyChanged;

namespace NeuronNetworks.WpfApp.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class NeuronNetworkViewModel
    {
        public NeuronNetworkViewModel()
        {
            SetDrawingField(letterA);
        }

        #region Значения каждой кнопки
        public int ValueButton0 { get; set; }
        public int ValueButton1 { get; set; }
        public int ValueButton2 { get; set; }
        public int ValueButton3 { get; set; }
        public int ValueButton4 { get; set; }
        public int ValueButton5 { get; set; }
        public int ValueButton6 { get; set; }
        public int ValueButton7 { get; set; }
        public int ValueButton8 { get; set; }
        public int ValueButton9 { get; set; }
        public int ValueButton10 { get; set; }
        public int ValueButton11 { get; set; }
        public int ValueButton12 { get; set; }
        public int ValueButton13 { get; set; }
        public int ValueButton14 { get; set; }
        public int ValueButton15 { get; set; }
        public int ValueButton16 { get; set; }
        public int ValueButton17 { get; set; }
        public int ValueButton18 { get; set; }
        public int ValueButton19 { get; set; }
        public int ValueButton20 { get; set; }
        public int ValueButton21 { get; set; }
        public int ValueButton22 { get; set; }
        public int ValueButton23 { get; set; }
        public int ValueButton24 { get; set; }
        #endregion

        //public Brush Testcolor { get; set; } = Brushes.BlueViolet;

        public int TestInteger1 { get; set; } = -1;
        public int TestInteger2 { get; set; } = 1;


        #region Массивы с данными для букв
        public int[] letterA = new int[25]
        {
                -1, -1,  1, -1, -1,
                -1,  1, -1,  1, -1,
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, -1,
                -1,  1, -1,  1, -1
        };

        int[] letterD = new int[25]
        {
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, -1,
                 1,  1,  1,  1,  1,
                 1, -1, -1, -1,  1,
                 1, -1, -1, -1,  1
        };

        int[] letterN = new int[25]
        {
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1,  1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
        };

        int[] letterB = new int[25]
        {
                -1, 1,  1,  1, -1,
                -1 ,1, -1, -1, -1,
                -1, 1,  1,  1, -1,
                -1, 1, -1,  1, -1,
                -1, 1,  1,  1, -1
        };
        #endregion


        private void SetDrawingField(int[] data)
        {
            if (data.Length != 25) return;

            ValueButton0 = data[0];
            ValueButton1 = data[1];
            ValueButton2 = data[2];
            ValueButton3 = data[3];
            ValueButton4 = data[4];
            ValueButton5 = data[5];
            ValueButton6 = data[6];
            ValueButton7 = data[7];
            ValueButton8 = data[8];
            ValueButton9 = data[9];
            ValueButton10 = data[10];
            ValueButton11 = data[11];
            ValueButton12 = data[12];
            ValueButton13 = data[13];
            ValueButton14 = data[14];
            ValueButton15 = data[15];
            ValueButton16 = data[16];
            ValueButton17 = data[17];
            ValueButton18 = data[18];
            ValueButton19 = data[19];
            ValueButton20 = data[20];
            ValueButton21 = data[21];
            ValueButton22 = data[22];
            ValueButton23 = data[23];
            ValueButton24 = data[24];
        }
    }

    public class NumberToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value == 1 ? Brushes.LightBlue : Brushes.WhiteSmoke;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
