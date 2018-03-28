using RacletteNeuralNetwork.Core;
using RacletteNeuralNetwork.Core.Helpers;
using RacletteNeuralNetwork.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacletteNeuralNetwork.Batch
{
    public class Program
    {
        static void Main(string[] args)
        {
            NetworkService networkService = new NetworkService();
            List<double> Variables = new List<double>()
            {
                0.8,
                0.2
            };
            List<Couche> Couches = new List<Couche>()
            {
                new Couche(2),
                new Couche(1)
            };

            Couches = networkService.GenerateNetwork(Couches, Variables);

            Couches = networkService.IterateInNetwork(Couches);

            Console.ReadKey();
        }
    }
}
