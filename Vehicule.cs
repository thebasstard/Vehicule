using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicule
{
    public abstract class Vehicule : IComparable
    {

        #region Proprietes

        private double _prix;

        private string _nom;
        private int _nbRoues;


        public abstract double PRK { get; }

        public Dictionary<DateTime,string> CarnetEntretien { get; }


        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public int NbRoues
        {
            get { return _nbRoues; }
            set { _nbRoues = value; }
        }

        public double Prix
        {
            get { return _prix; }
            set { _prix = value; }
        }


        public Energies Energie
        {
            get;
        }
        #endregion

        public virtual string Description
        {
            get { return $"Véhicule {Nom} roule sur {NbRoues} roues et à l'énergie {Energie}"; }
        }

        public Vehicule(string nom, int nbRoues, Energies energie):this()
        {
            _nom = nom;
            _nbRoues = nbRoues;
            Energie = energie;

           

        }

        public Vehicule(string nom, double prix):this()
        {
            _nom = nom;
            _prix = prix;

           
        }

        public Vehicule()
        {
            CarnetEntretien = new Dictionary<DateTime, string>();
        }


        public abstract void CalculerConso();

        
        int IComparable.CompareTo(object obj)
        {
            return PRK.CompareTo(((Vehicule)obj).PRK);
        }
        
        /*public int CompareTo(object obj)
        {
            return PRK.CompareTo(((Vehicule)obj).PRK);
        }*/
        
        
        public int CompareTo(object obj)
        {
            return Prix.CompareTo(((Vehicule)obj).Prix);
        }
        

        public static Vehicule LePlusCher(params Vehicule[] valeurs)
        {

            Vehicule vmax = valeurs[0];
            foreach (var v in valeurs)
            {
                if (v.CompareTo(vmax) > 0)
                {
                    vmax = v;
                }
            }
            return vmax;
           
        }

        public void Entretenir(DateTime date, DelegueEntretien entretien)
        {
            
            CarnetEntretien.Add(date, "");
            entretien(this);
         
        }
        
    }


    public delegate void DelegueEntretien(Vehicule vehicle);

}
