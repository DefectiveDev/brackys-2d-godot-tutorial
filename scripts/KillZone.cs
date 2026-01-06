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
        timer.Start();
    }

    private void OnTimerTimout()
    {
        GetTree().ReloadCurrentScene();
    }
}
