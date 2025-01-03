using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Components;

public class Rigidbody : Component
{
    public static readonly string ComponentName = "Rigidbody";
    
    public double? Mass { get; set; }
    
    public Rigidbody() : base(ComponentName)
    {
    }
}