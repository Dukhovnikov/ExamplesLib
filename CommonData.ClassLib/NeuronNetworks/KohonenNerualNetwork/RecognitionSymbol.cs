using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kohonen
{
    public class RecognitionSymbol
    {
        public static string Calculate(List<Neuron> Neurons, List<double> S)
        {
            int answer = 0;
            double[] distance = new double[Neurons.Count()];
            double temp = 100;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    distance[i] += Math.Pow(S[j] - Neurons[i].getWeight()[j], 2);
                }
                distance[i] = Math.Sqrt(distance[i]);
            }
            for (int i = 0; i < distance.Length; i++)
            {
                if (distance[i] < temp)
                {
                    temp = distance[i];
                    answer = i;
                }
            }
            switch (Neurons[answer].getIDsymbol())
            {
                case 0:
                    return "A";
                case 1:
                    return "Б";
                case 2:
                    return "Д";
                case 3:
                    return "Н";
                case 4:
                    return "О";
            }
            return "error";
        }
    }
}
