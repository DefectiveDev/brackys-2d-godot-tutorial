using Godot;
using System;

public partial class Slime : Node2D
{
    [Export]
    private float Speed = 60;

    private Vector2 direction = Vector2.Right;

    private RayCast2D rayCastRight;
    private RayCast2D rayCastLeft;
    private AnimatedSprite2D animatedSprite2D;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	    rayCastRight = GetNode<RayCast2D>("RayCastRight");
	    rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
	    animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (rayCastRight.IsColliding())
        {
            direction = Vector2.Left;
            animatedSprite2D.FlipH = true;
        }
        else if (rayCastLeft.IsColliding())
        {
            direction = Vector2.Right;
            animatedSprite2D.FlipH = false;
        }

	    Position += direction * Speed * (float)delta;
	}
}
