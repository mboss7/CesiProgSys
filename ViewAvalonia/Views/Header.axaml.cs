using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ViewAvalonia.Network;

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
    public static event EventHandler LanguageEvent;
    
    public HeaderViewModel()
    {
        Languages = new List<string>() { "English", "French" };
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
    
    private string _language = "English";
    public string Language
    {
        get => _language;
        set
        {
            if (_language != value)
            {
                _language = value;
                OnPropertyChanged("_languages");
                OnLanguagesChanges();
            }
        } 
    }

    public void OnLanguagesChanges()
    {
        LanguageEvent.Invoke(Language, EventArgs.Empty);
    }
    

}