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
      static DependencyProperty ExpectedValueProperty = DependencyProperty.Register("ExpectedValue", typeof(string), typeof(TextEntry), new PropertyMetadata());

      private Brush correctBrush = new SolidColorBrush(Colors.Red);
      private Brush incorrectBrush = new SolidColorBrush(Colors.Black);

      public TextEntry()
      {
         // normal initialization
         InitializeComponent();

         // add event handlers
         entryText.TextChanged += entryText_TextChanged;
         entryText.MouseDoubleClick += entryText_MouseDoubleClick;
      }

      void entryText_MouseDoubleClick(object sender, MouseButtonEventArgs e)
      {
         entryText.Text = ExpectedValue;
      }

      protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
      {
         if (e.Property == ExpectedValueProperty)
            UpdateControl();
         base.OnPropertyChanged(e);
      }

      void entryText_TextChanged(object sender, TextChangedEventArgs e)
      {
         UpdateControl();
      }

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

      private void UpdateControl()
      {
         if (entryText.Text == ExpectedValue)
            entryText.Foreground = correctBrush;
         else
            entryText.Foreground = incorrectBrush;
      }
   }
}
