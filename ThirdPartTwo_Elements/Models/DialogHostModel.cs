using System.ComponentModel;
using System.Runtime.CompilerServices;
using ThirdPartTwo_Elements.Annotations;

namespace ThirdPartTwo_Elements.Models
{
	public class DialogHostModel : INotifyPropertyChanged
	{
		private int _radius;
		private double _transparency;

		public int Radius
		{
			get => _radius;
			set
			{
				_radius = value;
				OnPropertyChanged(nameof(Radius));
			}
		}

		public double Transparency
		{
			get => _transparency;
			set
			{
				_transparency = value;
				OnPropertyChanged(nameof(Transparency));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}