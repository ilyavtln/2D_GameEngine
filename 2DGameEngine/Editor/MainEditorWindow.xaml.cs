using System.Numerics;
using System.Windows;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.Editor;

public partial class MainEditorWindow : Window
{
    public Scene Scene = new Scene("Main Scene");
    private int _sceneIndex = 1;

    public MainEditorWindow()
    {
        InitializeComponent();
        SetupEventHandlers();
    }

    private void NewScene_Click(object sender, RoutedEventArgs e)
    {
        InitializeScene(_sceneIndex.ToString());
        _sceneIndex++;
    }
    
    private void InitializeScene(string sceneName)
    {
        Scene = new Scene(sceneName);
        SceneView.SetScene(Scene);
        Scene.GameObjectAdded += HierarchyPanel.AddGameObjectToHierarchy;
    }
    
    private void SetupEventHandlers()
    {
        
    }
    
    private void NewProject_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private void OpenProject_Click(object sender, RoutedEventArgs e)
    {

    }

    private void OpenScene_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {

    }

    private void SaveAs_Click(object sender, RoutedEventArgs e)
    {
    }

    private void Undo_Click(object sender, RoutedEventArgs e)
    { 
    }

    private void Redo_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Cut_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Copy_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Paste_Click(object sender, RoutedEventArgs e)
    {

    }

    private void ImportPackage_Click(object sender, RoutedEventArgs e)
    {

    }

    private void ExportPackage_Click(object sender, RoutedEventArgs e)
    {

    }

    private void CreateEmpty_Click(object sender, RoutedEventArgs e)
    {

    }

    private void CreateSprite_Click(object sender, RoutedEventArgs e)
    {

    }

    private void AddRigidbody_Click(object sender, RoutedEventArgs e)
    {

    }

    private void AddCollider_Click(object sender, RoutedEventArgs e)
    {

    }

    private void AddMeshRenderer_Click(object sender, RoutedEventArgs e)
    {

    }

    private void AddSpriteRenderer_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private void Build_Click(object sender, RoutedEventArgs e)
    {

    }
    
    /// <summary>
    /// Закрывает работающее приложение
    /// </summary>
    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}