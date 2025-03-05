using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocabulary
{
    [Serializable]
   internal class Defintion {
        public string Partofspeech { get; set; }
        public string Meaning { get; set; }
        public string Sentence { get; set; }
    }
     


    [Serializable]
    internal class WordEntry
    {
        public string Word { get; set; }
        
        public List<Defintion> Definitions { get; set; } = new List<Defintion>();
    } 
}
