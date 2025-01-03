using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2DGameEngine.GameEngine.Sprites.Default;

public class CircleSprite : Sprite
{
    private static Image _circleImage = new Image
    {
        Source = new BitmapImage(new Uri("/Assets/Sprites/Circle.png", UriKind.Relative))
    };
    
    public CircleSprite(string name) : base(name, _circleImage)
    {
    }
}