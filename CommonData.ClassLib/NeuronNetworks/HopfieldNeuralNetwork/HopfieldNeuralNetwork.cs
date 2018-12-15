using CommonData.ClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.ClassLib.NeuronNetworks.HopfieldNeuralNetwork
{
    public class HopfieldNeuralNetwork
    {
        public IList<Vector> OriginalVectors { get; set; }
        public Matrix ConnectionMatrix { get; set; }

        public void Initialize()
        {
            OriginalVectors = new List<Vector>();
        }

        public bool Train(IList<double[]> letters)
        {
            ConnectionMatrix = new Matrix(letters.First().Length);

            foreach (var letter in letters)
            {
                OriginalVectors.Add(new Vector(letter));
            }

            for (int i = 0; i < OriginalVectors.Count; i++)
            {
                ConnectionMatrix += Vector.Multiplication(OriginalVectors[i], OriginalVectors[i]);
            }

            for (int i = 0; i < ConnectionMatrix.Size; i++)
            {
                ConnectionMatrix[i, i] = 0;
            }
            return true;
        }

        public double[] Run(double[] input)
        {
            Vector inputVector = new Vector(input);
            Vector currentVector = ConnectionMatrix * inputVector;

            while(SignActivationFunction(inputVector) != SignActivationFunction(currentVector))
            {
                inputVector = SignActivationFunction(currentVector);
                currentVector = ConnectionMatrix * inputVector;
            }

            return inputVector.vector;
        }

        private Vector SignActivationFunction(Vector v)
        {
            Vector signVector = new Vector(v.Size);

            for (int i = 0; i < v.Size; i++)
            {
                signVector[i] = Math.Sign(v[i]);
            }

            return signVector;
        }
    }
}
