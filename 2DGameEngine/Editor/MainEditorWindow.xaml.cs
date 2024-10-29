using System.Windows;

namespace _2DGameEngine.Editor;

public partial class MainEditorWindow : Window
{
    public MainEditorWindow()
    {
        InitializeComponent();
        SetupEventHandlers();
    }
    
    private void SetupEventHandlers()
    {
        // Пример связывания событий (в реальности можно добавить события для обновления инспектора)
        // Например, при выборе объекта в HierarchyPanel обновлять InspectorPanel.
    }
    
    private void NewProject_Click(object sender, RoutedEventArgs e)
    {
        // Логика для создания нового проекта
    }

    private void OpenProject_Click(object sender, RoutedEventArgs e)
    {
        // Логика для открытия проекта
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        // Логика для сохранения проекта
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void SaveAs_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Undo_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Redo_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Cut_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Copy_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Paste_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ImportPackage_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ExportPackage_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void CreateEmpty_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void CreateSprite_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddRigidbody_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddCollider_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddMeshRenderer_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddSpriteRenderer_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Build_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}