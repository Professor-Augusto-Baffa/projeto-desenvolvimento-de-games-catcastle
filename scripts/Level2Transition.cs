using Godot;
using static Godot.GD;
using System;

public partial class Level2Transition : Area2D
{
	public String SceneToLoad = "res://scenes/Map2.tscn";
	
	public override void _Ready()
	{
		this.Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}

	private void OnBodyEntered(Node body)
	{
		GD.Print("entered body");
		if (body.Name == "Castle")
		{
			GetTree().ChangeSceneToFile(SceneToLoad);
		}
	}
}
