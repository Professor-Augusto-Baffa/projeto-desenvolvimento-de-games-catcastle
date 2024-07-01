using Godot;
using System;

public partial class LevelSelectorPath : PathFollow2D
{
	public double Speed = 100;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		var pathFollow = GetNode<PathFollow2D>("/root/LevelSelectionMap/Path2D/PathFollow2D");
		pathFollow.Progress += (float)(Speed * delta);
	}
}
