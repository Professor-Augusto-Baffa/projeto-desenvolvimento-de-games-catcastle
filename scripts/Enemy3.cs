using Godot;
using System;

public partial class Enemy3 : Area2D
{
	public float Speed = 100.0f;
	private AnimatedSprite2D animatedSprite;
	private Vector2 lastPosition;
	private PathFollow2D pathFollow;
	private float pathLength;
	
	[Export]
	public int Health = 20;

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
			//UpdateAnimation(movementVector);
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
}
