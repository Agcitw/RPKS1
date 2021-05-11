using System.Windows.Controls;
using LetterKeyboardAndDemoNavigationManager.VM;

namespace LetterKeyboardAndDemoNavigationManager.Pages
{
	public partial class LetterKeyboardPage : Page
	{
		public LetterKeyboardPage()
		{
			InitializeComponent();
			DataContext = new LetterKeyboardPageViewModel();
		}
	}
}