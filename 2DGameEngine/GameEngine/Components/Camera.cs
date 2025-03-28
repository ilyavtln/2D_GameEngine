﻿using System.Numerics;
using _2DGameEngine.GameEngine.Core;

namespace _2DGameEngine.GameEngine.Components;

public class Camera : Component
{
    public static readonly string ComponentName = "Camera";
        
    public Vector2 Position { get; set; }

    public Camera() : base(ComponentName)
    {
        Position = new Vector2(0, 0);
    }
}