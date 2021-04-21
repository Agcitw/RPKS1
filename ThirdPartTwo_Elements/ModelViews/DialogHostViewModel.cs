using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ThirdPartTwo_Elements.Annotations;
using ThirdPartTwo_Elements.Models;
using ThirdPartTwo_Elements.ModelViews.Commands;

namespace ThirdPartTwo_Elements.ModelViews
{
    public sealed class DialogHostViewModel : INotifyPropertyChanged
    {
        private RelayCommand _openDialogCommand;
        private DialogHostModel _dialogHostModel = new DialogHostModel();

        public DialogHostViewModel()
        {
            _dialogHostModel.Radius = 0;
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
            get
            {
                return new RelayCommand(obj =>
                {
                    switch (new Random().Next(1, 4))
                    {
                        case 1:
                            MessageBox.Show("COMMAND1");
                            break;
                        case 2:
                            MessageBox.Show("COMMAND2");
                            break;
                        case 3:
                            MessageBox.Show("COMMAND3");
                            break;
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}