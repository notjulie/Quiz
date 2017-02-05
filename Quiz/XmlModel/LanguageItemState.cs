using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.XmlModel
{
   class LanguageItemState
   {
      public LanguageItemState(LanguageItemCategory category, string key)
      {
         // save parameters
         this.Category = category;
         this.Key = key;

         // never been asked
         LastAskedTime = DateTime.MaxValue;
      }

      public LanguageItemCategory Category
      {
         get;
         set;
      }

      public string Key
      {
         get;
         set;
      }

      public DateTime LastAskedTime
      {
         get;
         set;
      }
   }
}
