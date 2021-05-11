using System.Windows.Controls;
using LetterKeyboardAndDemoNavigationManager.VM;
using ThirdPartTwo_Elements.ModelViews.BaseLib;

namespace LetterKeyboardAndDemoNavigationManager.Pages
{
	public partial class StartPage : Page
	{
		public StartPage(NavigationManager navigationManager)
		{
			InitializeComponent();
			DataContext = new StartPageViewModel(navigationManager);
		}
	}
}