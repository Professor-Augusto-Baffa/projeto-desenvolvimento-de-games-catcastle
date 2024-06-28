using Godot;
using System;

public partial class Mob2 : Area2D
{
	public float Speed = 100.0f;
	private AnimatedSprite2D animatedSprite;
	private Vector2 lastPosition;
	private PathFollow2D pathFollow;
	private float pathLength;

	public override void _Ready()
	{
		RotationDegrees = -90; 
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		pathFollow = GetParent<PathFollow2D>();
		lastPosition = GlobalPosition;
		
		pathLength = ((Path2D)pathFollow.GetParent()).Curve.GetBakedLength();
	}

	public override void _Process(double delta)
	{
		if (pathFollow != null)
		{
			// Update the offset to move along the path
			pathFollow.Progress += Speed * (float)delta;

			// Determine the movement vector
			Vector2 movementVector = GlobalPosition - lastPosition;
			UpdateAnimation(movementVector);
			lastPosition = GlobalPosition;
			// Check if the mob has reached the end of the path
			if (pathFollow.Progress >= pathLength)
			{
				QueueFree();  // Remove the mob from the scene
			}
		}
		
		
	}

	private void UpdateAnimation(Vector2 movementVector)
	{
		if (movementVector.Length() > 0)
		{
			animatedSprite.Play();
			if (Mathf.Abs(movementVector.X) > Mathf.Abs(movementVector.Y))
			{
				animatedSprite.Animation = "front";
				animatedSprite.FlipH = movementVector.X < 0;
				animatedSprite.RotationDegrees = 0; // Ensure no rotation for left/right movement
			}
			else
			{
				if (movementVector.Y > 0)
				{
					animatedSprite.Animation = "front"; // Moving down
					animatedSprite.RotationDegrees = 0; // Ensure sprite is not rotated when moving down
				}
				else
				{
					animatedSprite.Animation = "back"; // Moving up
					animatedSprite.RotationDegrees = 180; // Rotate 180 degrees to correct the upside down issue
				}
			}
		}
		else
		{
			animatedSprite.Stop();
		}
	}
}
