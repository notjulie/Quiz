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
   public partial class VerbConjugationControl : UserControl
   {
      /// <summary>
      /// Initializes a new instance of class VerbConjugationControl
      /// </summary>
      public VerbConjugationControl()
      {
         InitializeComponent();

         Loaded += VerbConjugationControl_Loaded;
      }

      void VerbConjugationControl_Loaded(object sender, RoutedEventArgs e)
      {
         MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
      }
   }
}
