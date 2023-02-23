using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ViewAvalonia.Views;

public class Footer : UserControl
{
    public Footer()
    {
        AvaloniaXamlLoader.Load(this);
        DataContext = new FooterViewModel();
    }
}

public sealed class FooterViewModel : ViewModel
{
    public FooterViewModel()
    {
        
    }
    public void ClickExit()
    {
    }
} 