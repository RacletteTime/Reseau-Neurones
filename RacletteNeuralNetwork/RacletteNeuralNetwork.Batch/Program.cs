using RacletteNeuralNetwork.Core;
using RacletteNeuralNetwork.Core.Helpers;
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
            for (int i = 0; i < Couches.Count; i++)
            {
                if (i == 0)
                {
                    foreach (Neurone _neurone in Couches[i].Neurones)
                    {
                        foreach (double _variable in Variables)
                        {
                            NeuroneHelper.CreateLiaison(_neurone, _variable);
                        }
                    }
                }
                else
                {
                    foreach (Neurone _neurone in Couches[i].Neurones)
                    {
                        foreach (Neurone _previousNeurone in Couches[i-1].Neurones)
                        {
                            NeuroneHelper.CreateLiaison(_neurone, _previousNeurone);
                        }
                    }
                }
            }

            foreach(Couche _couche in Couches)
            {
                foreach(Neurone _neurone in _couche.Neurones)
                {
                    RetropropagationHelper.CalcSortieNeurone(_neurone);
                }
            }

            for(int i = Couches.Count -1; i>=0; i--)
            {
                foreach(Neurone _neurone in Couches[i].Neurones)
                {
                    if(_neurone == Couches[i].Neurones[0])
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

            Console.ReadKey();
        }
    }
}
