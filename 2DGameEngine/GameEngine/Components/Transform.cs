using _2DGameEngine.GameEngine.Core;
using System.Numerics;

namespace _2DGameEngine.GameEngine.Components;

/// <summary>
/// Класс, отвечающий за границы объекта для взаимодействия с физикой
/// </summary>
public class Transform : Component
{
    public static readonly string ComponentName = "Transform";
    public Vector2 Position { get; set; }
    public Vector2 Scale { get; set; }
    public float Rotation { get; set; }

    public Transform(float x = 0, float y = 0) : base(ComponentName)
    {
        Position = new Vector2(x, y);
        Scale = new Vector2(1.0f, 1.0f);
        Rotation = 0.0f;
    }
}
