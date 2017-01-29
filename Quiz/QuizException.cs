using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
   /// <summary>
   /// Base class for exceptions in the Quiz app
   /// </summary>
   [Serializable]
   public class QuizException : Exception
   {
      /// <summary>
      /// Initializes a new instance of class QuizException
      /// </summary>
      public QuizException()
         : base()
      {
      }

      /// <summary>
      /// Initializes a new instance of class QuizException
      /// </summary>
      /// <param name="message">information about the exception</param>
      public QuizException(string message)
         : base(message)
      {
      }

      /// <summary>
      /// Initializes a new instance of class QuizException
      /// </summary>
      /// <param name="message">information about the exception</param>
      /// <param name="inner">the root cause of the exception</param>
      public QuizException(string message, Exception inner)
         : base(message, inner)
      {
      }

      /// <summary>
      /// Initializes a new instance of class QuizException
      /// </summary>
      /// <param name="info">serialization info</param>
      /// <param name="context">streaming context</param>
      protected QuizException(SerializationInfo info, StreamingContext context)
         :base(info, context)
      {
      }
   }
}
