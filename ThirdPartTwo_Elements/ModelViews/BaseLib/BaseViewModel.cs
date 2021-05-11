using System.ComponentModel;
using System.Runtime.CompilerServices;
using ThirdPartTwo_Elements.Annotations;

namespace ThirdPartTwo_Elements.ModelViews.BaseLib
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		[NotifyPropertyChangedInvocator]
		protected void OnPropertiesChanged(params string[] propertyNames)
		{
			foreach (var propName in propertyNames)
				OnPropertyChanged(propName);
		}
	}
}