using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using _2DGameEngine.GameEngine.Components;
using _2DGameEngine.GameEngine.Core;
using _2DGameEngine.GameEngine.Sprites.Default;

namespace _2DGameEngine.Editor;

public partial class HierarchyPanel : UserControl
{
    private int _itemsConter = 1;
    
    public List<TreeViewItem> ChildItems { get; set; } = new List<TreeViewItem>();
    public Scene CurrentScene { get => GetCurrentScene(); }
    
    public HierarchyPanel()
    {
        InitializeComponent();
        LoadSceneObjects();
    }
    
    private Scene GetCurrentScene()
    {
        var mainEditorWindow = Window.GetWindow(this) as MainEditorWindow;
        return mainEditorWindow?.Scene;
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
    
    private void CreateEmpty_Click(object sender, RoutedEventArgs e)
    {
        var newObject = new GameObject("New Empty Object");
        AddGameObjectToHierarchy(newObject);
        CurrentScene?.AddGameObject(newObject);
    }

    private void CreateSpriteSquare_Click(object sender, RoutedEventArgs e)
    {
        var squareObject = new SquareSprite(_itemsConter.ToString());
        AddGameObjectToHierarchy(squareObject);
        CurrentScene.AddGameObject(squareObject);
        
        _itemsConter++;
    }

    private void CreateSpriteCircle_Click(object sender, RoutedEventArgs e)
    {
        var circleObject = CreateSpriteObject("New Circle Sprite", "circle.png"); // Предполагается, что есть ресурс circle.png
        AddGameObjectToHierarchy(circleObject);
        CurrentScene?.AddGameObject(circleObject);
    }

    private GameObject CreateSpriteObject(string name, string spritePath)
    {
        var spriteObject = new GameObject(name);
        var spriteRenderer = new SpriteRenderer(new Image
            { Source = new BitmapImage(new Uri(spritePath, UriKind.Relative)) });
        spriteObject.AddComponent(spriteRenderer);
        return spriteObject;
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