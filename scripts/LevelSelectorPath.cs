using Godot;
using System;
using System.Collections.Generic;

public partial class LevelSelectorPath : PathFollow2D
{
	private float maxSpeed = 75.0f;
	private float acceleration = 20.0f;
	private float currentSpeed = 0.0f;
	private List<float> stopPoints = new List<float>();
	private PathFollow2D pathFollow = new PathFollow2D();
	private Sprite2D sprite = new Sprite2D();
	private Vector2 oldOffset = new Vector2();
	private Vector2 newOffset = new Vector2();
	private int nextStopIndex = 0;
	private float lastPositionX = 0.0f;
	public static float LastCastleProgress;

	public override void _Ready()
	{
		pathFollow = GetNode<PathFollow2D>("/root/LevelSelectionMap/Path2D/PathFollow2D");
		sprite = GetNode<Sprite2D>("/root/LevelSelectionMap/Path2D/PathFollow2D/LevelSelectionCastle/CastleSprite");
		oldOffset = sprite.Offset;
		newOffset = new Vector2(sprite.Offset[0], sprite.Offset[1] + 1000);
		SetProcess(true);
		InitializeStopPoints();
		currentSpeed = 2.0f;
		lastPositionX = pathFollow.Position[0];
	}

	private void InitializeStopPoints()
	{
		var path = GetParent<Path2D>();
		Curve2D curve = path.Curve;

		foreach (Node node in GetTree().GetNodesInGroup("StopPositions"))
		{
			if (node is Marker2D marker)
			{
				float closestOffset = curve.GetClosestOffset(marker.GlobalPosition);
				stopPoints.Add(closestOffset);
				GD.Print("Stop Point at Position: " + marker.GlobalPosition + ", Offset: " + closestOffset);
			}
		}
		stopPoints.Sort();

		foreach (var point in stopPoints)
		{
			GD.Print("Stop Point: " + point);
		}
	}

	public override void _Process(double _delta)
	{
		float delta = (float)_delta;
		float pathProgress = pathFollow.Progress;
		float currentPositionX = pathFollow.Position[0];

		if (nextStopIndex < stopPoints.Count)
		{
			float distanceToStop = Mathf.Abs(pathProgress - stopPoints[nextStopIndex]);
			//GD.Print("Distance to stop: " + distanceToStop);
			if (distanceToStop > 180)
			{
				currentSpeed = Mathf.Min(currentSpeed + acceleration * delta, maxSpeed);
			}
			if (distanceToStop < 180)
			{
				currentSpeed = Mathf.Max(currentSpeed - acceleration * delta, 0);
			}
			if (distanceToStop < 50 && Mathf.IsEqualApprox(currentSpeed, 0))
			{
				GD.Print("Stopping at Point: " + stopPoints[nextStopIndex]);
				nextStopIndex++;
			}
		}
		else
		{
			currentSpeed = Mathf.Min(currentSpeed + acceleration * delta, maxSpeed);
		}
		pathFollow.Progress += currentSpeed * delta;
		
		if ((currentPositionX > lastPositionX && sprite.FlipV) || (currentPositionX < lastPositionX && !sprite.FlipV))
		{
			sprite.FlipV = !sprite.FlipV;
			sprite.FlipH = !sprite.FlipH;
			if (sprite.Offset == oldOffset)
			{
				sprite.Offset = newOffset;
			}
			else
			{
				sprite.Offset = oldOffset;
			}
		}
		lastPositionX = currentPositionX;
	}
	
	public void SaveCastleProgress(PathFollow2D castlePath)
	{
		LastCastleProgress = castlePath.Progress;
	}
	
	public void RestoreCastleProgress(PathFollow2D castlePath)
	{
		castlePath.Progress = LastCastleProgress;
	}
}
