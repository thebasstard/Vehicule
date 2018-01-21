using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicule
{
    public class Moto : Vehicule
    {
        public Moto(string nom, Energies energie) : base(nom, 2, energie)
        {

        }

        public Moto(string nom, double prix) : base(nom, prix)
        {

        }

        public override string Description
        {
            get
            {
                return "Je suis une moto \r\n" + base.Description;
            }
        }

        public override double PRK
        {
            get
            {
                return 10;
            }
        }

        public override void CalculerConso()
        {
            throw new NotImplementedException();
        }
    }
}
