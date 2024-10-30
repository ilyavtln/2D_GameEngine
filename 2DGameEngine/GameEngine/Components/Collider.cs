using System.Numerics;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Components
{
    public class Collider : Component
    {
        public Vector2 Size { get; set; }

        public Collider() : base("Collider")
        {
            Size = new Vector2(1, 1);
        }

        public override void Update()
        {
            // В дальнейшем можно добавить логику столкновений
        }
    }
}
