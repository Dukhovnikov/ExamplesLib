using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Prism.Commands;
using PropertyChanged;

namespace NeuronNetworks.WpfApp.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class NeuronNetworkViewModel
    {
        public NeuronNetworkViewModel()
        {
            SetDrawingField(letterA);
            SetOriginDrawingField(letterD);

            CheckCommand = new DelegateCommand(() => 
            {
                int[] data = GetDrawingFieldAsMass();
                SetOriginDrawingField(data);
            });
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


        public int ValueButtonOrigin0 { get; set; }
        public int ValueButtonOrigin1 { get; set; }
        public int ValueButtonOrigin2 { get; set; }
        public int ValueButtonOrigin3 { get; set; }
        public int ValueButtonOrigin4 { get; set; }
        public int ValueButtonOrigin5 { get; set; }
        public int ValueButtonOrigin6 { get; set; }
        public int ValueButtonOrigin7 { get; set; }
        public int ValueButtonOrigin8 { get; set; }
        public int ValueButtonOrigin9 { get; set; }
        public int ValueButtonOrigin10 { get; set; }
        public int ValueButtonOrigin11 { get; set; }
        public int ValueButtonOrigin12 { get; set; }
        public int ValueButtonOrigin13 { get; set; }
        public int ValueButtonOrigin14 { get; set; }
        public int ValueButtonOrigin15 { get; set; }
        public int ValueButtonOrigin16 { get; set; }
        public int ValueButtonOrigin17 { get; set; }
        public int ValueButtonOrigin18 { get; set; }
        public int ValueButtonOrigin19 { get; set; }
        public int ValueButtonOrigin20 { get; set; }
        public int ValueButtonOrigin21 { get; set; }
        public int ValueButtonOrigin22 { get; set; }
        public int ValueButtonOrigin23 { get; set; }
        public int ValueButtonOrigin24 { get; set; }
        #endregion

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


        public ICommand CheckCommand { get; set; }

        private int[] GetDrawingFieldAsMass()
        {
            int[] data = new int[25]
            {
                ValueButton0,
                ValueButton1,
                ValueButton2,
                ValueButton3,
                ValueButton4,
                ValueButton5,
                ValueButton6,
                ValueButton7,
                ValueButton8,
                ValueButton9,
                ValueButton10,
                ValueButton11,
                ValueButton12,
                ValueButton13,
                ValueButton14,
                ValueButton15,
                ValueButton16,
                ValueButton17,
                ValueButton18,
                ValueButton19,
                ValueButton20,
                ValueButton21,
                ValueButton22,
                ValueButton23,
                ValueButton24
            };

            return data;
        }

        private void GetOriginDrawingFieldAsMass()
        {
            int[] data = new int[25]
            {
                ValueButtonOrigin0,
                ValueButtonOrigin1,
                ValueButtonOrigin2,
                ValueButtonOrigin3,
                ValueButtonOrigin4,
                ValueButtonOrigin5,
                ValueButtonOrigin6,
                ValueButtonOrigin7,
                ValueButtonOrigin8,
                ValueButtonOrigin9,
                ValueButtonOrigin10,
                ValueButtonOrigin11,
                ValueButtonOrigin12,
                ValueButtonOrigin13,
                ValueButtonOrigin14,
                ValueButtonOrigin15,
                ValueButtonOrigin16,
                ValueButtonOrigin17,
                ValueButtonOrigin18,
                ValueButtonOrigin19,
                ValueButtonOrigin20,
                ValueButtonOrigin21,
                ValueButtonOrigin22,
                ValueButtonOrigin23,
                ValueButtonOrigin24
            };
        }

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

        private void SetOriginDrawingField(int[] data)
        {
            if (data.Length != 25) return;

            ValueButtonOrigin0 = data[0];
            ValueButtonOrigin1 = data[1];
            ValueButtonOrigin2 = data[2];
            ValueButtonOrigin3 = data[3];
            ValueButtonOrigin4 = data[4];
            ValueButtonOrigin5 = data[5];
            ValueButtonOrigin6 = data[6];
            ValueButtonOrigin7 = data[7];
            ValueButtonOrigin8 = data[8];
            ValueButtonOrigin9 = data[9];
            ValueButtonOrigin10 = data[10];
            ValueButtonOrigin11 = data[11];
            ValueButtonOrigin12 = data[12];
            ValueButtonOrigin13 = data[13];
            ValueButtonOrigin14 = data[14];
            ValueButtonOrigin15 = data[15];
            ValueButtonOrigin16 = data[16];
            ValueButtonOrigin17 = data[17];
            ValueButtonOrigin18 = data[18];
            ValueButtonOrigin19 = data[19];
            ValueButtonOrigin20 = data[20];
            ValueButtonOrigin21 = data[21];
            ValueButtonOrigin22 = data[22];
            ValueButtonOrigin23 = data[23];
            ValueButtonOrigin24 = data[24];
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
            return value.Equals(Brushes.LightBlue) ? -1 : 1;
        }
    }
}
