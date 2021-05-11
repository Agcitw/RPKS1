using System.Windows;
using System.Windows.Input;
using ThirdPartTwo_Elements.Models;
using ThirdPartTwo_Elements.ModelViews.BaseLib;
using ThirdPartTwo_Elements.ModelViews.Commands;

namespace ThirdPartTwo_Elements.ModelViews
{
	public sealed class DialogHostViewModel : BaseViewModel
	{
		private static DialogHostModel _dialogHostModel = new();
		private RelayCommand _openDialogCommand;

		public DialogHostViewModel()
		{
			_dialogHostModel.Radius = 60;
			_dialogHostModel.Transparency = 0.4;
		}

		public DialogHostModel DialogHostModel
		{
			get => _dialogHostModel;
			set
			{
				_dialogHostModel = value;
				OnPropertyChanged(nameof(DialogHostModel));
			}
		}

		public ICommand OnRadUp =>
			new RelayCommand(_ => _dialogHostModel.Radius += 10, o => _dialogHostModel.Radius < 300);

		public ICommand OnRadDown =>
			new RelayCommand(_ => _dialogHostModel.Radius -= 10, o => _dialogHostModel.Radius > 0);

		public ICommand OnTrUp =>
			new RelayCommand(_ => _dialogHostModel.Transparency += 0.1, o => _dialogHostModel.Transparency < 0.99999);

		public ICommand OnTrDown =>
			new RelayCommand(_ => _dialogHostModel.Transparency -= 0.1, o => _dialogHostModel.Transparency > 0.10001);

		public RelayCommand OpenDialogCommand
		{
			set
			{
				_openDialogCommand = value;
				OnPropertyChanged(nameof(OpenDialogCommand));
			}
			get { return new(obj => { MessageBox.Show("COMMAND"); }); }
		}
	}
}