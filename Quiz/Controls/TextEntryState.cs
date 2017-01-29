using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Controls
{
   /// <summary>
   /// States of the response in a TextEntry control
   /// </summary>
   public enum TextEntryState
   {
      /// <summary>
      /// The correct answer has not been given
      /// </summary>
      Unanswered,

      /// <summary>
      /// The correct answer was given without cheating
      /// </summary>
      Correct,

      /// <summary>
      /// The user got the correct answer by cheating
      /// </summary>
      Cheated
   }
}
