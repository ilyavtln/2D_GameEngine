using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.Editor;

public partial class SceneView : UserControl
{
    
    private Scene? _scene;
    
    private double _zoomScale = 1.0; // Начальный масштаб
    private readonly double _maxScale = 40.0;
    private readonly double _minScale = 1.0;
    private readonly int _gridSize = 8;
    private readonly double _strokeThickness = 0.2;
    private string? _currentTool = "View";
    
    public SceneView()
    {
        InitializeComponent();
        DrawGrid(); // Рисуем сетку при инициализации
        SceneCanvas.SizeChanged += SceneCanvas_SizeChanged; 
    }
    
    public void SetScene(Scene? scene)
    {
        _scene = scene;
        _scene.GameObjectAdded += OnGameObjectAdded;
    }

    private void OnGameObjectAdded(GameObject gameObject)
    {
        _scene.Render(SceneCanvas);
    }

    private void SceneCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        DrawGrid(); // Обновляем сетку при изменении размера
    }

    private void DrawGrid()
    {
        SceneCanvas.Children.Clear(); // Очистка предыдущих линий сетки
        double viewportWidth = SceneCanvas.ActualWidth;
        double viewportHeight = SceneCanvas.ActualHeight;

        // Рисуем вертикальные линии
        for (double x = 0; x < viewportWidth; x += _gridSize)
        {
            var line = new Line
            {
                X1 = x,
                Y1 = 0,
                X2 = x,
                Y2 = viewportHeight,
                Stroke = Brushes.Gray,
                StrokeThickness = _strokeThickness
            };
            SceneCanvas.Children.Add(line);
        }

        // Рисуем горизонтальные линии
        for (double y = 0; y < viewportHeight; y += _gridSize)
        {
            var line = new Line
            {
                X1 = 0,
                Y1 = y,
                X2 = viewportWidth,
                Y2 = y,
                Stroke = Brushes.Gray,
                StrokeThickness = _strokeThickness
            };
            SceneCanvas.Children.Add(line);
        }
    }
    
    private void SceneCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        // Обработка зума
        if (e.Delta > 0) // Приближение
        {
            if (_zoomScale < _maxScale) // Максимальный масштаб
            {
                _zoomScale *= 1.1;
            }
        }
        else // Отдаление
        {
            if (_zoomScale > _minScale) // Минимальный масштаб
            {
                _zoomScale /= 1.1;
            }
        }

        // Применение масштаба
        ZoomTransform.ScaleX = _zoomScale;
        ZoomTransform.ScaleY = _zoomScale;

        DrawGrid(); // Перерисовка сетки с новым масштабом
    }
    
    private void ToolButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            // Установка текущего инструмента
            _currentTool = button.Tag.ToString();
            UpdateToolSelection(button); // Передаем текущую кнопку
        }
    }

    private void UpdateToolSelection(Button selectedButton)
    {
        var stackPanel = (StackPanel) selectedButton.Parent;
    
        foreach (var child in stackPanel.Children)
        {
            if (child is Button button)
            {
                button.Background = button.Tag.ToString() == _currentTool ? Brushes.LightBlue : Brushes.White;
            }
        }
    }
}