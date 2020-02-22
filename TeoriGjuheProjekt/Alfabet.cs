using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TeoriGjuheProjekt
{
    class Alfabet
    {

        public List<String> _alfabeti { get; set; }

        public Alfabet(List<String> alfabet)
        {
            _alfabeti = alfabet;
        }

        public Alfabet() { }
        public List<String> MbushMeShkronja()
        {
            _alfabeti = new List<String>();

            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\UpWork\Alfabet.txt");
            while ((line = file.ReadLine()) != null)
            {
                _alfabeti.Add(line);
                counter++;
            }

            file.Close();

            return _alfabeti;
            // System.Console.WriteLine("Alfabeti i Automatit ka {0} Shkronja.", counter);


        }

        public string getshkronja(int i)
        {
            string shkronjaalfa = _alfabeti[i].ToString();
            return shkronjaalfa;
        }

        //    public void Afisho(Alfabet alf)
        //    {
        ////       return alf.getshkronja();
        //    }

        public void AfishoAlfabet()
        {

            foreach (var i in _alfabeti)
            {
                Console.WriteLine(i);
            }
        }
    }
}

