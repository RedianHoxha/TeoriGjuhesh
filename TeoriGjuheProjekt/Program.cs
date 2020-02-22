using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriGjuheProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            string _gjendjeNisje = string.Empty, _characterAlfabet = string.Empty, _gjendjeFundore = string.Empty;
            List<string> _kalimetMeGjendjeNisjeEdheGjendjeFundoreTeNJejte = new List<string>();
            List<string> _kalimetAfterConverting = new List<string>();

            List<string> _alfabetiCharacters = new Alfabet().MbushMeShkronja();

            List<string> _gjendjeList = new Gjendje().FutGJendjet();

            List<string> _kalimetList = new Kalimet().MbushmeKalime();

            for (int i = 0; i < _kalimetList.Count(); i++)
            {
                string _kalim = _kalimetList[i];
                _gjendjeNisje = _kalim.Substring(0, 2);
                _characterAlfabet = _kalim.Substring(2, 1);
                _gjendjeFundore = _kalim.Substring(3, 2);

                if (_gjendjeNisje.Equals(_gjendjeFundore))
                {
                    _kalimetMeGjendjeNisjeEdheGjendjeFundoreTeNJejte.Add(_kalim);
                    _kalimetList.Remove(_kalim); // heq ato qe jane te njejta
                    i--;
                }

                if (_characterAlfabet.ToLower().Equals("e"))
                {
                    _kalimetAfterConverting.AddRange(ChangeEpsilonToAlphabetCharacters(_kalim, _alfabetiCharacters));
                }
            }
            _kalimetList.RemoveAll(x => x.Contains("e"));
            _kalimetList.AddRange(_kalimetAfterConverting);


            for (int i = 0; i < _kalimetList.Count(); i++)
            {
                string _kalim = _kalimetList[i];
                _gjendjeNisje = _kalim.Substring(0, 2);
                _characterAlfabet = _kalim.Substring(2, 1);
                _gjendjeFundore = _kalim.Substring(3, 2);

                List<string> _listWithoutFirstKalim = _kalimetList.Where(x => x.ToString() != _kalim).ToList();
                for (int j = 0; j < _listWithoutFirstKalim.Count(); j++)
                {
                    string _kalimSecond = _listWithoutFirstKalim[j];
                    if (_gjendjeFundore.Equals(_kalimSecond.Substring(0, 2)) && _characterAlfabet.Equals(_kalimSecond.Substring(2, 1)))
                    {
                        _kalimetList.Add($"{_gjendjeNisje}{_characterAlfabet}{_kalimSecond.Substring(3, 2)}");

                    }
                }
            }
            _kalimetList.AddRange(_kalimetMeGjendjeNisjeEdheGjendjeFundoreTeNJejte);
            List<string> _listWithoutRepetition = _kalimetList.Distinct().ToList();
            foreach (string _kalimNew in _listWithoutRepetition)
            {
                Console.WriteLine($"{_kalimNew.Substring(0, 2)} --- {_kalimNew.Substring(2, 1)} ---  { _kalimNew.Substring(3, 2)}");
            }



            System.Console.ReadLine();
        }

        public static List<string> ChangeEpsilonToAlphabetCharacters(string _kalim, List<string> _alphabetCharacters)
        {
            List<string> _kalimeConvertedList = new List<string>();
            string _kalimLocal = string.Empty;
            foreach (string _character in _alphabetCharacters.Where(x => x != "e"))
            {
                _kalimLocal = _kalim.Replace("e", _character);
                _kalimeConvertedList.Add(_kalimLocal);
            }

            return _kalimeConvertedList;
        }
    }
}
