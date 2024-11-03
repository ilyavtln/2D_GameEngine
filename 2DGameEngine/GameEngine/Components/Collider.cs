using System.Numerics;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Components;

public class Collider : Component
{
    public static readonly string ComponentName = "Collider";
        
    public Vector2 Size { get; set; }

    public Collider() : base(ComponentName)
    {
        Size = new Vector2(1, 1);
    }
}
