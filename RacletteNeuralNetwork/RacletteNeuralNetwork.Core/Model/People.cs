using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacletteNeuralNetwork.Core.Model
{
    public class People
    {
        public bool Gender { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public bool Smoke { get; set; }
        public bool Drink { get; set; }
        public bool HealthyFood { get; set; }
        public bool Stress { get; set; }
        public bool Sport { get; set; }
        public bool Sedentary { get; set; }
        public bool Cancer { get; set; }
        public double Error { get; set; }

        public People(bool _gender, int _age, int _weight, bool _smoke, bool _drink, bool _healthyFood, bool _stress, bool _sport, bool _sedentary)
        {
            this.Gender = _gender;
            this.Age = _age;
            this.Weight = _weight;
            this.Smoke = _smoke;
            this.Drink = _drink;
            this.HealthyFood = _healthyFood;
            this.Stress = _stress;
            this.Sport = _sport;
            this.Sedentary = _sedentary;
        }

        public People() { }

    }
}
