using RacletteNeuralNetwork.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacletteNeuralNetwork.Core
{
    public class Couche
    {
        public int CoucheNumber { get; set; }
        public List<Neurone> Neurones { get; set; }
        public Couche(int _nbNeurones)
        {
            Neurones = new List<Neurone>();
            for (int i = 1; i <= _nbNeurones; i++)
            {
                Neurones.Add(new Neurone(1, RandomHelper.GetRandomNumber()));
            }
        }
    }
}
