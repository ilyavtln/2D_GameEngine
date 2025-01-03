using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Components;

/// <summary>
/// Класс, отвечающий за отрисовку спрайтов
/// </summary>
public class SpriteRenderer : Component
{
    public static readonly string ComponentName = "Sprite Renderer";
    public Image? SpriteImage { get; set; }
    public Color SpriteColor { get; set; }

    public SpriteRenderer(Image? sprite, Color? spriteColor = null) : base(ComponentName)
    {
        SpriteImage = sprite;
        SpriteColor = spriteColor ?? Color.White;
    }
    
    public void Render(Canvas canvas, Transform transform)
    {
        if (SpriteImage == null) return;

        Canvas.SetLeft(SpriteImage, transform.Position.X);
        Canvas.SetTop(SpriteImage, transform.Position.Y);

        if (!canvas.Children.Contains(SpriteImage))
        {
            canvas.Children.Add(SpriteImage);
        }
    }

    public override void Update()
    {
    }
}