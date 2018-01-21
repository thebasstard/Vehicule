using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicule
{
    public class Voiture : Vehicule
    {
       

        public Voiture(string nom, Energies energie) : base(nom, 4, energie)
        {
            
        }

        public Voiture(string nom, double prix) : base (nom, prix)
        {

        }

        public override string Description
        {
            get
            {
                return "Je suis une voiture \r\n" + base.Description;
            }
        }

        public override double PRK
        {
            get
            {
                return 5;
            }
        }

        public override void CalculerConso()
        {
            throw new NotImplementedException();
        }

    }
}
