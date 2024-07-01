using Godot;
using System;

public partial class LevelSelectionCastle : Area2D
{
	public String SceneToLoad = "res://scenes/";
	
	public override void _Ready()
	{	
		this.Connect("area_entered", new Callable(this, nameof(OnAreaEntered)));
	}

	private void OnAreaEntered(Node area)
	{
		GD.Print("Collision detected with: " + area.Name);
		switch (area.Name)
		{
			case "Level1Area":
				//GetTree().ChangeSceneToFile(SceneToLoad + "Map2.tscn");
				break;
			case "Level2Area":
				//GetTree().ChangeSceneToFile(SceneToLoad + "Map2.tscn");
				break;
			case "Level3Area":
				GetTree().ChangeSceneToFile(SceneToLoad + "Map2.tscn");
				break;
			case "Level4Area":
				GetTree().ChangeSceneToFile(SceneToLoad + "Map2.tscn");
				break;
			default:
				GD.Print("No matching scene for this Area");
				break;
		}
	}
}
