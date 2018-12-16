using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using CommonData.ClassLib.NeuronNetworks.HammingNetwork;
using Prism.Commands;
using PropertyChanged;

namespace NeuronNetworks.WpfApp.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class NeuronNetworkViewModel
    {
        public NeuronNetworkViewModel()
        {
            SetDrawingField(letterForTestD);
            SetOriginDrawingField(errorLetter);

            CheckCommand = new DelegateCommand(() => Compute());

            LearningSet = new List<double[]>();
            LearningSet.Add(letterA);
            LearningSet.Add(letterB);
            LearningSet.Add(letterD);
            LearningSet.Add(letterN);
            LearningSet.Add(letterO);


            LearningSetDictionary = new Dictionary<string, double[]>()
            {
                {"A", letterA },
                {"Б", letterB },
                {"Д", letterD },
                {"Н", letterN },
                {"O", letterO },
            };

            LearningSetDictionaryInt = new Dictionary<int, double[]>()
            {
                {0, letterA },
                {1, letterB },
                {2, letterD },
                {3, letterN },
                {4, letterO },
            };

            //InverseColor = new DelegateCommand(() => )
        }

        public void Compute()
        {
            var input = GetDrawingFieldAsMass();
            NeuralNetwork hammingnetwork = new NeuralNetwork();
            hammingnetwork.Initialize(5);
            hammingnetwork.Train(LearningSet);
            var output = hammingnetwork.Run(input);
            var maxindex = IndexOfMaxElement(output);

            SetOriginDrawingField(LearningSetDictionaryInt[maxindex]);
        }

        private int IndexOfMaxElement(double[] mass)
        {
            double max = mass[0];
            int index = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] > max)
                {
                    max = mass[i];
                    index = i;
                }
            }

            return index;
        }

        #region Значения каждой кнопки
        public double ValueButton0 { get; set; }
        public double ValueButton1 { get; set; }
        public double ValueButton2 { get; set; }
        public double ValueButton3 { get; set; }
        public double ValueButton4 { get; set; }
        public double ValueButton5 { get; set; }
        public double ValueButton6 { get; set; }
        public double ValueButton7 { get; set; }
        public double ValueButton8 { get; set; }
        public double ValueButton9 { get; set; }
        public double ValueButton10 { get; set; }
        public double ValueButton11 { get; set; }
        public double ValueButton12 { get; set; }
        public double ValueButton13 { get; set; }
        public double ValueButton14 { get; set; }
        public double ValueButton15 { get; set; }
        public double ValueButton16 { get; set; }
        public double ValueButton17 { get; set; }
        public double ValueButton18 { get; set; }
        public double ValueButton19 { get; set; }
        public double ValueButton20 { get; set; }
        public double ValueButton21 { get; set; }
        public double ValueButton22 { get; set; }
        public double ValueButton23 { get; set; }
        public double ValueButton24 { get; set; }


        public double ValueButtonOrigin0 { get; set; }
        public double ValueButtonOrigin1 { get; set; }
        public double ValueButtonOrigin2 { get; set; }
        public double ValueButtonOrigin3 { get; set; }
        public double ValueButtonOrigin4 { get; set; }
        public double ValueButtonOrigin5 { get; set; }
        public double ValueButtonOrigin6 { get; set; }
        public double ValueButtonOrigin7 { get; set; }
        public double ValueButtonOrigin8 { get; set; }
        public double ValueButtonOrigin9 { get; set; }
        public double ValueButtonOrigin10 { get; set; }
        public double ValueButtonOrigin11 { get; set; }
        public double ValueButtonOrigin12 { get; set; }
        public double ValueButtonOrigin13 { get; set; }
        public double ValueButtonOrigin14 { get; set; }
        public double ValueButtonOrigin15 { get; set; }
        public double ValueButtonOrigin16 { get; set; }
        public double ValueButtonOrigin17 { get; set; }
        public double ValueButtonOrigin18 { get; set; }
        public double ValueButtonOrigin19 { get; set; }
        public double ValueButtonOrigin20 { get; set; }
        public double ValueButtonOrigin21 { get; set; }
        public double ValueButtonOrigin22 { get; set; }
        public double ValueButtonOrigin23 { get; set; }
        public double ValueButtonOrigin24 { get; set; }
        #endregion

        #region Массивы с данными для букв
        public double[] letterA = new double[25]
        {
                -1, -1,  1, -1, -1,
                -1,  1, -1,  1, -1,
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, -1,
                -1,  1, -1,  1, -1
        };

        double[] letterB = new double[25]
        {
                -1, 1,  1,  1, -1,
                -1 ,1, -1, -1, -1,
                -1, 1,  1,  1, -1,
                -1, 1, -1,  1, -1,
                -1, 1,  1,  1, -1
        };

        double[] letterD = new double[25]
        {
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, -1,
                 1,  1,  1,  1,  1,
                 1, -1, -1, -1,  1,
                 1, -1, -1, -1,  1
        };

        double[] letterN = new double[25]
        {
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1,  1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
        };

        double[] letterO = new double[25]
        {
                -1, 1, 1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1,  -1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1, 1, 1, -1,
        };

        public double[] letterForTestA = new double[25]
        {
                1, -1,  1, -1, 1,
                -1,  1, -1,  1, -1,
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, -1,
                -1,  1, -1,  -1, -1
        };

        double[] letterForTestB = new double[25]
        {
                -1, 1,  1,  1, -1,
                -1 ,1, -1, -1, -1,
                -1, 1,  -1,  1, 1,
                -1, 1, -1,  1, -1,
                -1, 1,  1,  1, 1
        };

        double[] letterForTestD = new double[25]
        {
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, 1,
                 1,  1,  -1,  1,  1,
                 1, -1, -1, -1,  1,
                 1, -1, -1, -1,  1
        };

        double[] letterForTestN = new double[25]
        {
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
                1, 1,  1, 1, 1,
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
        };

        double[] letterForTestO = new double[25]
        {
                -1, 1, 1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1,  1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1, 1, 1, -1,
        };

        double[] errorLetter = new double[25]
        {
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1,  -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
        };
        #endregion

        public IList<double[]> LearningSet = new List<double[]>();

        public Dictionary<string, double[]> LearningSetDictionary { get; set; }
        public Dictionary<int, double[]> LearningSetDictionaryInt { get; set; }



        public ICommand CheckCommand { get; set; }
        public ICommand InverseColor { get; set; }

        private double[] GetDrawingFieldAsMass()
        {
            double[] data = new double[25]
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
            double[] data = new double[25]
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

        private void SetDrawingField(double[] data)
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

        private void SetOriginDrawingField(double[] data)
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
            return (double)value == 1 ? Brushes.LightBlue : Brushes.WhiteSmoke;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(Brushes.LightBlue) ? -1 : 1;
        }
    }
}
