using Godot;
using System;

public partial class CatSword : Area2D
{
	[Export]
	public float AttackRate = 1.0f;

	[Export]
	public float AttackRange = 100.0f; // Range within which the turret can attack

	[Export]
	public int Damage = 10;

	private float _timeSinceLastAttack = 0.0f;
	private bool _isPlaced = false;
	private AnimatedSprite2D _animatedSprite;

	public bool IsPlaced
	{
		get { return _isPlaced; }
		set
		{
			_isPlaced = value;
			if (_isPlaced)
			{
				// Enable collision shape when placed
				GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
			}
		}
	}

	public override void _Ready()
	{
		// Disable collision shape initially
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _Process(double delta)
	{
		if (IsPlaced)
		{
			_timeSinceLastAttack += (float)delta;

			if (_timeSinceLastAttack >= AttackRate)
			{
				PerformMeleeAttack();
				_timeSinceLastAttack = 0.0f;
			}
		}
	}

	private void PerformMeleeAttack()
	{
		var enemies = GetTree().GetNodesInGroup("Enemies");
		bool attacked = false;
		foreach (Node2D enemy in enemies)
		{
			if (GlobalPosition.DistanceTo(enemy.GlobalPosition) <= AttackRange)
			{
				GD.Print("Attacking enemy: ", enemy.Name);
				// Apply damage to the enemy
				
				if (enemy is Enemy2 enemy2)
				{
					enemy2.TakeDamage(Damage);
					attacked = true;
				}
				else if (enemy is Enemy3 enemy3)
				{
					enemy3.TakeDamage(Damage);
					attacked = true;
				}
			}
		}

		// Play attack animation if an enemy was attacked
		if (attacked)
		{
			_animatedSprite.Play("attack");
		}
	}
}
