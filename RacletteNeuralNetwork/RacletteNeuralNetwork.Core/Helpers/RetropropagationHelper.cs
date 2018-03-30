using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacletteNeuralNetwork.Core.Constants;

namespace RacletteNeuralNetwork.Core.Helpers
{
    public class RetropropagationHelper
    {
        private static double SommePonderee(Neurone _neurone)
        {
            double somme = 0;
            foreach(Liaison liaison in _neurone.Liaisons)
            {
                if (liaison.PreviousNeurone != null)
                {
                    somme += liaison.PreviousNeurone.Sortie * liaison.Weight;
                }
                else
                {
                    somme += liaison.Variable * liaison.Weight;
                }
            }
            somme += _neurone.Biais * _neurone.WeightBiais;
            return somme;
        }

        private static double Sigmoide(double somme)
        {
            double sigmoideResult;
            sigmoideResult = 1 / (1 + Math.Exp(-somme));
            return sigmoideResult;
        }

        public static void CalcSortieNeurone(Neurone _neurone)
        {
            double sommePonderee = SommePonderee(_neurone);
            _neurone.Sortie = Sigmoide(sommePonderee);
        }

        public static void CalcErreurLastNeurone(Neurone _neurone)
        {
            _neurone.Erreur = NetworkConstants.SortieSouhaitee - _neurone.Sortie;
        }

        public static void CalcErreurPreviousNeurones(Neurone _neurone)
        {
            foreach(Liaison _liaison in _neurone.Liaisons)
            {
                if (_liaison.PreviousNeurone != null)
                {
                    _liaison.PreviousNeurone.Erreur = _neurone.Erreur * _liaison.Weight;
                }
            }
        }

        public static void UpdateWeights(Neurone _neurone)
        {
            foreach(Liaison _liaison in _neurone.Liaisons)
            {
                if (_liaison.PreviousNeurone != null)
                {
                    _liaison.Weight = _liaison.Weight + NetworkConstants.ConstApprentissage * _neurone.Erreur * _neurone.Sortie * (1 - _neurone.Sortie) * _liaison.PreviousNeurone.Sortie;
                }
                else
                {
                    _liaison.Weight = _liaison.Weight + NetworkConstants.ConstApprentissage * _neurone.Erreur * _neurone.Sortie * (1 - _neurone.Sortie) * _liaison.Variable;
                }
            }

            _neurone.WeightBiais = _neurone.WeightBiais + NetworkConstants.ConstApprentissage * _neurone.Erreur * _neurone.Sortie * (1 - _neurone.Sortie) * _neurone.Biais;
        }
    }
}
