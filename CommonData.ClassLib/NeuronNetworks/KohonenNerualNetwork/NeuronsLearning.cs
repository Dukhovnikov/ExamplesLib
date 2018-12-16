using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kohonen
{
    public class NeuronsLearning
    {
        public static List<Neuron> Learning()
        {
            double[,] symbols = Symbols.getSymbols();
            List<Neuron> Neurons;
            Neurons = getWeight();
            Neurons = AdjustmentWeight(Neurons, symbols);
            return Neurons;
        }

        public static List<Neuron> getWeight()
        {
            List<Neuron> Neurons = new List<Neuron>();
            List<double> weight;
            Neuron neuron;
            Random rand = new Random(1);
            for (int i = 0; i < 5; i++)
            {
                weight = new List<double>();
                for (int j = 0; j < 20; j++)
                {
                    weight.Add(rand.NextDouble());
                }
                neuron = new Neuron(-1, weight);
                Neurons.Add(neuron);
            }
            return Neurons;
        }

        public static List<Neuron> AdjustmentWeight(List<Neuron> Neurons, double[,] symbols)
        {
            int winner = 0, globalWinner = -1;
            double alpha, h;
            List<double> weight;
            for (int i = 0; i < 5; i++)
            {
                alpha = 0.9;
                while(true)
                {
                    winner = searchWinner(Neurons, symbols, i);
                    if (globalWinner == winner)
                    {
                        Neurons[winner] = new Neuron(i, Neurons[winner].getWeight());
                        globalWinner = -1;
                        winner = 0;
                        break;
                    } else
                    {
                        globalWinner = winner;
                    }
                    globalWinner = winner;
                    for (int n = 0; n < Neurons.Count(); n++)
                    {
                        weight = Neurons[n].getWeight();
                        for (int s = 0; s < 20; s++)
                        {
                            h = hc(i, Neurons[winner].getWeight()[s], Neurons[n].weight[s]);
                            weight[s] = weight[s] + h * alpha * (symbols[i, s] - weight[s]);
                        }
                    }
                    alpha -= 0.001;
                }
            }
            return Neurons;
        }

        public static int searchWinner(List<Neuron> Neurons, double[,] symbols, int numberSymbol)
        {
            int winner = 0;
            double[] distance = new double[Neurons.Count()];
            double temp = 100;
            double temp1 = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    distance[i] += Math.Pow(symbols[numberSymbol,j] - Neurons[i].getWeight()[j], 2);
                }
                distance[i] = Math.Sqrt(distance[i]);
            }
            for (int i = 0; i < distance.Length; i++)
            {
                if (distance[i] < temp)
                {
                    if (Neurons[i].getIDsymbol() == -1)
                    {
                        temp = distance[i];
                        winner = i;
                    }
                }
            }
            return winner;
        }

        public static double hc(int k, double weightWinner, double weight)
        {
            double distance = Math.Sqrt(Math.Pow(weightWinner - weight, 2));
            return Math.Exp(-distance / Math.Exp(-k));
        }
    }
}
