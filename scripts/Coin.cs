using Godot;
using System;

public partial class Coin : Area2D
{

    private void OnBodyEntered(Node2D body)
    {
        GetNode<GameManager>("%GameManager").AddPoint();
        GetNode<AnimationPlayer>("AnimationPlayer").Play("pickup");
    }
}
