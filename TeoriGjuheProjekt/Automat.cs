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

        public Automat(ArrayList a)
        {
            Automati = a;
          
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

   

        public void AfishoKalime()
        {
            Kalimet kalimetObject = new Kalimet();
            
                foreach( var i in Automati)
                {
                kalimetObject = (Kalimet)i;
               Console.WriteLine(kalimetObject.afisho());
                

                  //i.Afisho();
                  //Console.WriteLine(i.ToString());
                }
            
        }

      
    }
    
}
