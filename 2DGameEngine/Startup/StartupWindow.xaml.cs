using System.Windows;
using _2DGameEngine.Editor;

namespace _2DGameEngine.Startup;

public partial class StartupWindow : Window
{
    public StartupWindow()
    {
        InitializeComponent();
        Loaded += StartupWindow_Loaded;
    }
    
    private async void StartupWindow_Loaded(object sender, RoutedEventArgs e)
    {
        // Выполняем загрузку зависимостей асинхронно
        await LoadDependenciesAsync();

        // После завершения загрузки открываем главное окно редактора
        var mainEditorWindow = new MainEditorWindow();
        mainEditorWindow.Show();

        // Закрываем окно загрузки
        Close();
    }

    private Task LoadDependenciesAsync()
    {
        return Task.Run(() =>
        {
            System.Threading.Thread.Sleep(500);
        });
    }
}