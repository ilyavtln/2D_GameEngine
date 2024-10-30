using System.Numerics;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Components
{
    public class Camera : Component
    {
        public Vector2 Position { get; set; }

        public Camera() : base("Camera")
        {
            Position = new Vector2(0, 0);
        }

        public override void Update()
        {
            // Добавьте логику смещения или масштабирования для Canvas
        }
    }
}