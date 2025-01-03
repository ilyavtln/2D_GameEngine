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

    public Scene? CurrentScene => (Window.GetWindow(this) as MainEditorWindow)?.Scene;
    public Canvas SceneCanvas => (Window.GetWindow(this) as MainEditorWindow)!.SceneCanvas;


    public TreeViewItem? RootItem;
    
    public HierarchyPanel()
    {
        InitializeComponent();
        Loaded += OnLoaded;
        HierarchyTreeView.SelectedItemChanged += HierarchyTreeView_SelectedItemChanged;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        LoadSceneObjects();
    }
    
    private void LoadSceneObjects()
    {
        RootItem = new TreeViewItem { Header = CurrentScene?.Name, IsExpanded = true };
        HierarchyTreeView.Items.Add(RootItem);
    }
    
    private void CreateEmpty_Click(object sender, RoutedEventArgs e)
    {
        var emptyObject = new GameObject($"Empty {_itemsCounter++}");
        AddGameObjectToHierarchy(emptyObject);
        CurrentScene?.AddGameObject(emptyObject);
    }

    private void CreateSpriteSquare_Click(object sender, RoutedEventArgs e)
    {
        var squareObject = new SquareSprite($"Square {_itemsCounter++}");
        squareObject.Render(SceneCanvas);
        AddGameObjectToHierarchy(squareObject);
        CurrentScene?.AddGameObject(squareObject);
    }

    private void CreateSpriteCircle_Click(object sender, RoutedEventArgs e)
    {
        var circleObject = new CircleSprite($"Circle {_itemsCounter++}");
        circleObject.Render(SceneCanvas);
        AddGameObjectToHierarchy(circleObject);
        CurrentScene?.AddGameObject(circleObject);
    }
    
    private void CreateSpriteTriangle_Click(object sender, RoutedEventArgs e)
    {
        var triangleObject = new TriangleSprite($"Triangle {_itemsCounter++}");
        triangleObject.Render(SceneCanvas);
        AddGameObjectToHierarchy(triangleObject);
        CurrentScene?.AddGameObject(triangleObject);
    }
    
    private void CreateCamera_Click(object sender, RoutedEventArgs e)
    {
        var cameraObject = new GameObject($"Camera {_itemsCounter++}");
        var camera = new Camera();
        cameraObject.AddComponent(camera);
        AddGameObjectToHierarchy(cameraObject);
        CurrentScene?.AddGameObject(cameraObject);
    }

    public void AddGameObjectToHierarchy(GameObject obj)
    {
        var gameObjectItem = new TreeViewItem { Header = obj.Name };
        RootItem?.Items.Add(gameObjectItem);
    }
    
    private void HierarchyTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (e.NewValue is TreeViewItem selectedItem && CurrentScene != null)
        {
            var selectedObject = CurrentScene.GetGameObjectByName(selectedItem.Header.ToString());
            var inspector = (Window.GetWindow(this) as MainEditorWindow)?.InspectorPanel;
            inspector?.DisplayObjectProperties(selectedObject);
        }
    }
}