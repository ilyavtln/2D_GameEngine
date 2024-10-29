using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Components;

public abstract class Component
{
    public GameObject GameObject { get; set; }
    
    public virtual void Update() { }
}
