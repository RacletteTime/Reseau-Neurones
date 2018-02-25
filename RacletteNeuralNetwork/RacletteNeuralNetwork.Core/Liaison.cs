using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacletteNeuralNetwork.Core
{
    public class Liaison
    {
        public double Variable { get; set; }
        public Neurone PreviousNeurone { get; set; }
        public double Weight { get; set; }

        public Liaison(double _variable, double _weight)
        {
            Variable = _variable;
            Weight = _weight;
        }
        public Liaison(Neurone _neurone, double _weight)
        {
            PreviousNeurone = _neurone;
            Weight = _weight;
        }
    }
}
