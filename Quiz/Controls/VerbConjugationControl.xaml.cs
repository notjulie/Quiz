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

namespace Quiz.Controls
{
   /// <summary>
   /// Interaction logic for VerbConjugationControl.xaml
   /// </summary>
   public partial class VerbConjugationControl : UserControl, IUserEntryControl
   {
      private TextEntryState textEntryState = TextEntryState.Unanswered;

      /// <summary>
      /// Initializes a new instance of class VerbConjugationControl
      /// </summary>
      public VerbConjugationControl()
      {
         InitializeComponent();

         Loaded += VerbConjugationControl_Loaded;
         io.TextEntryStateChanged += textEntryStateChanged;
         tu.TextEntryStateChanged += textEntryStateChanged;
         lui.TextEntryStateChanged += textEntryStateChanged;
         noi.TextEntryStateChanged += textEntryStateChanged;
         voi.TextEntryStateChanged += textEntryStateChanged;
         loro.TextEntryStateChanged += textEntryStateChanged;
      }

      void textEntryStateChanged(object sender, EventArgs e)
      {
         this.TextEntryState = GetTextEntryState();
      }

      /// <summary>
      /// Event fired when the text entry state changes
      /// </summary>
      public event EventHandler<EventArgs> TextEntryStateChanged;

      /// <summary>
      /// Gets the text entry state
      /// </summary>
      public TextEntryState TextEntryState
      {
         get
         {
            return textEntryState;
         }
         private set
         {
            if (value != textEntryState)
            {
               textEntryState = value;
               if (TextEntryStateChanged != null)
                  TextEntryStateChanged(this, EventArgs.Empty);
            }
         }
      }

      void VerbConjugationControl_Loaded(object sender, RoutedEventArgs e)
      {
         MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
      }

      private TextEntryState GetTextEntryState()
      {
         bool anyCheated = false;

         foreach (TextEntry textEntry in new TextEntry[] { io, tu, lui, noi, voi, loro })
         {
            switch (textEntry.TextEntryState)
            {
               case TextEntryState.Unanswered:
                  return TextEntryState.Unanswered;

               case TextEntryState.Cheated:
                  anyCheated = true;
                  break;

               case TextEntryState.Correct:
                  break;
            }
         }

         if (anyCheated)
            return TextEntryState.Cheated;
         else
            return TextEntryState.Correct;
      }
   }
}
