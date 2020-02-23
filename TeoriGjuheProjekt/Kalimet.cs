using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TeoriGjuheProjekt.Gjendje;
//using TeoriGjuheProjekt.Alfabet;


namespace TeoriGjuheProjekt
{
    class Kalimet
    {
        public int IdKalimi { get; set; }

        public string gjendjanisjes { get; set; }
        public string alfabetkalimi { get; set; }
        public string gjendjemberritjes { get; set; }
        public List<String> _kalimet { get; set; }

        public Kalimet() { }
        public Kalimet(int id, string gjendjenisjes, string alfabet, string gjendjemberritje)
        {
            IdKalimi = id;
            gjendjanisjes = gjendjenisjes;
            alfabetkalimi = alfabet;
            gjendjemberritjes = gjendjemberritje;
        }

        //Gjendje gj = new Gjendje();
        //Alfabet alfa = new Alfabet();
        //public void KrijoKalim(int id,string gj1, string alf, string gje2)
        //{
        //    IdKalimi = id;
        //    gjendjanisjes = gj.getgjendja(gj1);
        //    alfabetkalimi = alfa.getshkronja(alf);
        //    gjendjemberritjes = gj.getgjendja(gje2);
        //}

        public void KrijoKalim(int id, string gj1, string alf, string gj2)
        {
            IdKalimi = id;
            gjendjanisjes = gj1;
            alfabetkalimi = alf;
            gjendjemberritjes = gj2;
        }

        public List<String> MbushmeKalime()
        {
            _kalimet = new List<string>();
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\Prov\Kalimet.txt");
            while ((line = file.ReadLine()) != null)
            {
                //string gjendje1, shkralfabet, gjendjefund;
                //gjendje1 = line.Substring(0, 2);
                //shkralfabet = line.Substring(2, 1);
                //gjendjefund = line.Substring(3, 2);
                //Kalimet kalim = new Kalimet(counter, gjendje1, shkralfabet, gjendjefund);
                _kalimet.Add(line);
                counter++;
            }

            file.Close();
            return _kalimet;

        }

        public string afisho()
        {
            return "Id : " + IdKalimi + " Gjendja1 : " + gjendjanisjes + " Alfabet : " + alfabetkalimi + " Gjendjafund : " + gjendjemberritjes;
        }

    }


}
