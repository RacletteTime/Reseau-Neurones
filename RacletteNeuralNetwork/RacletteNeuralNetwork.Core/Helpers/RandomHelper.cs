using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacletteNeuralNetwork.Core.Helpers
{
    public static class RandomHelper
    {
        static Random random = new Random();
        public static double GetRandomNumber()
        {
            return random.NextDouble() * (1 - -1) + -1;
        }
    }
}
