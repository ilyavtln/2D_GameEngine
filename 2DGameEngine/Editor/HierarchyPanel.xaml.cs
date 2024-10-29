using System.Windows.Controls;

namespace _2DGameEngine.Editor;

public partial class HierarchyPanel : UserControl
{
    public List<TreeViewItem> ChildItems { get; set; } = new List<TreeViewItem>();
    
    public HierarchyPanel()
    {
        InitializeComponent();
        LoadSceneObjects();
    }
    
    private void LoadSceneObjects()
    {
        // Здесь можно загрузить объекты из текущей сцены и отобразить их
        // В этом примере добавим тестовые объекты в дерево.
        var rootItem = new TreeViewItem { Header = "Сцена 1" };
        
        // Инициализация списка дочерних элементов
        ChildItems.Add(new TreeViewItem { Header = "Объект 1" });
        ChildItems.Add(new TreeViewItem { Header = "Объект 2" });
        ChildItems.Add(new TreeViewItem { Header = "Объект 3" });

        // Добавляем дочерние элементы в корень
        foreach (var childItem in ChildItems)
        {
            rootItem.Items.Add(childItem);
        }

        // Добавляем корневой элемент в дерево
        HierarchyTreeView.Items.Add(rootItem);
    }
}