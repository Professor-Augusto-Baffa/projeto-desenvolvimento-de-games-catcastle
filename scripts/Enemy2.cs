using Godot;
using System;

public partial class Enemy2 : Area2D
{
	public float Speed = 100.0f;
	private AnimatedSprite2D animatedSprite;
	private Vector2 lastPosition;
	private PathFollow2D pathFollow;
	private float pathLength;
	
	[Export]
	public int Health = 10;

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
			// Check if the enemy has reached the end of the path
			if (pathFollow.Progress >= pathLength)
			{
				QueueFree();  // Remove the enemy from the scene
			}
		}
	}
	
	public void TakeDamage(int amount)
	{
		Health -= amount;
		GD.Print("Enemy3 health: ", Health);
		if (Health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		GD.Print("Enemy3 died: ", Name);
		QueueFree();
	}
	
	private void OnBodyEntered(Node body)
	{
		GD.Print("Collision detected with: " + body.Name); // Debugging statement

		if (body is SlingProjectile)
		{
			GD.Print("Collided with projectile: " + body.Name); // Debugging statement
			body.QueueFree(); // Remove the projectile
			//QueueFree(); // Remove the mob
			TakeDamage(10);
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
