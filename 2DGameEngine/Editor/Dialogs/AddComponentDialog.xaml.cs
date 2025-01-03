using System.Windows;
using System.Windows.Controls;
using _2DGameEngine.GameEngine.Core;
using _2DGameEngine.GameEngine.Utils.classes;

namespace _2DGameEngine.Editor.Dialogs;

public partial class AddComponentDialog : Window
{
    public Component SelectedComponent { get; private set; }

    public AddComponentDialog()
    {
        Title = "Add Component";
        Width = 300;
        Height = 200;

        var stackPanel = new StackPanel();

        var componentList = new ComboBox();
        componentList.Items.Add("Rigidbody");
        componentList.Items.Add("Collider");
        componentList.Items.Add("SpriteRenderer");

        var addButton = new Button { Content = "Add" };
        addButton.Click += (s, e) =>
        {
            var selected = componentList.SelectedItem.ToString();
            if (selected != null) SelectedComponent = ComponentFactory.Create(selected);
            DialogResult = true;
            Close();
        };

        stackPanel.Children.Add(componentList);
        stackPanel.Children.Add(addButton);

        Content = stackPanel;
    }
}