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
   /// Class representation of XML Nouns element
   /// </summary>
   public class Nouns
   {
      private Collection<Noun> nounList = new Collection<Noun>();

      /// <summary>
      /// Gets or sets the verb conjugations
      /// </summary>
      [XmlArray("NounList")]
      public Collection<Noun> NounList
      {
         get
         {
            return nounList;
         }
      }
   }
}
