using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.XmlModel
{
   /// <summary>
   /// Base class for items that can be used in quiz questions
   /// </summary>
   public abstract class LanguageItem
   {
      /// <summary>
      /// Gets a key string that identifies this item within the collection it comes from
      /// </summary>
      public abstract string Key
      {
         get;
      }
   }
}
