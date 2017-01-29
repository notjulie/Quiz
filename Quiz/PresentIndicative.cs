using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz
{
   public class PresentIndicative
   {
      [XmlArray("VerbConjugations")]
      public VerbConjugation[] VerbConjugations
      {
         get;
         set;
      }
   }
}
