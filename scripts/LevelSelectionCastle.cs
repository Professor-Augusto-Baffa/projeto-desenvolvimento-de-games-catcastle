using Godot;
using System;

public partial class LevelSelectionCastle : Area2D
{
	public String SceneToLoad = "res://scenes/";
	private PopupPanel popupPanel = new PopupPanel();
	
	public override void _Ready()
	{	
		this.Connect("area_entered", new Callable(this, nameof(OnAreaEntered)));
		popupPanel = GetNode<PopupPanel>("/root/LevelSelectionMap/PopupPanel");
	}

	private void OnAreaEntered(Node area)
	{
		GD.Print("Collision detected with: " + area.Name);
		switch (area.Name)
		{
			case "Level1Area":
				GetTree().ChangeSceneToFile(SceneToLoad + "Map1.tscn");
				break;
			case "Level2Area":
				//GetTree().ChangeSceneToFile(SceneToLoad + "Map2.tscn");
				ShowPopup();
				break;
			case "Level3Area":
				//GetTree().ChangeSceneToFile(SceneToLoad + "Map2.tscn");
				ShowPopup();
				break;
			case "Level4Area":
				GetTree().ChangeSceneToFile(SceneToLoad + "Map2.tscn");
				break;
			default:
				GD.Print("No matching scene for this Area");
				break;
		}
	}
	
	private void ShowPopup()
	{
		popupPanel.PopupCentered();
	}
}
