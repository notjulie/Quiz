using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz.XmlModel
{
   /// <summary>
   /// Class representation of XML Noun element
   /// </summary>
   public class Noun : LanguageItem
   {
      /// <summary>
      /// Gets or sets the noun in English
      /// </summary>
      [XmlAttribute]
      public string English
      {
         get;
         set;
      }

      /// <summary>
      /// Gets or sets the noun's gender
      /// </summary>
      [XmlAttribute]
      public Gender Gender
      {
         get;
         set;
      }

      /// <summary>
      /// Gets or sets the noun in Italian
      /// </summary>
      [XmlAttribute]
      public string Italian
      {
         get;
         set;
      }

      /// <summary>
      /// Gets a key string that identifies this item within the collection it comes from
      /// </summary>
      public override string Key
      {
         get 
         {
            return English;
         }
      }

      /// <summary>
      /// Gets the noun in Italian along with its definite article
      /// </summary>
      public string TheItalian
      {
         get
         {
            // anything starting with a vowel gets "l'"
            if (!Alphabet.IsConsonant(Italian[0]))
               return "l'" + Italian;

            // anything else feminine is "la"
            if (Gender == Gender.Feminine)
               return "la " + Italian;

            // check for "lo" cases
            if (Italian[0] == 'z')
               return "lo " + Italian;
            if (Italian[0] == 's' && Alphabet.IsConsonant(Italian[1]))
               return "lo " + Italian;
            if (Italian[0] == 'g' && Italian[1]=='n')
               return "lo " + Italian;

            // else it's "il"
            return "il " + Italian;
         }
      }
   }
}
