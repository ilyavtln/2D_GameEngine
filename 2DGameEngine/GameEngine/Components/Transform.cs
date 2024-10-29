using System.Numerics;

namespace _2DGameEngine.GameEngine.Components;

public class Transform : Component
{
    public Vector2 Position { get; set; }
    public Vector2 Scale { get; set; } = new Vector2(1, 1);
    public float Rotation { get; set; }

    public Transform()
    {
        Position = new Vector2(0, 0);
    }
}
