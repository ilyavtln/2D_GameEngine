using System.Windows;
using System.Windows.Controls;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Components
{
    public class SpriteRenderer : Component
    {
        public static readonly string ComponentName = "Sprite Renderer";
        public Image? Sprite { get; set; }

        public SpriteRenderer(Image? sprite) : base(ComponentName)
        {
            Sprite = sprite;
        }

        public override void Update()
        {
        }
    }
}