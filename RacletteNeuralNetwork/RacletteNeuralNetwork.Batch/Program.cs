using RacletteNeuralNetwork.Core;
using RacletteNeuralNetwork.Core.Helpers;
using RacletteNeuralNetwork.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacletteNeuralNetwork.Core.Constants;
using RacletteNeuralNetwork.Core.Model;
using Json;
using Newtonsoft.Json;
using System.IO;

namespace RacletteNeuralNetwork.Batch
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<People> peoples = getData();

            Random rnd = new Random();

            List<double> Variables = getPeopleData(peoples[rnd.Next(peoples.Count - 1)]);

            int iterate = 0;
            NetworkService networkService = new NetworkService();
            double acceptedError = 0.01;
            double totalError = 0;
            List<Couche> Couches = new List<Couche>()
            {
                new Couche(5),
                new Couche(5),
                new Couche(1)
            };

            Couches = networkService.GenerateNetwork(Couches, Variables);

            //Calcule de l'erreur totale après la première itération
            foreach (People _people in peoples)
            {
                Variables = getPeopleData(_people);
                networkService.ChangeVariables(Couches, Variables);

                Couches = networkService.IterateInNetwork(Couches);

                _people.Error = Math.Abs(Couches[Couches.Count - 1].Neurones[0].Erreur);
                totalError += _people.Error;
            }

            People people;
            int peopleRan;
            //Ajustement des poids avec saisie randome d'un patient jusqu'au taux acceptable
            do
            {
                iterate++;
                peopleRan = rnd.Next(peoples.Count - 1);

                people = peoples[peopleRan];
                peoples.Remove(people);

                totalError -= people.Error;
                
                Variables = getPeopleData(people);
                networkService.ChangeVariables(Couches, Variables);

                Couches = networkService.IterateInNetwork(Couches);

                peoples.Add(people);

                totalError += Math.Abs(Couches[Couches.Count - 1].Neurones[0].Erreur);

                Console.WriteLine("Itération " + iterate + " - Taux d'erreur total: " + totalError);
            } while (totalError > acceptedError);

            Console.WriteLine("\n=====> Taux d'erreur final: " + totalError + "\n\n###### Apprentissage terminé ######\n\n");


            string continueProgram = "y";
            do
            {
                people = new People();

                Console.Write("Test du risque d'atteinte du cancer\n\n");

                Console.Write("\nSexe [h/f]: ");
                people.Gender = (Console.ReadLine() == "h" ? true : false);
                Console.Write("\nAge: ");
                people.Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nPoids: ");
                people.Weight = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nFumeur [y/n]: ");
                people.Smoke = (Console.ReadLine() == "y" ? true : false);
                Console.Write("\nConsommation d'alcool [y/n]: ");
                people.Drink = (Console.ReadLine() == "y" ? true : false);
                Console.Write("\nAlimentation saine [y/n]: ");
                people.HealthyFood = (Console.ReadLine() == "y" ? true : false);
                Console.Write("\nStress [y/n]: ");
                people.Stress = (Console.ReadLine() == "y" ? true : false);
                Console.Write("\nSport [y/n]: ");
                people.Sport = (Console.ReadLine() == "y" ? true : false);
                Console.Write("\nSedentarité [y/n]: ");
                people.Sedentary = (Console.ReadLine() == "y" ? true : false);

                Variables = getPeopleData(people);
                networkService.ChangeVariables(Couches, Variables);
                Couches = networkService.Prediction(Couches);

                Console.Write("\nRésultat: Vous avez " + Math.Round(Couches[Couches.Count-1].Neurones[0].Sortie * 100, 1) + "% de chance d'avoir un cancer.");

                Console.Write("\n\nTester à nouveau le risque d'atteinte du cancer [y/n]? ");
                continueProgram = Console.ReadLine();
                Console.WriteLine("\n\n");
            } while ("y" == continueProgram);

            Console.ReadKey();
        }

        public static List<People> getData()
        {
            string solutiondir = Directory.GetParent(
                Directory.GetCurrentDirectory()).Parent.FullName;

            Console.WriteLine(solutiondir);

            List<People> peoples;
            using (StreamReader r = new StreamReader(solutiondir + "/Data/cancer.json"))
            {
                string json = r.ReadToEnd();
                peoples = JsonConvert.DeserializeObject<List<People>>(json);
            }

            return peoples;
        }

        private static List<double> getPeopleData(People _people)
        {
            NetworkConstants.SortieSouhaitee = Convert.ToDouble(_people.Cancer);

            Double gender = Convert.ToDouble(_people.Gender);
            Double age = Convert.ToDouble(_people.Age);
            Double weight = Convert.ToDouble(_people.Weight);
            Double smoke = Convert.ToDouble(_people.Smoke);
            Double drink = Convert.ToDouble(_people.Drink);
            Double healthyFood = Convert.ToDouble(_people.HealthyFood);
            Double sport = Convert.ToDouble(_people.Sport);
            Double sedentary = Convert.ToDouble(_people.Sedentary);

            NetworkService networkService = new NetworkService();
            List<double> Variables = new List<double>()
            {
                gender,
                age,
                weight,
                smoke,
                drink,
                healthyFood,
                sport,
                sedentary
            };

            return Variables;
        }
    }
}
