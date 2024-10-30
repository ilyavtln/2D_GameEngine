namespace _2DGameEngine.GameEngine.Core;

public abstract class Component
{
    public string Name { get; }
    public GameObject? GameObject { get; set; }
    
    protected Component(string name)
    {
        Name = name;
    }
    
    public virtual void Update() { }
}
