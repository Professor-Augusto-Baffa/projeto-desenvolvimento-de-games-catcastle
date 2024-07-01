using Godot;
using System;

public partial class StartButton : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Connect("pressed", new Callable(this, nameof(OnStartButtonPressed)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnStartButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/LevelSelection.tscn");
	}
}
