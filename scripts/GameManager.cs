using Godot;
using System;

public partial class GameManager : Node
{
	private int points = 0; // Points variable
	private Label pointsLabel; // Points label

	public override void _Ready()
	{
		pointsLabel = GetNode<Label>("CanvasLayer2/PointsLabel");
		UpdatePointsLabel();
	}

	public void AddPoint()
	{
		points += 1;
		UpdatePointsLabel();
	}

	private void UpdatePointsLabel()
	{
		pointsLabel.Text = $"Points: {points}";
	}
}
