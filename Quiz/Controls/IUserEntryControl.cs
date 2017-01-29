using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Controls
{
   interface IUserEntryControl
   {
      TextEntryState TextEntryState 
      {
         get; 
      }

      event EventHandler<EventArgs> TextEntryStateChanged;
   }
}
