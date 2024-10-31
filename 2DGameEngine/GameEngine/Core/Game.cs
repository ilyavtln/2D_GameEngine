namespace _2DGameEngine.GameEngine.Core;

public class Game
{
    private bool _isRunning;
    private Scene _currentScene;

    public Game(Scene currentScene)
    {
        _currentScene = currentScene;
    }

    public async void Run()
    {
        _isRunning = true;
        
        while (_isRunning)
        {
            Update();
            Render();
        }
    }

    public void Stop()
    {
        _isRunning = false;
    }

    private void Update()
    {
        _currentScene.Update();
    }

    private void Render()
    { 
        throw new NotImplementedException();
    }
}
