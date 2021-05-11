using System.Windows.Input;
using LetterKeyboardAndDemoNavigationManager.Pages;
using ThirdPartTwo_Elements.ModelViews.BaseLib;
using ThirdPartTwo_Elements.ModelViews.Commands;

namespace LetterKeyboardAndDemoNavigationManager.VM
{
	public class StartPageViewModel : BaseViewModel
	{
		private readonly NavigationManager _navigationManager;

		public StartPageViewModel(NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
		}

		public ICommand LetterKeyboardCommand =>
			new RelayCommand(_ => GoToLetterKeyboard());

		private void GoToLetterKeyboard()
		{
			_navigationManager.NavigateWithNavigationManager<LetterKeyboardPage, LetterKeyboardPageViewModel>();
		}
	}
}