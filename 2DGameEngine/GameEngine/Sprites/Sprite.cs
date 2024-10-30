using System.Windows.Controls;
using _2DGameEngine.GameEngine.Components;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Sprites;

public class Sprite : GameObject
{
    public Image? SpriteImage { get; set; }
    public string Color { get; set; }

    public Sprite(string name, Image? spriteImage, string color) : base(name)
    {
        SpriteImage = spriteImage;
        Color = color;
        AddComponent(new SpriteRenderer(SpriteImage));
    }
}