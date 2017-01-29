using System;
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

using Quiz.Controls;
using Quiz.XmlModel;

namespace Quiz
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      #region Constructor

      /// <summary>
      /// Initializes a new instance of class MainWindow
      /// </summary>
      public MainWindow()
      {
         // normal initialization
         InitializeComponent();
      
         this.Loaded += MainWindow_Loaded;
      }

      #endregion

      #region Event Handlers

      void MainWindow_Loaded(object sender, RoutedEventArgs e)
      {
         // load our language data
         PresentIndicative pi = XMLLoader.Load<PresentIndicative>("PresentIndicative.xml");
         Adverbs adverbs = XMLLoader.Load<Adverbs>("Adverbs.xml");

         // spew up the first adverb for now
         ShowItem(adverbs.AdverbList[0]);
      }

      #endregion

      #region Private Methods

      private void ShowItem(object item)
      {
         try
         {
            FrameworkElement itemControl;

            // create the child control according to the object type
            switch (item.GetType().Name)
            {
               case "Adverb":
                  itemControl = new SimpleTranslationControl();
                  break;

               default:
                  throw new Exception("MainWindow.ShowItem: unsupported item type: " + item.GetType().Name);
            }

            itemControl.DataContext = item;
            itemContainer.Content = itemControl;
         }
         catch (Exception e)
         {
            MessageBox.Show(e.Message);
         }
      }

      #endregion
   }
}
