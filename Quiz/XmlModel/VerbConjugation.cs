using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz.XmlModel
{
   /// <summary>
   /// Class representation of the serializable VerbConjugation XML element
   /// </summary>
   public class VerbConjugation : LanguageItem
   {
      /// <summary>
      /// Gets a key string that identifies this item within the collection it comes from
      /// </summary>
      public override string Key
      {
         get 
         {
            return Name;
         }
      }

      /// <summary>
      /// Gets or sets the verb name
      /// </summary>
      [XmlAttribute]
      public string Name
      {
         get;
         set;
      }

      /// <summary>
      /// Gets or sets the first person singular form
      /// </summary>
      [XmlAttribute]
      public string Io
      {
         get;
         set;
      }

      /// <summary>
      /// Gets or sets the second person singular form
      /// </summary>
      [XmlAttribute]
      public string Tu
      {
         get;
         set;
      }

      /// <summary>
      /// Gets or sets the third person singular form
      /// </summary>
      [XmlAttribute]
      public string Lui
      {
         get;
         set;
      }

      /// <summary>
      /// Gets or sets the first person plural form
      /// </summary>
      [XmlAttribute]
      public string Noi
      {
         get;
         set;
      }

      /// <summary>
      /// Gets or sets the second person plural form
      /// </summary>
      [XmlAttribute]
      public string Voi
      {
         get;
         set;
      }

      /// <summary>
      /// Gets or sets the third person plural form
      /// </summary>
      [XmlAttribute]
      public string Loro
      {
         get;
         set;
      }
   }
}
