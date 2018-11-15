using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKohonen
{
    /// <summary>
    /// Вход нейросети.
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Связи между нейронами.
        /// </summary>
        public Link[] OutgoingLinks { get; set; }
    }

    /// <summary>
    /// Связь входа с нейроном.
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Нейрон.
        /// </summary>
        public Neuron Neuron { get; set; }

        /// <summary>
        /// Вес связи.
        /// </summary>
        public double Weight { get; set; }
    }

    public class Neuron
    {
        /// <summary>
        /// Входы нейрона.
        /// </summary>
        public Link[] IncomingLinks { get; set; }

        /// <summary>
        /// Накопленный заряд.
        /// </summary>
        public double Power { get; set; }

        public static implicit operator Neuron(Input v)
        {
            throw new NotImplementedException();
        }
    }
}
