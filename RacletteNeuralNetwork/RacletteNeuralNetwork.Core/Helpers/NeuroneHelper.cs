using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacletteNeuralNetwork.Core.Helpers
{
    public static class NeuroneHelper
    {
        public static void CreateLiaison(Neurone _neurone, double variable)
        {
            if(_neurone.Liaisons == null)
            {
                _neurone.Liaisons = new List<Liaison>();
            }
            _neurone.Liaisons.Add(new Liaison(variable, RandomHelper.GetRandomNumber()));
        }

        public static void CreateLiaison(Neurone _neurone, Neurone _previousNeurone)
        {
            if (_neurone.Liaisons == null)
            {
                _neurone.Liaisons = new List<Liaison>();
            }
            _neurone.Liaisons.Add(new Liaison(_previousNeurone, RandomHelper.GetRandomNumber()));
        }
    }
}
