using _2DGameEngine.GameEngine.Components;

namespace _2DGameEngine.GameEngine.Core;

public class GameObject
{
    public string Name { get; set; }
    public Transform Transform { get; set; }
    public List<Component> Components { get; private set; }

    public GameObject(string name)
    {
        Name = name;
        Transform = new Transform();
        Components = new List<Component>();
    }

    public void AddComponent(Component component)
    {
        Components.Add(component);
    }

    public T GetComponent<T>() where T : Component
    {
        return Components.OfType<T>().FirstOrDefault();
    }

    public void Update()
    {
        foreach (var component in Components)
        {
            component.Update();
        }
    }
}
