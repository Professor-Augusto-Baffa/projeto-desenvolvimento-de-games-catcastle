using Godot;
using System;

public partial class Castle : Area2D
{
	[Export]
	public int MaxHealth = 100;
	public int CurrentHealth;

	private Label _healthLabel;

	public override void _Ready()
	{
		CurrentHealth = MaxHealth;
		_healthLabel = GetNode<Label>("../CanvasLayer2/CastleHealthLabel");
		UpdateHealthLabel();
	}
	
	private void OnAreaEntered(Area2D area)
	{
		if (area is Enemy2 enemy2)
		{
			TakeDamage(10);
			enemy2.QueueFree(); // Remove the enemy after it hits the castle
		}
		else if (area is Enemy3 enemy3)
		{
			TakeDamage(20);
			enemy3.QueueFree(); // Remove the enemy after it hits the castle
		}
	}

	public void TakeDamage(int amount)
	{
		CurrentHealth -= amount;
		if (CurrentHealth < 0) CurrentHealth = 0;
		UpdateHealthLabel();

		if (CurrentHealth <= 0)
		{
			Die();
		}
	}

	private void UpdateHealthLabel()
	{
		_healthLabel.Text = $"Castle Health: {CurrentHealth}";
	}

	private void Die()
	{
		GD.Print("Castle has been destroyed!");
		// Handle the castle destruction logic here
	}
}


