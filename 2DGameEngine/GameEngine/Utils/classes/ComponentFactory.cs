using System.Windows.Controls;
using System.Windows.Media.Imaging;
using _2DGameEngine.GameEngine.Components;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Utils.classes;

public static class ComponentFactory
{
    private static Image squareImage = new Image
    {
        Width = 10,
        Height = 10,
        Source = new BitmapImage(new Uri("/Assets/sprites/Square.png", UriKind.Relative))
    };  
    
    public static Component Create(string componentName)
    {
        return componentName switch
        {
            "Rigidbody" => new Rigidbody(),
            "Collider" => new Collider(),
            "SpriteRenderer" => new SpriteRenderer(squareImage),
            _ => throw new ArgumentException("Unknown component")
        };
    }
}