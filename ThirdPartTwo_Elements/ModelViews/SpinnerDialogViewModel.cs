using System.Windows.Input;
using ThirdPartTwo_Elements.Models;
using ThirdPartTwo_Elements.ModelViews.BaseLib;
using ThirdPartTwo_Elements.ModelViews.Commands;

namespace ThirdPartTwo_Elements.ModelViews
{
	public sealed class SpinnerDialogViewModel : BaseViewModel
	{
		private static SpinnerDialogModel _spinnerDialogModel = new SpinnerDialogModel("Please, wait...", 10);

		public SpinnerDialogModel SpinnerDialogModel
		{
			get => _spinnerDialogModel;
			set
			{
				OnPropertyChanged(nameof(SpinnerDialogModel));
				_spinnerDialogModel = value;
			}
		}

		public ICommand OnTextSizeUp =>
			new RelayCommand(_ => _spinnerDialogModel.FontSize++, _ => _spinnerDialogModel.FontSize < 30);
		public ICommand OnTextSizeDown =>
			new RelayCommand(_ => _spinnerDialogModel.FontSize--, _ => _spinnerDialogModel.FontSize > 1);
		public ICommand OnTextChanged =>
			new RelayCommand(str => _spinnerDialogModel.Text = str as string);
	}
}