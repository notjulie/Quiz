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
         buttonNext.Click += buttonNext_Click;
      }

      #endregion

      #region Event Handlers

      void buttonNext_Click(object sender, RoutedEventArgs e)
      {
         NextQuestion();
      }

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
                  buttonNext.IsEnabled = true;
                  buttonNext.Focus();
                  break;

               case TextEntryState.Correct:
                  buttonNext.IsEnabled = true;
                  buttonNext.Focus();
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
            NextQuestion();
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

         // disable the next button until they get it right
         buttonNext.IsEnabled = false;
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
               case "Phrase":
                  itemControl = new SimpleTranslationControl();
                  itemControl.DataContext = item;
                  break;

               case "Noun":
                  itemControl = new SimpleTranslationControl();
                  Noun noun = (Noun)item;
                  itemControl.DataContext = new { 
                     English = "the " + noun.English,
                     Italian = noun.TheItalian
                  };
                  break;

               case "VerbConjugation":
                  itemControl = new VerbConjugationControl();
                  itemControl.DataContext = item;
                  break;

               default:
                  throw new QuizException("unsupported item type: " + item.GetType().Name);
            }

            // install it
            IUserEntryControl userEntryControl = itemControl as IUserEntryControl;
            if (userEntryControl != null)
               userEntryControl.TextEntryStateChanged += this.itemTextEntryStateChanged;
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
