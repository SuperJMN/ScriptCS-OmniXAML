#r "PresentationCore"
#r "PresentationFramework"
#r "WindowsBase"
#r "System.Xaml"
#r "System.Xml"
#r "System.Runtime"
#r "System.IO"
#r "System.Reflection"

#load utilities.csx
#load mvvm.csx
#load viewmodels.csx

using System.Windows;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using OmniXaml.Wpf;
using OmniXaml;
using System.Reflection;

public class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
	{
		Console.WriteLine("Setting up the thing!");

		var loader = new WpfXamlLoader();

		using (var stream = new FileStream("CalculatorView.xaml", FileMode.Open))
		{
			Console.WriteLine("XAML Parsing with OmniXAML now");
			var window = (Window) loader.Load(stream);
			Console.WriteLine("Done! Let's WPF do its job ;)");

			window.DataContext = new CalculatorViewModel();
			window.Show();
		}
	}
}

Utilities.RunInSTAThread(() => new App().Run());
