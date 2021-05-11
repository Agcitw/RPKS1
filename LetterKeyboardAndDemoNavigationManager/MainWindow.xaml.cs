using LetterKeyboardAndDemoNavigationManager.Pages;
using ThirdPartTwo_Elements.ModelViews.BaseLib;

namespace LetterKeyboardAndDemoNavigationManager
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			Frame.Content = new StartPage(new NavigationManager(Frame.NavigationService));
		}
	}
}