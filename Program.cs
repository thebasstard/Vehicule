using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;



namespace Vehicule
{
    public enum Energies
    {
        Aucune,
        Essence,
        Gazole,
        GPL,
        Electrique
    }

    class Program
    {
        static void Main(string[] args)
        {
            var v = new Voiture("Saxo",Energies.Gazole);

            Vehicule voi = new Voiture("Mercedes", Energies.Gazole);
            Vehicule moto = new Moto("Kawazaki", Energies.Essence);


            //Console.WriteLine(v.Description);

            Console.WriteLine(voi.Description);
            Console.WriteLine(moto.Description);

            //IComparable Voital = new Voiture("BMW",Energies.Essence);
            IComparable Voital = new Voiture("BMW", Energies.Essence);
            IComparable Motal = new Moto("Honda", Energies.Essence);

 
            //Transtypage
            //cast sécurisé
            IComparable MotMot = new Moto("Yamaha", Energies.Essence);
            if (MotMot is Moto)
            {
                Moto M1 = (Moto)MotMot;
                Console.WriteLine(M1.Description);
            }

            Vehicule v12 = Voital as Vehicule;
            if (v12 != null)
            {
                Console.WriteLine(v12.Description);
            }
            

            Console.WriteLine("");

            if (Voital.CompareTo(Motal) < 0 )
            {
                Console.WriteLine("voiture a un PRK < moto");
            }
            else if (Voital.CompareTo(Motal) > 0)
            {
                Console.WriteLine("voiture a un PRK > moto");
            }
            else
            {
                Console.WriteLine("voiture a un PRK = moto");
            }

            Console.WriteLine("");
            Console.WriteLine("");


            Decrire(v12);


            Console.WriteLine("");

            ////tableaux
            Voiture Megane = new Voiture("Megane", 19000);
            Moto Intruder = new Moto("Intruder", 13000);
            Voiture Enzo = new Voiture("Enzo", 380000);
            Moto Yamaha = new Moto("Yamaha XJR1300", 11000);

            var tab = Vehicule.LePlusCher(Megane, Intruder, Enzo, Yamaha);

            //Console.WriteLine(tab.Nom);

            ////listes
            SortedList<Vehicule,string> Liste3 = new SortedList<Vehicule,string>();

            Liste3.Add(Megane,Megane.Nom);
            Liste3.Add(Intruder, Intruder.Nom);
            //Liste3.Add(Enzo, Enzo.Nom);
            //Liste3.Add(Yamaha, Yamaha.Nom);

            Dictionary<string, Vehicule> dico = new Dictionary<string, Vehicule>();

            foreach (var paire in Liste3)
            {
                Console.WriteLine("{0} : {1}", paire.Key.Nom, paire.Key.Prix);
                dico.Add(paire.Value, paire.Key);
            }

            Liste3.Clear();

            foreach (var paire in dico)
            {
                Console.WriteLine("{0} : {1}", paire.Key, paire.Value.Prix);              
            }

            string[] NomsVehicules = { "Clio", "Saxo", "208" };

            foreach(string nom in NomsVehicules)
            {
                if (dico.ContainsKey(nom))
                {
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("");


            DelegueEntretien delEnt = null;//déclaration d'un délégué
            delEnt += ChangerPneus;//branchement d'une méthode de changement de pneus
            delEnt += Vidanger;
            delEnt += RetoucherPeinture;

            Intruder.Entretenir(DateTime.Now, delEnt);

            foreach (var entretien in Intruder.CarnetEntretien)
            {
                Console.WriteLine(entretien.Value);
            }

            


            Console.ReadKey();
        }



        static void Decrire(Object o)
        {
            Type t = o.GetType();

            Console.WriteLine($"Nom du type : {t}");

            Console.WriteLine("");

            Console.WriteLine($"Nom du type dont il herite : {t.BaseType}");

            Console.WriteLine("");

            //le nom des interfaces qu'il implémente
            foreach (Type t1 in t.GetInterfaces())
            {
                Console.WriteLine($"Nom de l'interface qu'il implémente : {t1.Name}");
            }

            Console.WriteLine("");

            Console.WriteLine($"Membres de {t.Name}");

            Console.WriteLine(""); 

            //liste des membres et types de noms
            foreach (var m in t.GetMembers())
            {
                Console.WriteLine("Type: {0}, Nom: {1}", m.MemberType, m.Name);
            }


            

        }


        static void ChangerPneus(Vehicule vehicle)
        {
            DateTime date = vehicle.CarnetEntretien.Keys.Last();
            vehicle.CarnetEntretien[date] += "\nchanger les pneus";
            
        }

        static void Vidanger(Vehicule vehicle)
        {
            DateTime date = vehicle.CarnetEntretien.Keys.Last();
            vehicle.CarnetEntretien[date] += "\nvidanger l'huile";
           
        }

        static void RetoucherPeinture(Vehicule vehicle)
        {
            DateTime date = vehicle.CarnetEntretien.Keys.Last();
            vehicle.CarnetEntretien[date] += "\nretoucher la peinture";

        }
    }
}
