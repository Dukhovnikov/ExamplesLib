using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kohonen
{
    public class Neuron
    {
        public int IDsymbol;
        public List<double> weight;

        public Neuron(int IDsymbol, List<double> weight)
        {
            this.IDsymbol = IDsymbol;
            this.weight = weight;
        }

        public int getIDsymbol()
        {
            return IDsymbol;
        }

        public void setIDsymbol(int IDsymbol)
        {
            this.IDsymbol = IDsymbol;
        }

        public List<double> getWeight()
        {
            return weight;
        }

        public void setWeight(List<double> weight)
        {
            this.weight = weight;
        }
    }
}
