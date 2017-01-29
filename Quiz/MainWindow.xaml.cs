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

      void itemTextEntryStateChanged(object sender, EventArgs e)
      {
         IUserEntryControl control = itemContainer.Content as IUserEntryControl;
         if (control != null)
         {
            switch (control.TextEntryState)
            {
               case TextEntryState.Unanswered:
                  break;

               case TextEntryState.Cheated:
                  NextQuestion();
                  break;

               case TextEntryState.Correct:
                  NextQuestion();
                  break;
            }
         }
      }

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

      private void NextQuestion()
      {
         // spew up a random item
         ShowItem(languageData.GetRandomItem());
      }

      private void ShowItem(object item)
      {
         try
         {
            // get rid of the previous item
            IUserEntryControl previousItem = itemContainer.Content as IUserEntryControl;
            if (previousItem != null)
               previousItem.TextEntryStateChanged -= itemTextEntryStateChanged;
            itemContainer.Content = null;

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
                  throw new QuizException("unsupported item type: " + item.GetType().Name);
            }

            // install it
            IUserEntryControl userEntryControl = itemControl as IUserEntryControl;
            if (userEntryControl != null)
               userEntryControl.TextEntryStateChanged += this.itemTextEntryStateChanged;
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
