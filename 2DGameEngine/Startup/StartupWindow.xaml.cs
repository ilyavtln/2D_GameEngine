using System.Windows;
using _2DGameEngine.Editor;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.Startup;

public partial class StartupWindow : Window
{
    private readonly Scene? _mainScene = new Scene("Main Scene");
    
    public StartupWindow()
    {
        InitializeComponent();
        Loaded += StartupWindow_Loaded;
    }
    
    private async void StartupWindow_Loaded(object sender, RoutedEventArgs e)
    {
        await LoadDependenciesAsync();
        
        var mainEditorWindow = new MainEditorWindow();
        mainEditorWindow.Show();
        
        Close();
    }

    /// <summary>
    /// Делаем вид, что что-то грузим
    /// </summary>
    private Task LoadDependenciesAsync()
    {
        return Task.Run(() =>
        {
            System.Threading.Thread.Sleep(500);
        });
    }
}