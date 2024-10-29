namespace _2DGameEngine.GameEngine.Core;

public class Scene
{
    public List<GameObject> GameObjects { get; private set; } = new List<GameObject>();

    public void AddGameObject(GameObject gameObject)
    {
        GameObjects.Add(gameObject);
    }

    public void Update()
    {
        foreach (var gameObject in GameObjects)
        {
            gameObject.Update();
        }
    }

    public void Render()
    {
        // Логика рендеринга объектов сцены
    }
}
