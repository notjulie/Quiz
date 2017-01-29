using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz.XmlModel
{
   /// <summary>
   /// Class representation of the PresentIndicative.xml resource file
   /// </summary>
   public class PresentIndicative
   {
      /// <summary>
      /// Gets or sets the verb conjugations
      /// </summary>
      [XmlArray("VerbConjugations")]
      public VerbConjugation[] VerbConjugations
      {
         get;
         set;
      }
   }
}
