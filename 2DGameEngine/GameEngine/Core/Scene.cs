using System.Windows.Controls;
using System.Windows.Shapes;
using _2DGameEngine.GameEngine.Components;

namespace _2DGameEngine.GameEngine.Core;

public class Scene
{
    public List<GameObject> GameObjects { get; private set; } = new List<GameObject>();
    public string Name { get; set; }
    
    public Scene(string name)
    {
        Name = name;
    }

    public event Action<GameObject>? GameObjectAdded;

    public void AddGameObject(GameObject gameObject)
    {
        GameObjects.Add(gameObject);
        GameObjectAdded?.Invoke(gameObject);
    }
    
    public GameObject? GetGameObjectByName(string? name)
    {
        return GameObjects.FirstOrDefault(obj => obj.Name == name);
    }

    public void Update()
    {
        foreach (var gameObject in GameObjects)
        {
            gameObject.Update();
        }
    }

    public void Render(Canvas canvas)
    {
        canvas.Children.Clear();

        foreach (var gameObject in GameObjects)
        {
            var transform = gameObject.GetComponent<Transform>();
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

            if (transform != null && spriteRenderer != null)
            {
                spriteRenderer.Render(canvas, transform);
            }
        }
    }
}
