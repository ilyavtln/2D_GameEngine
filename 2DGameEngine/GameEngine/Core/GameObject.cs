using _2DGameEngine.GameEngine.Components;

namespace _2DGameEngine.GameEngine.Core;

/// <summary>
/// Класс, используемый для всех объектов в сцене
/// </summary>
public class GameObject
{
    // Название объекта
    public string Name { get; set; }
    
    // Список компонентов 
    public List<Component> Components { get; private set; }

    public GameObject(string name)
    {
        Name = name;
        Components = new List<Component>(){ new Transform() };
    }

    public void AddComponent(Component component)
    {
        Components.Add(component);
    }

    public T? GetComponent<T>() where T : Component
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
