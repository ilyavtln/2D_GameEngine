using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using _2DGameEngine.Editor.Dialogs;
using _2DGameEngine.GameEngine.Components;
using _2DGameEngine.GameEngine.Core;
using Transform = _2DGameEngine.GameEngine.Components.Transform;

namespace _2DGameEngine.Editor;

public partial class InspectorPanel : UserControl
{
    public InspectorPanel()
    {
        InitializeComponent();
    }
    
    public void DisplayObjectProperties(GameObject? selectedObject)
    {
        InspectorStackPanel.Children.Clear();

        if (selectedObject is null)
        {
            return;
        }

        // Отображение имени
        var nameTextBox = new TextBlock
        {
            Text = selectedObject.Name,
            FontSize = 18,
            FontWeight = FontWeights.Medium
        };

        var backgroundBorder = new Border
        {
            Background = Brushes.LightBlue,
            Padding = new Thickness(2),
            Child = nameTextBox
        };
        
        InspectorStackPanel.Children.Add(backgroundBorder);
        
        foreach (var component in selectedObject.Components)
        {
            var componentTree = new TreeViewItem
            {
                Header = component.GetType().Name,
                IsExpanded = true
            };
                
            var propertiesPanel = new StackPanel();

            if (component is Transform)
            {
                var transform = selectedObject.GetComponent<Transform>();
                
                if (transform is null) { continue; }
                
                // Позиция
                propertiesPanel.Children.Add(new TextBlock { Text = $"Position: X = {transform.Position.X}, Y = {transform.Position.Y}" });

                // Свойства масштаба
                propertiesPanel.Children.Add(new TextBlock { Text = $"Scale: X = {transform.Scale.X}, Y = {transform.Scale.Y}" });

                // Свойство вращения
                propertiesPanel.Children.Add(new TextBlock { Text = $"Rotation: {transform.Rotation}" });
            }
            else if (component is SpriteRenderer)
            {
                
            }
            
            // Добавляем свойства в Expander
            componentTree.Items.Add(propertiesPanel);

            // Добавляем Expander в инспектор
            InspectorStackPanel.Children.Add(componentTree);
        }

        // Кнопка для добавления нового компонента
        var addComponentButton = new Button { Content = "Add Component" };
        addComponentButton.Click += (s, e) => ShowAddComponentDialog(selectedObject);
        InspectorStackPanel.Children.Add(addComponentButton);
    }
    
    private void ShowAddComponentDialog(GameObject? selectedObject)
    {
        var dialog = new AddComponentDialog();
        if (dialog.ShowDialog() == true && selectedObject is not null)
        {
            var newComponent = dialog.SelectedComponent;
            selectedObject.AddComponent(newComponent);

            // Обновление отображения
            DisplayObjectProperties(selectedObject);
        }
    }
}