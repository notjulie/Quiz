using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace Quiz.DB
{
   class Database : IDisposable
   {
      #region Private Fields

      private SQLiteConnection connection;

      #endregion

      #region Public Methods

      public void GetRandomQuestionID()
      {
         throw new NotImplementedException("Getting random question not implemented");
      }

      #endregion

      #region IDisposable

      public void Dispose()
      {
         if (connection != null)
         {
            connection.Dispose();
            connection = null;
         }
      }

      #endregion

      #region Static Public Methods

      static public Database Create(string fileName)
      {
         SQLiteConnection.CreateFile(fileName);
         return Open(fileName);
      }

      static public Database Open(string fileName)
      {
         Database result = new Database();
         try
         {
            result.OpenFile(fileName);
            return result;
         }
         catch
         {
            result.Dispose();
            throw;
         }
      }

      static public Database OpenOrCreate(string fileName)
      {
         if (!File.Exists(fileName))
            return Create(fileName);
         else
            return Open(fileName);
      }

      #endregion

      #region Private Methods

      private void OpenFile(string fileName)
      {
         connection = new SQLiteConnection("Data Source=" + fileName + ";Version=3;");
         connection.Open();
      }

      #endregion
   }
}
