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

      #region Public Properties

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
            SetValue(ExpectedValueProperty, value);
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
            entryText.Foreground = correctBrush;
         else
            entryText.Foreground = incorrectBrush;
      }

      #endregion
   }
}
