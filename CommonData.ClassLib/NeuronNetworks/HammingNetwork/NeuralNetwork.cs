using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.ClassLib.NeuronNetworks.HammingNetwork
{
    public class NeuralNetwork
    {
        public IList<Layer> Layers { get; set; }

        //public NeuralNetwork()
        //{
        //    //Три слоя так как сеть Хэмминга - это трёхслойная сеть
        //    Layers = new List<Layer>(3);
        //}

        /// <summary>Инициализация слоев с заданым количеством нейронов на каждом уровне</summary>
        public void Initialize(int countStandarts)
        {
            //Три слоя так как сеть Хэмминга - это трёхслойная сеть
            Layers = new List<Layer>() { new Layer(countStandarts), new Layer(countStandarts), new Layer(countStandarts) };
            //foreach (var layer in Layers)
            //{   
            //    layer.Neurons = new List<Neuron>(countStandarts);
            //}
        }

        /// <summary>
        /// Обучение нейронной сети. Для сети Хэмминга - это заполнение весовых коэффициентов связей синапсов каждого нейрона.
        /// </summary>
        public bool Train(IList<double[]> letters)
        {
            if (!Layers.Any()) return false;
            if (Layers[0].Neurons.Count != letters.Count) return false;

            Layers[0].Neurons = new List<Neuron>();

            foreach (var letter in letters)
            {
                LearnLetter(letter);
            }

            return true;
        }

        private void LearnLetter(double[] letter)
        {
            Layer firstLayer = Layers[0];

            for (int i = 0; i < firstLayer.Neurons.Count; i++)
            {
                Neuron neuron = new Neuron();

                foreach (var symbol in letter)
                {
                    neuron.Weights.Add(symbol / 2);
                }
                //neuron.Bias = (double) (letter.Length / 2);
                neuron.Bias = 4.5;
                neuron.ResetPower();

                //firstLayer.Neurons[i] = neuron;
                firstLayer.Neurons.Add(neuron);
            }
        }

        public double[] Run(double[] input)
        {
            //Рассчет состояний нейронов первого слоя (входной сигнал каждого Z-нейрона по формуле (7))
            foreach (var zNeuron in Layers[0].Neurons)
            {
                zNeuron.Power = zNeuron.Bias;
                for (int i = 0; i < input.Length; i++)
                {
                    zNeuron.Power += zNeuron.Weights[i] * input[i];
                }
            }

            //Рассчет выходного сигнала Z-нейронов одновременно являющийся входным для A-нейронов
            IList<Neuron> zNeurons = Layers[0].Neurons;
            IList<Neuron> aNeurons = Layers[1].Neurons;
            for (int i = 0; i < aNeurons.Count; i++)
            {
                aNeurons[i].Power = ActivationFunction(zNeurons[i]);
            }

            //Рассчет подсети Maxnet 
            IList<double> inputsANeurons = new List<double>(); 
            for (int i = 0; i < aNeurons.Count; i++)
            {
                inputsANeurons.Add(aNeurons[i].Power);
            }
            IList<double> outputsANeurons = getANeuronsOutputSignals(inputsANeurons);

            return outputsANeurons.ToArray();
        }

        private double ActivationFunction(Neuron neuron)
        {
            const double K1 = 0.1;
            const double Un = 20;

            double power = neuron.Power;

            if (power < 0) return 0;
            if (0 <= power && power <= Un) return K1 * power;
            if (power > Un) return Un;

            return 0;
        }

        private double ActivationFunctionG(double input)
        {
            if (input > 0)
            {
                return input;
            }
            else
            {
                return 0;
            }
        }

        private IList<double> getANeuronsOutputSignals(IList<double> Zneurons)
        {
            List<double> Aneurons = new List<double>();
            double g = 0;
            for (int k = 0; k < Zneurons.Count() - 1; k++)
            {
                Aneurons.Clear();
                for (int i = 0; i < Zneurons.Count(); i++)
                {
                    for (int j = 0; j < Zneurons.Count(); j++)
                    {
                        if (i != j)
                        {
                            g += Zneurons[j];
                        }
                    }
                    g = g * 0.2;
                    g = Zneurons[i] - g;
                    if (g <= 0)
                    {
                        g = 0;
                    }
                    Aneurons.Add(g);
                }
                Zneurons.Clear();
                for (int i = 0; i < Aneurons.Count(); i++)
                {
                    Zneurons.Add(Aneurons[i]);
                }
            }
            return Aneurons;
        }
    }
}
