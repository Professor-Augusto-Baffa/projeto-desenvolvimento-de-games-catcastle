using Godot;
using System;

public partial class PathFollower : Node
{
	[Export]
	public NodePath PathFollowPath; // Export this so you can set it in the Godot editor

	public float Speed = 80.0f;

	private PathFollow2D pathFollow;

	public override void _Ready()
	{
		// Use the exported NodePath to get the PathFollow2D
		pathFollow = GetNode<PathFollow2D>(PathFollowPath);

		if (pathFollow == null)
		{
			GD.Print("PathFollow2D node not found! Check the NodePath.");
		}
	}

	public override void _Process(double delta)
	{
		if (pathFollow != null)
		{
			pathFollow.Progress += Speed * (float)delta; // Update the offset based on the speed
		}
	}
}
