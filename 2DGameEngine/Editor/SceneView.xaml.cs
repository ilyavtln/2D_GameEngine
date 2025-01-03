using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using _2DGameEngine.GameEngine.Core;
using _2DGameEngine.GameEngine.Utils.Enums;

namespace _2DGameEngine.Editor;

public partial class SceneView : UserControl
{
    private Scene? _scene;
    
    private double _zoomScale = 1.0;
    private readonly double _maxScale = 40.0;
    private readonly double _minScale = 1.0;
    
    private SceneTools CurrentTool
    {
        get => (Window.GetWindow(this) as MainEditorWindow)?.SceneTools ?? SceneTools.View;
        set
        {
            if (Window.GetWindow(this) is not MainEditorWindow mainWindow) return;
            mainWindow.SceneTools = value;
            UpdateToolsButtons(CurrentTool);
        }
    }

    private GameState CurrentGameState
    {
        get => (Window.GetWindow(this) as MainEditorWindow)?.GameState ?? GameState.Stopped;
        set
        {
            if (Window.GetWindow(this) is not MainEditorWindow mainWindow) return;
            mainWindow.GameState = value;
            UpdatePlayButtons(value);
        }
    }


    private DispatcherTimer? _gameLoopTimer;
    
    public Canvas SceneCanvasControl => SceneCanvas;
    
    public SceneView()
    {
        InitializeComponent();
        UpdatePlayButtons(CurrentGameState);
        UpdateToolsButtons(CurrentTool);
        Loaded += (s, e) => DrawGrid();
        SceneCanvas.SizeChanged += (s, e) => DrawGrid();
        InitializeGameLoop();
    }
    
    private void InitializeGameLoop()
    {
        _gameLoopTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(16)
        };
        _gameLoopTimer.Tick += GameLoop_Tick;
    }
    
    private void GameLoop_Tick(object? sender, EventArgs e)
    {
        UpdateGame();
    }
    
    private void UpdateGame()
    {

    }
    
    private void ResetGameState()
    {
        // Сбросить состояние игры
    }
    
    public void SetScene(Scene? scene)
    {
        _scene = scene;
        if (_scene != null) _scene.GameObjectAdded += OnGameObjectAdded;
    }

    private void OnGameObjectAdded(GameObject gameObject)
    {
        if (_scene == null) return;

        _scene.Render(SceneCanvas);
    }
    
    private void SceneCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        Point mousePosition = e.GetPosition(SceneCanvas);
        
        double zoomFactor = (e.Delta > 0) ? 1.1 : 0.9;
        double newZoomScale = _zoomScale * zoomFactor;
        
        if (newZoomScale > _maxScale || newZoomScale < _minScale) return;

        _zoomScale = newZoomScale;
        
        ZoomTransform.CenterX = mousePosition.X;
        ZoomTransform.CenterY = mousePosition.Y;
        
        ZoomTransform.ScaleX = _zoomScale;
        ZoomTransform.ScaleY = _zoomScale;
    }

    
    private void DrawGrid(double cellSize = 16)
    {
        SceneCanvas.Children.Clear();

        double width = SceneCanvas.ActualWidth;
        double height = SceneCanvas.ActualHeight;

        for (double x = 0; x < width; x += cellSize)
        {
            var verticalLine = new Line
            {
                X1 = x,
                Y1 = 0,
                X2 = x,
                Y2 = height,
                Stroke = new SolidColorBrush(Colors.Gray),
                StrokeThickness = 0.5
            };
            SceneCanvas.Children.Add(verticalLine);
        }

        for (double y = 0; y < height; y += cellSize)
        {
            var horizontalLine = new Line
            {
                X1 = 0,
                Y1 = y,
                X2 = width,
                Y2 = y,
                Stroke = new SolidColorBrush(Colors.Gray),
                StrokeThickness = 0.5
            };
            SceneCanvas.Children.Add(horizontalLine);
        }
    }


    private void PlayButton_Click(object sender, RoutedEventArgs e)
    {
        if (CurrentGameState != GameState.Playing)
        {
            CurrentGameState = GameState.Playing;
            _gameLoopTimer?.Start();
            MessageBox.Show("Game Started!");
        }
    }
    
    private void PauseButton_Click(object sender, RoutedEventArgs e)
    {
        if (CurrentGameState != GameState.Paused && CurrentGameState != GameState.Stopped)
        {
            CurrentGameState = GameState.Paused;
            _gameLoopTimer?.Stop();
            MessageBox.Show("Game Paused!");
        }
    }
    
    private void StopButton_Click(object sender, RoutedEventArgs e)
    {
        if (CurrentGameState != GameState.Paused && CurrentGameState != GameState.Stopped)
        {
            CurrentGameState = GameState.Stopped;
            _gameLoopTimer?.Stop();
            MessageBox.Show("Game Stopped!");
            ResetGameState();
        }
    }
    
    private void UpdatePlayButtons(GameState state)
    {
        PlayButton.Background = new SolidColorBrush(Colors.White);
        PauseButton.Background = new SolidColorBrush(Colors.White);
        StopButton.Background = new SolidColorBrush(Colors.White);
        
        switch (state)
        {
            case GameState.Playing:
                PlayButton.Background = new SolidColorBrush(Colors.LightGreen);
                break;
            case GameState.Paused:
                PauseButton.Background = new SolidColorBrush(Colors.LightSalmon);
                break;
            case GameState.Stopped:
                StopButton.Background = new SolidColorBrush(Colors.LightCoral);
                break;
        }
    }
    
    private void RotateButton_Click(object sender, RoutedEventArgs e)
    {
        CurrentTool = SceneTools.Rotate;
    }

    private void ViewButton_Click(object sender, RoutedEventArgs e)
    {
        CurrentTool = SceneTools.View;
    }

    private void MoveButton_Click(object sender, RoutedEventArgs e)
    {
        CurrentTool = SceneTools.Move;
    }

    private void ScaleButton_Click(object sender, RoutedEventArgs e)
    {
        CurrentTool = SceneTools.Scale;
    }
    
    private void UpdateToolsButtons(SceneTools tools)
    {
        ViewButton.Background = new SolidColorBrush(Colors.White);
        MoveButton.Background = new SolidColorBrush(Colors.White);
        RotateButton.Background = new SolidColorBrush(Colors.White);
        ScaleButton.Background = new SolidColorBrush(Colors.White);
        
        switch (tools)
        {
            case SceneTools.View:
                ViewButton.Background = new SolidColorBrush(Colors.LightBlue);
                break;
            case SceneTools.Move:
                MoveButton.Background = new SolidColorBrush(Colors.LightBlue);
                break;
            case SceneTools.Rotate:
                RotateButton.Background = new SolidColorBrush(Colors.LightBlue);
                break;
            case SceneTools.Scale:
                ScaleButton.Background = new SolidColorBrush(Colors.LightBlue);
                break;
        }
    }
}