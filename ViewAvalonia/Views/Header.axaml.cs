using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ViewAvalonia.Views;

public class Header : UserControl
{
    public Header()
    {
        AvaloniaXamlLoader.Load(this); 
        DataContext = new HeaderViewModel();
    }
}

public sealed class HeaderViewModel : ViewModel
{
    public HeaderViewModel()
    {
        Languages = new List<string>() { "English", "French", "Spanish" };
    }

    private List<string> _languages;
    public List<string> Languages
    {
        get => _languages;
        set
        {
            if (_languages != value)
            {
                _languages = value;
                OnPropertyChanged("_languages");
            }
        } 
    }
    

}