using Godot;
using System;

public partial class CatSlingshot : Area2D
{
	[Export]
	public int Range = 200; // Range of the turret
	[Export]
	public float FireInterval = 1.0f; // Time between shots
	[Export]
	public PackedScene ProjectileScene; // The projectile scene to spawn

	private float fireCooldown = 0.0f;
	private Node2D currentTarget;
	private AnimatedSprite2D animatedSprite;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var shape = new CircleShape2D();
		shape.Radius = Range;
		
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		var collisionShape = new CollisionShape2D();
		collisionShape.Shape = shape;
		AddChild(collisionShape);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		fireCooldown -= (float)delta;

		if (currentTarget != null && fireCooldown <= 0)
		{
			FireProjectile();
			fireCooldown = FireInterval;
		}

		AimAtTarget();
	}
	
	private void OnAreaEntered(Area2D area)
	{
		if (area.IsInGroup("Enemies"))
		{
			currentTarget = (Node2D)area; // For simplicity, target the first enemy detected
		}
	}

	private void OnAreaExited(Area2D area)
	{
		if (area == currentTarget)
		{
			currentTarget = null; // Clear the target if it leaves the detection area
		}
	}
	
	private void FireProjectile()
	{
		if (ProjectileScene != null)
		{
			var projectile = ProjectileScene.Instantiate<SlingProjectile>();
			
			GetParent().AddChild(projectile); // Add projectile to the scene
			projectile.GlobalPosition = GlobalPosition;

			var projectileScript = (SlingProjectile)projectile;
			projectileScript.SetDirection(currentTarget.GlobalPosition);
			
			animatedSprite.Play("shooting");
		}
	}

	private void AimAtTarget()
	{
		if (currentTarget != null)
		{
			LookAt(currentTarget.GlobalPosition);
		}
	}
}
