using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2DGameEngine.GameEngine.Sprites.Default;

public class SquareSprite : Sprite
{
    // Размер квадрата
    public float Size { get; private set; }
    
    private Image _squareImage;

    public SquareSprite(string name, float size = 16) : base(name, null, "LightGray")
    {
        Size = size;
        
        _squareImage = new Image
        {
            Width = Size,
            Height = Size,
            Source = new BitmapImage(new Uri("/Assets/sprites/Square.png", UriKind.Relative))
        };
        
        SpriteImage = _squareImage;
    }

    // Метод для изменения размера квадрата
    public void SetSize(float newSize)
    {
        Size = newSize;
        _squareImage.Width = Size;
        _squareImage.Height = Size;
    }

    // Метод для рендеринга квадрата на Canvas
    public void Render(Canvas canvas)
    {
       
        Canvas.SetLeft(_squareImage, 0); // Положение по X
        Canvas.SetTop(_squareImage, 0); // Положение по Y
        canvas.Children.Add(_squareImage);
    }
}