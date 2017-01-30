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
   /// The class representation of the XML Phrases element
   /// </summary>
   public class Phrases
   {
      private Collection<Phrase> phraseList = new Collection<Phrase>();

      /// <summary>
      /// Gets or sets the phrase list
      /// </summary>
      [XmlArray("PhraseList")]
      public Collection<Phrase> PhraseList
      {
         get
         {
            return phraseList;
         }
      }
   }
}
