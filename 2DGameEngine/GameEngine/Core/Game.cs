namespace _2DGameEngine.GameEngine.Core;

public class Game
{
    private bool _isRunning;
    private Scene _currentScene;

    public void Run()
    {
        _isRunning = true;
        
        while (_isRunning)
        {
            Update();
            Render();
        }
    }

    private void Update()
    {
        _currentScene.Update();
    }

    private void Render()
    {
        
    }
}
