﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Quiz.XmlModel;

namespace Quiz
{
   static class XMLLoader
   {
      static public T Load<T>(string fileName)
      {
         // get the PresentIndicative resource stream
         var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Quiz.XML." + fileName);

         // get our verbs
         XmlSerializer serializer = new XmlSerializer(
            typeof(T),
            new Type[] { 
               typeof(VerbConjugation)
               }
            );
         var result = serializer.Deserialize(stream);
         return (T)result;
      }
   }
}
