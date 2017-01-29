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
   /// Interaction logic for TextEntry.xaml
   /// </summary>
   public partial class TextEntry : UserControl
   {
      #region Private Fields

      private static DependencyProperty ExpectedValueProperty = DependencyProperty.Register("ExpectedValue", typeof(string), typeof(TextEntry), new PropertyMetadata());

      private Brush correctBrush = new SolidColorBrush(Colors.Red);
      private Brush incorrectBrush = new SolidColorBrush(Colors.Black);
      private TextEntryState textEntryState = TextEntryState.Unanswered;

      #endregion

      #region Constructor

      /// <summary>
      /// Initializes a new instance of class TextEntry
      /// </summary>
      public TextEntry()
      {
         // normal initialization
         InitializeComponent();

         // add event handlers
         entryText.TextChanged += entryText_TextChanged;
         entryText.MouseDoubleClick += entryText_MouseDoubleClick;
      }

      #endregion

      #region Public Properties / Events

      /// <summary>
      /// Event fired when the TextEntryState property changes
      /// </summary>
      public event EventHandler<EventArgs> TextEntryStateChanged;

      /// <summary>
      /// Gets or sets the expected value
      /// </summary>
      public string ExpectedValue
      {
         get
         {
            return (string)GetValue(ExpectedValueProperty);
         }
         set
         {
            // set the propery value
            SetValue(ExpectedValueProperty, value);

            // this clears our state
            textEntryState = TextEntryState.Unanswered;

            // but then we need to check the state
            UpdateControl();
         }
      }

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

      /// <summary>
      /// Gets or sets the title string
      /// </summary>
      public string Title
      {
         get
         {
            return title.Content.ToString();
         }
         set
         {
            title.Content = value;
         }
      }

      #endregion

      #region Protected Methods

      /// <summary>
      /// Takes action when a dependency property changes
      /// </summary>
      /// <param name="e">details of the event</param>
      protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
      {
         if (e.Property == ExpectedValueProperty)
            UpdateControl();
         base.OnPropertyChanged(e);
      }

      #endregion

      #region Event Handlers

      void entryText_MouseDoubleClick(object sender, MouseButtonEventArgs e)
      {
         // if the answer is already correct, ignore this
         if (textEntryState == TextEntryState.Correct)
            return;

         // else cheat
         this.TextEntryState = TextEntryState.Cheated;
         entryText.Text = ExpectedValue;
      }

      void entryText_TextChanged(object sender, TextChangedEventArgs e)
      {
         UpdateControl();
      }

      #endregion

      #region Private Methods

      private void UpdateControl()
      {
         if (entryText.Text == ExpectedValue)
         {
            entryText.Foreground = correctBrush;
            if (textEntryState != TextEntryState.Cheated)
               this.TextEntryState = TextEntryState.Correct;
         }
         else
         {
            entryText.Foreground = incorrectBrush;
         }
      }

      #endregion
   }
}
