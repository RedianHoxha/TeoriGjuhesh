using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriGjuheProjekt
{
    class Program
    {
        public static List<string> _kalimetMeGjendjeNisjeEdheGjendjeFundoreTeNJejte = new List<string>();
        static void Main(string[] args)
        {
            string _gjendjeNisje = string.Empty, _characterAlfabet = string.Empty, _gjendjeFundore = string.Empty;
            
            List<string> _kalimetAfterConverting = new List<string>();
            List<string> _kalimetForRemovingAfterUpdate = new List<string>();

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
                    continue;
                }
            }


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
                        continue;
                    }
                    if(_gjendjeFundore.Equals(_kalimSecond.Substring(0, 2)) && _characterAlfabet.Equals("e"))
                    {
                        _kalimetList.Add($"{_gjendjeNisje}{_kalimSecond.Substring(2, 1)}{_kalimSecond.Substring(3, 2)}");
                        _kalimetList.Add($"{_gjendjeNisje}{_kalimSecond.Substring(2, 1)}{_gjendjeFundore}");
                        _kalimetForRemovingAfterUpdate.Add(_kalim);
                    }
                }

            }
            _kalimetList = _kalimetList.Except(_kalimetForRemovingAfterUpdate).OrderBy(x => x.ToString()).ToList();
            _kalimetList.AddRange(_kalimetMeGjendjeNisjeEdheGjendjeFundoreTeNJejte);
            List<string> _listWithoutRepetition = _kalimetList.Distinct().ToList();
            List<string> _listKalimeConverted = ChangeEpsilonToAlphabetCharacters(_listWithoutRepetition);
            _listWithoutRepetition.AddRange(_listKalimeConverted);

            _listWithoutRepetition.RemoveAll(x => x.Contains("e"));


            foreach (string _kalimNew in _listWithoutRepetition.Distinct().OrderBy(x => x.ToString()))
            {
                Console.WriteLine($"{_kalimNew.Substring(0, 2)} --- {_kalimNew.Substring(2, 1)} ---  { _kalimNew.Substring(3, 2)}");
            }

            Console.ReadLine();
        }

        public static List<string> ChangeEpsilonToAlphabetCharacters(List<string> _listKalime)
        {
            List<string> _kalimeConvertedList = new List<string>();
            List<string> _kalimeThatContainsCharacterE = _listKalime.Where(x => x.Contains("e")).ToList();
            string _kalimLocal = string.Empty;
            List<string> _kalimeThatHaveFirstStateSameWithLastStateSameOfE = new List<string>();

            foreach (string _kalim in _kalimeThatContainsCharacterE)  // q0eq3
            {
                if (_kalim.Substring(0, 2).Equals(_kalim.Substring(3, 2)))
                    continue;
                _kalimeThatHaveFirstStateSameWithLastStateSameOfE = _listKalime.Where(x => x.StartsWith(_kalim.Substring(3, 2))).ToList();
                foreach(string _kalimSecond in _kalimeThatHaveFirstStateSameWithLastStateSameOfE) //q3aq3 ,  q3bq3
                {
                    _kalimLocal = _kalim.Replace("e", _kalimSecond.Substring(2, 1)); //q0aq3, q0bq3
                    _kalimeConvertedList.Add(_kalimLocal);
                }
                
            }
            return _kalimeConvertedList;
        }
    }
}
