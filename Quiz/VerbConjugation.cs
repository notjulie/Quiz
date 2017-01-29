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
      public string name
      {
         get;
         set;
      }

      [XmlAttribute]
      public string io
      {
         get;
         set;
      }

      [XmlAttribute]
      public string tu
      {
         get;
         set;
      }

      [XmlAttribute]
      public string lui
      {
         get;
         set;
      }

      [XmlAttribute]
      public string noi
      {
         get;
         set;
      }

      [XmlAttribute]
      public string voi
      {
         get;
         set;
      }

      [XmlAttribute]
      public string loro
      {
         get;
         set;
      }
   }
}
