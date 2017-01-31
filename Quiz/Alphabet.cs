using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
   static class Alphabet
   {
      public static bool IsConsonant(char c)
      {
         return "bcdfghjklmnpqrstvwxyz".IndexOf(c) >= 0;
      }
   }
}
