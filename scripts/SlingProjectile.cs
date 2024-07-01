using Godot;
using System;

public partial class SlingProjectile : CharacterBody2D
{
	[Export]
	public float Speed = 400.0f;

	private Vector2 direction;
	private Vector2 velocity;

	public override void _Ready()
	{
		GD.Print("Projectile ready");  // Debugging statement
	}

	public void SetDirection(Vector2 targetPosition)
	{
		direction = (targetPosition - GlobalPosition).Normalized();
		velocity = direction * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		// Move and slide and capture the collision information
		MoveAndSlide((float)delta);

		// Check for collisions
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var collision = GetSlideCollision(i);
			CheckCollision(collision.GetCollider() as Node2D);
		}
	}

	private void MoveAndSlide(float delta)
	{
		Vector2 motion = velocity * delta;
		MoveAndCollide(motion);
	}

	private void CheckCollision(Node2D collider)
	{
		if (collider != null && collider.IsInGroup("Enemies"))
		{
			GD.Print("Collided with enemy: " + collider.Name); // Debugging statement
			collider.QueueFree(); // Remove the enemy
			QueueFree(); // Remove the projectile
		}
	}
}
