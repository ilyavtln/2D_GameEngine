using System.Windows.Input;

namespace _2DGameEngine.GameEngine.Systems;

public class InputSystem
{
    public bool IsKeyPressed(Key key)
    {
        return Keyboard.IsKeyDown(key);
    }
}
