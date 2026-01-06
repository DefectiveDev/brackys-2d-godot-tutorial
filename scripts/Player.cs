using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;


    AnimatedSprite2D animatedSprite2D;
	public override void _Ready()
    {
        animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float direction = Input.GetAxis("move_left", "move_right");

        //flip sprite dependent on direction
        if (direction > 0)
        {
            animatedSprite2D.FlipH = false;
        }
        else if (direction < 0)
        {
            animatedSprite2D.FlipH = true;
        }

        //change animation
        if (IsOnFloor())
        {
            if (direction == 0)
            {
                animatedSprite2D.Play("idle");
            }
            else
            {
                animatedSprite2D.Play("run");
            }
        }
        else
        {
            animatedSprite2D.Play("jump");
        }

		if (direction != 0)
		{
			velocity.X = direction * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
