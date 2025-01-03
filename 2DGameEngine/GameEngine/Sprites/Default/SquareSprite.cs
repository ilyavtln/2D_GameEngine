using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2DGameEngine.GameEngine.Sprites.Default;

public class SquareSprite : Sprite
{
    private static Image _squareImage = new Image
    {
        Source = new BitmapImage(new Uri("/Assets/Sprites/Square.png", UriKind.Relative))
    };
    
    public SquareSprite(string name) : base(name, _squareImage)
    {
    }
}