using System.Windows.Controls;

namespace _2DGameEngine.GameEngine.Components;

public class SpriteRenderer : Component
{
    public Image Sprite { get; set; }

    public override void Update()
    {
        // Логика рендеринга спрайта, привязанного к GameObject
    }
}
