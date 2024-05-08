using Godot;
using System;

public partial class EnemySpawner : Node
{
	[Export]
	public PackedScene EnemyPrefab;
	
	[Export]
	public NodePath SpawnPointPath;  // Path to the Marker2D node used as the spawn point
	[Export]
	public NodePath PathFollowPath;
	[Export]
	public float SpawnInterval = 2.0f;  // Time between spawns

	private float _timer = 0.0f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer = SpawnInterval;
		SpawnEnemy();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_timer -= (float)delta;
		if (_timer <= 0)
		{
			//SpawnEnemy();
			_timer = SpawnInterval;  // Reset the timer after spawning an enemy
		}
	}
	
	private void SpawnEnemy()
	{
		var spawnPoint = GetNode<Marker2D>(SpawnPointPath);  // Get the spawn point node
		var pathFollow = GetNode<PathFollow2D>(PathFollowPath); 
		var enemy = EnemyPrefab.Instantiate<Mob2>(); // Create an instance of the enemy
		pathFollow.AddChild(enemy);
		enemy.GlobalPosition = spawnPoint.GlobalPosition; // Set the enemy's position to the spawn point
	}
}
