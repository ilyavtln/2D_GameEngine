using System.Windows.Controls;

namespace _2DGameEngine.Editor;

public partial class InspectorPanel : UserControl
{
    public InspectorPanel()
    {
        InitializeComponent();
    }
    
    public void DisplayObjectProperties(object selectedObject)
    {
        // Очистить панель и загрузить свойства выбранного объекта
        InspectorStackPanel.Children.Clear();
        // Пример: добавить свойства объекта
        InspectorStackPanel.Children.Add(new TextBlock { Text = "Name: GameObject 1" });
    }
}