using System.Windows.Controls;
using System.Windows.Navigation;

namespace ThirdPartTwo_Elements.ModelViews.BaseLib
{
	public class NavigationManager
	{
		private readonly NavigationService _navigationService;

		public NavigationManager(NavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		private bool CanGoBack => _navigationService.CanGoBack;

		public void NavigateWithNavigationManager<TView, TViewModel>() where TView : Page, new()
			where TViewModel : BaseViewModelNavigation, new()
		{
			Page page = new TView();
			BaseViewModelNavigation viewModel = new TViewModel();
			viewModel.NavigationManager = this;
			page.DataContext = viewModel;
			_navigationService.Navigate(page);
		}

		public void GoBack()
		{
			if (!CanGoBack) return;
			_navigationService.GoBack();
		}

		#region Navigate

		public bool Navigate<TView>(BaseViewModel viewModel) where TView : Page, new()
		{
			Page page = new TView();
			page.DataContext = viewModel;
			_navigationService.Navigate(page);
			return true;
		}

		public bool NavigateWithNavigationManager<TView>(BaseViewModelNavigation viewModel) where TView : Page, new()
		{
			Page page = new TView();
			page.DataContext = viewModel;
			_navigationService.Navigate(page);
			return true;
		}

		public bool Navigate<TView, TViewModel>() where TView : Page, new() where TViewModel : BaseViewModel, new()
		{
			Page page = new TView();
			BaseViewModel viewModel = new TViewModel();
			page.DataContext = viewModel;
			_navigationService.Navigate(page);
			return true;
		}

		#endregion
	}
}