﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Quiz.XmlModel;

namespace Quiz
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      /// <summary>
      /// Initializes a new instance of class MainWindow
      /// </summary>
      public MainWindow()
      {
         // normal initialization
         InitializeComponent();
      
         this.Loaded += MainWindow_Loaded;
      }

      void MainWindow_Loaded(object sender, RoutedEventArgs e)
      {
         PresentIndicative pi = XMLLoader.Load<PresentIndicative>("PresentIndicative.xml");
         Adverbs adverbs = XMLLoader.Load<Adverbs>("Adverbs.xml");
         verbConjugationControl.DataContext = pi.VerbConjugations[0];
      }

   }
}
