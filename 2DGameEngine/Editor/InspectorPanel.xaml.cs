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
        InspectorStackPanel.Children.Clear();
        InspectorStackPanel.Children.Add(new TextBlock { Text = "Name: GameObject 1" });
    }
}