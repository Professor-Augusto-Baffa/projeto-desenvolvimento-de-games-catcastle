using Godot;
using System;

public partial class QuitButton : TextureButton
{
	public override void _Ready()
	{
		this.Connect("pressed", new Callable(this, nameof(OnQuitPressed)));
	}

	public override void _Process(double delta)
	{
	}
	
	public void OnQuitPressed()
	{
		GetTree().Quit();
	}
}
