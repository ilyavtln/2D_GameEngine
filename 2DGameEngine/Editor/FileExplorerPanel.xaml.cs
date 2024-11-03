using System.ComponentModel;
using System.Windows.Controls;
using System.IO;
using System.Windows.Input;

namespace _2DGameEngine.Editor;

public partial class FileExplorerPanel : UserControl, INotifyPropertyChanged
{
    private string? _currentDirectory;

    public string? CurrentDirectory
    {
        get => _currentDirectory;
        set
        {
            _currentDirectory = value;
            OnPropertyChanged(nameof(CurrentDirectory));
        }
    }

    public FileExplorerPanel()
    {
        InitializeComponent();
        DataContext = this;
        CurrentDirectory = Path.GetFullPath(Directory.GetCurrentDirectory());
    }

    private void FileTreeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (FileTreeView.SelectedItem is TreeViewItem selectedItem && selectedItem.Tag is string path && Directory.Exists(path))
        {
            CurrentDirectory = path;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}