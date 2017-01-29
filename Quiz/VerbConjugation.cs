using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz
{
   public class VerbConjugation
   {
      [XmlAttribute]
      public string Name
      {
         get;
         set;
      }

      [XmlAttribute]
      public string Io
      {
         get;
         set;
      }

      [XmlAttribute]
      public string Tu
      {
         get;
         set;
      }

      [XmlAttribute]
      public string Lui
      {
         get;
         set;
      }

      [XmlAttribute]
      public string Noi
      {
         get;
         set;
      }

      [XmlAttribute]
      public string Voi
      {
         get;
         set;
      }

      [XmlAttribute]
      public string Loro
      {
         get;
         set;
      }
   }
}
