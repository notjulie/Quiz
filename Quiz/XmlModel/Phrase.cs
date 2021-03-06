﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz.XmlModel
{
   /// <summary>
   /// The class representation of the XML Adverb element
   /// </summary>
   public class Phrase : LanguageItem
   {
      /// <summary>
      /// Gets or sets the phrase in English
      /// </summary>
      [XmlAttribute]
      public string English
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
      /// Gets or sets the phrase in Italian
      /// </summary>
      [XmlAttribute]
      public string Italian
      {
         get;
         set;
      }
   }
}
