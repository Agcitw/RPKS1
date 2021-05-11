using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LetterKeyboardAndDemoNavigationManager.Controls
{
	public partial class LetterKeyboard : UserControl
	{
		private readonly char[] _englishAlphabet = 
		{ 
			'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p',
			'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l',
			'z', 'x', 'c', 'v', 'b', 'n', 'm', 
		};

		private readonly char[] _russianAlphabet =
		{
			'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ',
			'ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л', 'д', 'ж', 'э',
			'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю', 'ё'
		};

		private bool _isEnglishChosen;

		public LetterKeyboard()
		{
			InitializeComponent();
			Loaded += InitLetters;
			var commandBindingLang = new CommandBinding(ApplicationCommands.Replace);
			commandBindingLang.Executed += SwitchLanguage;
			CommandBindings.Add(commandBindingLang);
		}

		private void SwitchLanguage(object sender, RoutedEventArgs args)
		{
			_isEnglishChosen = !_isEnglishChosen;
			InitLetters(sender, args);
		}

		private void CapsClicked(object sender, RoutedEventArgs e)
		{
			IsCapsChecked = !IsCapsChecked;
			InitLetters(sender, e);
		}

		private void InitLetters(object sender, RoutedEventArgs args)
		{
			var alphabet = _isEnglishChosen ? _englishAlphabet : _russianAlphabet;
			var buttons0 = new List<Button>();
			var buttons1 = new List<Button>();
			var buttons2 = new List<Button>();

			for (var i = 0; i < alphabet.Length; i++)
			{
				var button = new Button
				{
					Content = IsCapsChecked ? char.ToUpper(alphabet[i]) : alphabet[i],
					Style = LettersStyle,
					Height = 30,
					Width = 40,
					FontSize = 12,
					Command = LettersCommand
				};

				if (_isEnglishChosen)
					switch (i)
					{
						case < 10:
							buttons0.Add(button);
							break;
						case < 19:
							buttons1.Add(button);
							break;
						default:
							buttons2.Add(button);
							break;
					}
				else
					switch (i)
					{
						case < 12:
							buttons0.Add(button);
							break;
						case < 23:
							buttons1.Add(button);
							break;
						default:
							buttons2.Add(button);
							break;
					}
			}

			Items0.ItemsSource = buttons0;
			Items1.ItemsSource = buttons1;
			Items2.ItemsSource = buttons2;
		}

		#region DPs

		public static readonly DependencyProperty IsCapsCheckedProperty = DependencyProperty.Register(
			nameof(IsCapsChecked), typeof(bool), typeof(LetterKeyboard), new PropertyMetadata(false));

		public static readonly DependencyProperty LettersStyleProperty = DependencyProperty.Register(
			nameof(LettersStyle), typeof(Style), typeof(LetterKeyboard));

		public static readonly DependencyProperty CapsOnStyleProperty = DependencyProperty.Register(
			nameof(CapsOnStyle), typeof(Style), typeof(LetterKeyboard));

		public static readonly DependencyProperty CapsOffStyleProperty = DependencyProperty.Register(
			nameof(CapsOffStyle), typeof(Style), typeof(LetterKeyboard));

		public static readonly DependencyProperty EnterStyleProperty = DependencyProperty.Register(
			nameof(EnterStyle), typeof(Style), typeof(LetterKeyboard));

		public static readonly DependencyProperty CStyleProperty = DependencyProperty.Register(
			nameof(CStyle), typeof(Style), typeof(LetterKeyboard));

		public static readonly DependencyProperty LettersCommandProperty = DependencyProperty.Register(
			nameof(LettersCommand), typeof(ICommand), typeof(LetterKeyboard));

		public static readonly DependencyProperty EnterCommandProperty = DependencyProperty.Register(
			nameof(EnterCommand), typeof(ICommand), typeof(LetterKeyboard));

		public static readonly DependencyProperty CCommandProperty = DependencyProperty.Register(
			nameof(CCommand), typeof(ICommand), typeof(LetterKeyboard));

		public bool IsCapsChecked
		{
			get => (bool) GetValue(IsCapsCheckedProperty);
			set => SetValue(IsCapsCheckedProperty, value);
		}

		public Style LettersStyle
		{
			get => (Style) GetValue(LettersStyleProperty);
			set => SetValue(LettersStyleProperty, value);
		}

		public Style CapsOnStyle
		{
			get => (Style) GetValue(CapsOnStyleProperty);
			set => SetValue(CapsOnStyleProperty, value);
		}

		public Style CapsOffStyle
		{
			get => (Style) GetValue(CapsOffStyleProperty);
			set => SetValue(CapsOffStyleProperty, value);
		}

		public Style EnterStyle
		{
			get => (Style) GetValue(EnterStyleProperty);
			set => SetValue(EnterStyleProperty, value);
		}

		public Style CStyle
		{
			get => (Style) GetValue(CStyleProperty);
			set => SetValue(CStyleProperty, value);
		}

		public ICommand LettersCommand
		{
			get => (ICommand) GetValue(LettersCommandProperty);
			set => SetValue(LettersCommandProperty, value);
		}

		public ICommand EnterCommand
		{
			get => (ICommand) GetValue(EnterCommandProperty);
			set => SetValue(EnterCommandProperty, value);
		}

		public ICommand CCommand
		{
			get => (ICommand) GetValue(CCommandProperty);
			set => SetValue(CCommandProperty, value);
		}

		#endregion
	}
}