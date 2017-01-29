using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz.XmlModel
{
   /// <summary>
   /// The class representation of the XML Adverbs element
   /// </summary>
   public class Adverbs
   {
      /// <summary>
      /// Gets or sets the verb conjugations
      /// </summary>
      [XmlArray("AdverbList")]
      public Adverb[] AdverbList
      {
         get;
         set;
      }
   }
}
