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
        public double[] Weights;
        public double Y;
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

            WeightCoefficientMatrix = new Matrix(N, M);

            for (int j = 0; j < M - 1; j++)
            {
                for (int i = 0; i < N - 1; i++)
                {
                    WeightCoefficientMatrix[i, j] = sampleVectors[j][i];
                }
            }
        }

        public void FillFirstLayer(Vector x)
        {
            double t = N / 2;

            for (int j = 0; j < M; j++)
            {
                Neuron currentNeuron = FirstLayer[j];

                double state = 0;
            }
        }
    }


}
