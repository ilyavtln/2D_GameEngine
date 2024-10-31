using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
    }
}
