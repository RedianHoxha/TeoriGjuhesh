using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriGjuheProjekt
{
    class Automat
    {
        public ArrayList Automati { get; set; }
        public Alfabet alfabetiAutomatit { get; set; }
        public Gjendje gjendjeAutomatit { get; set; }
        public Automat(ArrayList automat,Alfabet alfabetautomati,Gjendje gjendjeautomati)
        {
            Automati = automat;
            alfabetiAutomatit = alfabetautomati;
            gjendjeAutomatit = gjendjeautomati;
          
        }

        public Automat()
        {
        }

        public void KrijoAutomat()
        { 
            bool mbaroi = true;
            int id = 1;
            Automati = new ArrayList();
            do
            {
             
                Console.WriteLine("Fusni gjendjen e nisjes");
                string gj1= Console.ReadLine();

                Console.WriteLine("Fusni shkronjene  alfabetit");
                string alf = Console.ReadLine();

                Console.WriteLine("Fusni gjendjen e mberritjes");
                string gj2 = Console.ReadLine();


                //k.KrijoKalim(id, gj1, alf, gj2);
                Kalimet k = new Kalimet(id, gj1, alf, gj2);
                Automati.Add(k);
                //k.afisho();
                id++;

                Console.WriteLine("Deshironi te fusni kalim tjt?");
                Console.WriteLine("Nqs po shtyp 'Y' perndryshe 'N'");
                string Pergjigje = Console.ReadLine();
                if(Pergjigje.ToUpper()=="N")
                {
                    mbaroi = false;
                }

            } while (mbaroi);

        }

        public void MbushmeKalime(){
                  Automati = new ArrayList();
                  int counter = 0;
                  string line;

                // Read the file and display it line by line.  
                System.IO.StreamReader file = new System.IO.StreamReader(@"c:\Prov\Kalimet.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                string gjendje1, shkralfabet, gjendjefund;
                gjendje1 = line.Substring(0, 2);
                shkralfabet = line.Substring(2, 1);
                gjendjefund = line.Substring(3,2);
                Kalimet kalim = new Kalimet(counter, gjendje1, shkralfabet, gjendjefund);
                        Automati.Add(kalim);
                        counter++;
                    }

            file.Close();

        }


        public void AfishoKalime()
        {
            Kalimet kalimetObject = new Kalimet();
            
                foreach( var i in Automati)
                {
                kalimetObject = (Kalimet)i;
               Console.WriteLine(kalimetObject.afisho());
                //Console.WriteLine (kalimetObject.gjendjanisjes);

             
                }
            
        }

        //public ArrayList KontrolliEpsilon1(Alfabet alfabetiAutomatit, string kalim,Gjendje GjendjeteAutomatit)
        //{

        //    ArrayList gjendjetEpsilon = new ArrayList();

        //    Kalimet kalimetObject = new Kalimet();

        //    Alfabet shkronjalfabeti = new Alfabet();



      

        //    return gjendjetEpsilon;
        //}



            public void Konverto(Gjendje gjendjetautomatit,Alfabet alfabetiautomatit)
        {
            int count=0;
            //kshu do jet alfabeti per kalimin epsilon
           string epsi="ep";
            bool ndryshoi = true;
            Alfabet alfabetobjekt = new Alfabet();
            ArrayList kontrollieps1 = KontrollEpsilon1(gjendjetautomatit,epsi);//kontrolli 1
            ArrayList kontrollpasperseritje;
            do
            {
                Gjendje gjendje = new Gjendje(kontrollieps1);
                kontrollpasperseritje = KontrollEpsilonperseritje(gjendje, epsi);
                if(kontrollieps1.Equals(kontrollpasperseritje))
                {
                    ndryshoi = false;
                }

            } while (ndryshoi);

            Gjendje gjendjeperkontrollalfabeti = new Gjendje(kontrollpasperseritje);//arraylista me gjendjet fillesatre

            foreach(var i in alfabetiautomatit.alfabeti)
            {
                count++;
            }


            foreach(var i in alfabetiautomatit.alfabeti)//per cdo shkornje te alfabettit 
            {

                alfabetobjekt = (Alfabet)i;
                //string alfabet = alfabetobjekt.

               //  ArrayList gjendjepasalfabetiti = Kontrollalfabet(alfabet, gjendjeperkontrollalfabeti);
            }
       

        }


        public ArrayList Kontrollalfabet( string alfabet,Gjendje Gjendjeepsilon)
        {
            ArrayList gjendjealfabet = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            Gjendje gjendje = new Gjendje();

                   foreach(var gje in Gjendjeepsilon.gjendje)
                    {
                        foreach (var i in Automati)
                        {
                            kalimetObject = (Kalimet)i;

                             if(gje==kalimetObject.gjendjanisjes && alfabet == kalimetObject.alfabetkalimi)
                              {
                                  gjendjealfabet.Add(kalimetObject.gjendjemberritjes);                                
                              }

                        }
                    }
           

                return gjendjealfabet;
            
        }

        public ArrayList KontrollEpsilon1(Gjendje GjendjeteAutomatit,string epsilon)
        {
            ArrayList gjendjeepsilon1 = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            Gjendje gjendje = new Gjendje();

            foreach(var gjen in GjendjeteAutomatit.gjendje)
            {
                foreach(var i in Automati)
                {
                    kalimetObject = (Kalimet)i;
                    if(gjen==kalimetObject.gjendjanisjes&& epsilon==kalimetObject.alfabetkalimi)
                    {
                        gjendjeepsilon1.Add(kalimetObject.gjendjemberritjes);

                    }
                }
            }

            return gjendjeepsilon1;

        }

        public ArrayList KontrollEpsilonperseritje(Gjendje gjendjetepsilon1, string epsilon)
        {
            ArrayList gjendjeepsilonndryshime = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            Gjendje gjendje = new Gjendje();

            foreach (var gjen in gjendjetepsilon1.gjendje)
            {
                foreach (var i in Automati)
                {
                    kalimetObject = (Kalimet)i;
                    if (gjen == kalimetObject.gjendjanisjes) 
                    {
                        if(epsilon == kalimetObject.alfabetkalimi)
                        {
                            string gjendjare = kalimetObject.gjendjemberritjes;
                            if (gjendjetepsilon1.gjendje.Contains(gjendjare))
                            {
                                gjendjeepsilonndryshime.Add(kalimetObject.gjendjemberritjes);
                            }
                        }
                        else
                        {
                            gjendjeepsilonndryshime.Add(gjen);

                        }

                    }
                 
                }
            }

            return gjendjeepsilonndryshime;

        }
 
    }
    
}
