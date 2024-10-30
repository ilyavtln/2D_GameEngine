using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2DGameEngine.GameEngine.Sprites.Default;

public class SquareSprite : Sprite
{
    // Размер квадрата
    public float Size { get; private set; }
        
    // Прямоугольник для визуализации квадрата
    private Rectangle _square;

    public SquareSprite(string name, float size = 16) : base(name, null, "LightGray")
    {
        Size = size;

        // Создание прямоугольника для представления квадрата
        _square = new Rectangle
        {
            Width = Size,
            Height = Size,
            Fill = new SolidColorBrush(Colors.LightGray) // Цвет квадрата
        };

        // Добавляем квадрат на canvas
        // Предположим, что у вас есть метод, который позволяет добавлять элементы на canvas
        // Вы можете вызвать его в базовом классе или передать canvas в конструктор
    }

    // Метод для изменения размера квадрата
    public void SetSize(float newSize)
    {
        Size = newSize;
        _square.Width = Size;
        _square.Height = Size;
    }

    // Метод для рендеринга квадрата на Canvas
    public void Render(Canvas canvas)
    {
       
        Canvas.SetLeft(_square, 0); // Положение по X
        Canvas.SetTop(_square, 0); // Положение по Y
        canvas.Children.Add(_square);
    }
}