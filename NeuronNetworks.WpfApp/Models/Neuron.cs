using CommonData.ClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronNetworks.WpfApp.Models
{
    public class Neuron
    {
        /// <summary>Веса</summary>
        public double[] Weights;

        /// <summary>Аксон</summary>
        public double Y;

        /// <summary>Синапс</summary>
        public double S;
    }

    public class HammingNetwork
    {
        /// <summary>Разрядность координат (размерность вектора)</summary>
        public int N { get; set; }

        /// <summary>Количество образцов</summary>
        public int M { get; set; }

        public Neuron[] FirstLayer;
        public Neuron[] SecondLayer;

        public Matrix WeightCoefficientMatrix;

        /// <summary>Заполнение весовых коэффициентов нейронов первого слоя</summary>
        public void InitializeNetwork(Vector[] sampleVectors)
        {
            N = sampleVectors[0].Size;
            M = sampleVectors.Length;

            FirstLayer = new Neuron[M];
            SecondLayer = new Neuron[M];

            WeightCoefficientMatrix = new Matrix(N, M);

            for (int j = 0; j < M - 1; j++)
            {
                for (int i = 0; i < N - 1; i++)
                {
                    WeightCoefficientMatrix[i, j] = sampleVectors[j][i] / 2;
                }
            }
        }

        /// <summary>Расчёт состояний нейронов первого слоя</summary>
        public void FillFirstLayer(Vector x)
        {
            double t = N / 2;

            for (int j = 0; j < M; j++)
            {
                Neuron currentNeuron = FirstLayer[j];

                double state = 0;

                for (int i = 0; i < N; i++)
                {
                    state += currentNeuron.Weights[i] * x[i];
                }

                state += t;

                currentNeuron.S = state;
                currentNeuron.Y = state;
            }
        }

        /// <summary>Расчёт состояний нейронов второго слоя</summary>
        public double[] CalculateSecondLayer()
        {
            double epsilon = 1 / M;
            double eMax = 0.1;
            double t = N / 2;

            List<double> lastY = new List<double>();
            for (int j = 0; j < M; j++)
            {
                Neuron currentNeuron = SecondLayer[j];
                currentNeuron.S = FirstLayer[j].S;
                currentNeuron.Y = FirstLayer[j].Y;

                lastY.Add(FirstLayer[j].Y);
            }

            

            return null;
        }

        public double CalculateSum(IList<double> Y, double epsilon, int j)
        {
            double sum = 0;
            for (int k = 0; k < M; k++)
            {

            }
            return null;
        }
    }


}
