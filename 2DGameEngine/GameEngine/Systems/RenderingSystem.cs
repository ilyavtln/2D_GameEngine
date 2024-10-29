using _2DGameEngine.GameEngine.Components;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Systems;

public class RenderingSystem
{
    public void Render(Scene scene)
    {
        foreach (var gameObject in scene.GameObjects)
        {
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Логика рендеринга спрайта
            }
        }
    }
}
