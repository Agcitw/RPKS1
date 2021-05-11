using System.Windows.Input;
using ThirdPartTwo_Elements.ModelViews.BaseLib;
using ThirdPartTwo_Elements.ModelViews.Commands;

namespace LetterKeyboardAndDemoNavigationManager.VM
{
	internal class LetterKeyboardPageViewModel : BaseViewModelNavigation
	{
		public ICommand BackCommand =>
			new RelayCommand(_ => NavigationManager.GoBack());
	}
}