using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
      private Collection<VerbConjugation> verbConjugations = new Collection<VerbConjugation>();

      /// <summary>
      /// Gets or sets the verb conjugations
      /// </summary>
      [XmlArray("VerbConjugations")]
      public Collection<VerbConjugation> VerbConjugations
      {
         get
         {
            return verbConjugations;
         }
      }
   }
}
