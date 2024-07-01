using Godot;
using System;

public partial class RestartButton : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Connect("pressed", new Callable(this, nameof(OnRestartButtonPressed)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnRestartButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/MainMenu.tscn"); 
	}
}
