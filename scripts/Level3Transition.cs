using Godot;
using System;

public partial class Level3Transition : Area2D
{
	public String SceneToLoad = "res://scenes/Map3.tscn";
	
	public override void _Ready()
	{
		this.Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}

	private void OnBodyEntered(Node body)
	{
		if (body.Name == "Castle")
		{
			GetTree().ChangeSceneToFile(SceneToLoad);
		}
	}
}
