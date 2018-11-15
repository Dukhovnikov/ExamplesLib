using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKohonen
{
    public class KohonenNetwork
    {
        private readonly Input[] inputs;
        private readonly Neuron[] neurons;

        public void Study(int[] input, int correctAnswer)
        {
            Neuron neuron = neurons[correctAnswer];

            for (int i = 0; i < neuron.IncomingLinks.Length; i++)
            {
                Link incomingLink = neuron.IncomingLinks[i];
                incomingLink.Weight = incomingLink.Weight + 0.5 * (input[i] - incomingLink.Weight);
            }
        }

        /// <summary>
        /// Пропустить вектор через нейронную сеть 
        /// </summary>
        public int Handle(int[] input)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                Input inputNeuron = inputs[i];

                foreach (var outgoingLink in inputNeuron.OutgoingLinks)
                {
                    outgoingLink.Neuron.Power += outgoingLink.Weight * input[i];
                }
            }

            int maxIndex = 0;
            for (int i = 0; i < neurons.Length; i++)
            {
                if (neurons[i].Power > neurons[maxIndex].Power)
                {
                    maxIndex = i;
                }
            }

            //снять импульс со всех нейронов:
            foreach (var outputNeuron in neurons)
            {
                outputNeuron.Power = 0;
            }

            return maxIndex;
        }
    }
}
