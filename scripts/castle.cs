using Godot;
using System;

public partial class Castle : Area2D
{
	public int Health { get; set; } = 100;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	 public void TakeDamage(int amount)
	{
		Health -= amount;
		GD.Print($"Health remaining: {Health}");

		if (Health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		QueueFree();  // Destroys the object
		// Additional logic for game over or damage animation can be added here
	}
}
