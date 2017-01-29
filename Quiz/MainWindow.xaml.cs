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
      #region Private Fields

      private LanguageData languageData = null;

      #endregion

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
         try
         {
            // load our language data
            languageData = new LanguageData();

            // spew up a random item
            ShowItem(languageData.GetRandomItem());
         }
         catch (Exception x)
         {
            MessageBox.Show(x.Message);
            Close();
         }
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

               case "VerbConjugation":
                  itemControl = new VerbConjugationControl();
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
