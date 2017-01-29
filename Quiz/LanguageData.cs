using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Quiz.XmlModel;

namespace Quiz
{
   class LanguageData
   {
      private Random random = new Random();
      private PresentIndicative pi = XMLLoader.Load<PresentIndicative>("PresentIndicative.xml");
      private Adverbs adverbs = XMLLoader.Load<Adverbs>("Adverbs.xml");
      private List<object> allItems = new List<object>();

      public LanguageData()
      {
         allItems.AddRange(pi.VerbConjugations);
         allItems.AddRange(adverbs.AdverbList);
      }

      public object GetRandomItem()
      {
         int nextIndex = random.Next(allItems.Count);
         return allItems[nextIndex];
      }
   }
}
