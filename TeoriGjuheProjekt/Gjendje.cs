using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriGjuheProjekt
{
    class Gjendje
    {

        public List<String> _gjendje { get; set; }
        /// public IEnumerator enumerator{get; set;}

        public Gjendje(List<String> gjendjet)
        {
            _gjendje = gjendjet;
        }
        public Gjendje() { }
        public List<String> FutGJendjet()
        {
            _gjendje = new List<String>();

            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\Prov\Gjendje.txt");
            while ((line = file.ReadLine()) != null)
            {
                _gjendje.Add(line);
                counter++;
            }

            file.Close();
            return _gjendje;
        }

        public string getgjendja(int i)
        {
            string gjendja = _gjendje[i].ToString();
            return gjendja;
        }

        public void AfishoGjendjet()
        {

            foreach (var i in _gjendje)
            {
                Console.WriteLine(i);
            }
        }
    }
}
