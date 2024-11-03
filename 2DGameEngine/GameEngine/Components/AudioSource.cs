using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Components
{
    public class AudioSource : Component
    {
        public static readonly string ComponentName = "Audio Source";
        
        public AudioSource() : base(ComponentName)
        {
        }
    }
}