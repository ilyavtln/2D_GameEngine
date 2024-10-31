using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using _2DGameEngine.GameEngine.Components;
using _2DGameEngine.GameEngine.Core;
using _2DGameEngine.GameEngine.Sprites.Default;

namespace _2DGameEngine.Editor;

public partial class HierarchyPanel : UserControl
{
    private int _itemsCounter = 1;
    
    /// <summary>
    /// Корневой объект - сцена
    /// </summary>
    public TreeViewItem? RootItem;

    public Scene? CurrentScene
    {
        get => (Window.GetWindow(this) as MainEditorWindow)?.Scene;
    }
    
    public HierarchyPanel()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        LoadSceneObjects();
    }
    
    /// <summary>
    /// Получаем текущую сцену и отображаем ее объекты
    /// </summary>
    private void LoadSceneObjects()
    {
        RootItem = new TreeViewItem { Header = CurrentScene?.Name };
        HierarchyTreeView.Items.Add(RootItem);
    }
    
    private void CreateEmpty_Click(object sender, RoutedEventArgs e)
    {
        var emptyObject = new GameObject($"Empty Object {_itemsCounter++}");
        AddGameObjectToHierarchy(emptyObject);
        CurrentScene?.AddGameObject(emptyObject);
    }

    private void CreateSpriteSquare_Click(object sender, RoutedEventArgs e)
    {
        var squareObject = new SquareSprite(_itemsCounter.ToString());
        AddGameObjectToHierarchy(squareObject);
        CurrentScene.AddGameObject(squareObject);
    }

    private void CreateSpriteCircle_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    public void AddGameObjectToHierarchy(GameObject obj)
    {
        var gameObjectItem = new TreeViewItem { Header = obj.Name };
            
        // Проверим, есть ли уже корневой элемент (например, "Сцена 1")
        if (HierarchyTreeView.Items.Count == 0)
        {
            // Создаем корневой элемент для сцены, если он еще не добавлен
            var rootItem = new TreeViewItem { Header = "Сцена 5" };
            HierarchyTreeView.Items.Add(rootItem);
            rootItem.Items.Add(gameObjectItem);
        }
        else
        {
            // Добавляем объект в существующий корневой элемент
            var rootItem = (TreeViewItem)HierarchyTreeView.Items[0];
            rootItem.Items.Add(gameObjectItem);
        }
    }
}