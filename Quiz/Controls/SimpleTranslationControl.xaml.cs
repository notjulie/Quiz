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
   /// Interaction logic for SimpleTranslationControl.xaml
   /// </summary>
   public partial class SimpleTranslationControl : UserControl, IUserEntryControl
   {
      /// <summary>
      /// Initializes a new instance of class SimpleTranslationControl
      /// </summary>
      public SimpleTranslationControl()
      {
         InitializeComponent();

         Loaded += SimpleTranslationControl_Loaded;
         textEntry.TextEntryStateChanged += textEntry_TextEntryStateChanged;
      }

      void textEntry_TextEntryStateChanged(object sender, EventArgs e)
      {
         if (TextEntryStateChanged != null)
            TextEntryStateChanged(this, EventArgs.Empty);
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
            return textEntry.TextEntryState;
         }
      }

      void SimpleTranslationControl_Loaded(object sender, RoutedEventArgs e)
      {
         MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
      }
   }
}
