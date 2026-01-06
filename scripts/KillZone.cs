using Godot;
using System;

public partial class KillZone : Area2D
{
    Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
    }

    private void OnBodyEntered(Node2D body)
    {
        GD.Print("You died!");
        Engine.TimeScale = 0.5;
        body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
        timer.Start();
    }

    private void OnTimerTimout()
    {
        Engine.TimeScale = 1;
        GetTree().ReloadCurrentScene();
    }
}
