using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacletteNeuralNetwork.Core
{
    public class Neurone
    {
        public double Biais { get; set; }
        public double WeightBiais { get; set; }
        public List<Liaison> Liaisons { get; set; }

        public double Sortie { get; set; }
        public double Erreur { get; set; }

        public Neurone(double _biais ,double _weightBiais ,List<Liaison> _liaisons)
        {
            Biais = _biais;
            WeightBiais = _weightBiais;
            Liaisons = _liaisons;
        }

        public Neurone(double _biais, double _weightBiais)
        {
            Biais = _biais;
            WeightBiais = _weightBiais;
        }

        
    }
}
