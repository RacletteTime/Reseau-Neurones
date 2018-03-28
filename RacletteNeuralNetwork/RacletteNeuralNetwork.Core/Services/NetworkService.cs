using RacletteNeuralNetwork.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacletteNeuralNetwork.Core.Services
{
    public class NetworkService
    {
        public List<Couche> GenerateNetwork(List<Couche> _couches, List<double> _variables)
        {
            for (int i = 0; i < _couches.Count; i++)
            {
                if (i == 0)
                {
                    foreach (Neurone _neurone in _couches[i].Neurones)
                    {
                        foreach (double _variable in _variables)
                        {
                            NeuroneHelper.CreateLiaison(_neurone, _variable);
                        }
                    }
                }
                else
                {
                    foreach (Neurone _neurone in _couches[i].Neurones)
                    {
                        foreach (Neurone _previousNeurone in _couches[i - 1].Neurones)
                        {
                            NeuroneHelper.CreateLiaison(_neurone, _previousNeurone);
                        }
                    }
                }
            }

            return _couches;
        }

        public List<Couche> IterateInNetwork(List<Couche> _couches)
        {
            foreach (Couche _couche in _couches)
            {
                foreach (Neurone _neurone in _couche.Neurones)
                {
                    RetropropagationHelper.CalcSortieNeurone(_neurone);
                }
            }

            for (int i = _couches.Count - 1; i >= 0; i--)
            {
                foreach (Neurone _neurone in _couches[i].Neurones)
                {
                    if (_neurone == _couches[i].Neurones[0])
                    {
                        RetropropagationHelper.CalcErreurLastNeurone(_neurone);
                    }
                    else
                    {
                        RetropropagationHelper.CalcErreurPreviousNeurones(_neurone);
                    }
                    RetropropagationHelper.UpdateWeights(_neurone);
                }
            }

            return _couches;
        }
    }
}
