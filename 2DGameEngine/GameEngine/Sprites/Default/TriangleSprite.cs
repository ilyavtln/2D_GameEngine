using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace _2DGameEngine.GameEngine.Sprites.Default;

public class TriangleSprite : Sprite
{
    private static Image _triangleImage = new Image
    {
        Source = new BitmapImage(new Uri("/Assets/Sprites/Triangle.png", UriKind.Relative))
    };
    
    public TriangleSprite(string name) : base(name, _triangleImage)
    {
    }
}