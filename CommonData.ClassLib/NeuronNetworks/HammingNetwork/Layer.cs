using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.ClassLib.NeuronNetworks.HammingNetwork
{
    public class Layer
    {
        public IList<Neuron> Neurons { get; set; }

        public Layer(int numNeurons)
        {
            Neurons = new List<Neuron>();

            for (int i = 0; i < numNeurons; i++)
            {
                Neurons.Add(new Neuron());
            }
        }
    }
}
