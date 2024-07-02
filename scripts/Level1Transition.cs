using Godot;
//using Godot.GD as GD;
using System;

public partial class Level1Transition : Area2D
{
	public String SceneToLoad = "res://scenes/Map1.tscn";
	
	public override void _Ready()
	{	
		this.Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}

	private void OnBodyEntered(Node body)
	{
		GD.Print("Collision detected with: " + body.Name);
		if (body.Name == "Castle")
		{
			GetTree().ChangeSceneToFile(SceneToLoad);
		}
	}
}
