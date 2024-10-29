using System.Windows.Controls;
using System.IO;

namespace _2DGameEngine.Editor;

public partial class FileExplorerPanel : UserControl
{
    private string _projectRootPath;
    
    public FileExplorerPanel()
    {
        InitializeComponent();
        _projectRootPath = Path.Combine(Directory.GetCurrentDirectory(), "Assets");
        LoadDirectoryStructure();
    }
    
    private void LoadDirectoryStructure()
    {
        if (Directory.Exists(_projectRootPath))
        {
            LoadDirectory(RootFolder, _projectRootPath);
        }
    }

    private void LoadDirectory(TreeViewItem parentItem, string path)
    {
        // Добавляем папки
        foreach (var dir in Directory.GetDirectories(path))
        {
            var dirItem = new TreeViewItem { Header = Path.GetFileName(dir) };
            parentItem.Items.Add(dirItem);
            LoadDirectory(dirItem, dir); // Рекурсивно загружаем вложенные папки
        }

        // Добавляем файлы
        foreach (var file in Directory.GetFiles(path))
        {
            var fileItem = new TreeViewItem { Header = Path.GetFileName(file) };
            parentItem.Items.Add(fileItem);
        }
    }
}