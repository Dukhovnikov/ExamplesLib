using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.ClassLib.NeuronNetworks.HammingNetwork
{
    public class Neuron
    {
        /// <summary>Веса входящих связей нейрона</summary>
        public IList<double> Weights { get; set; }

        /// <summary>Смещение нейрона</summary>
        public double Bias { get; set; }

        /// <summary>Заряд нейрона/// </summary>
        public double Power { get; set; }

        public Neuron()
        {
            Weights = new List<double>();
            Power = 0;
        }

        internal void ResetPower()
        {
            Power = 0;
        }
    }
}
