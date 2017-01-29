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
   /// The class representation of the XML Adverbs element
   /// </summary>
   public class Adverbs
   {
      private Collection<Adverb> adverbList = new Collection<Adverb>();

      /// <summary>
      /// Gets or sets the verb conjugations
      /// </summary>
      [XmlArray("AdverbList")]
      public Collection<Adverb> AdverbList
      {
         get
         {
            return adverbList;
         }
      }
   }
}
