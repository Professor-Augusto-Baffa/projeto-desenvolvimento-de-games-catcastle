using Godot;
using System;

public partial class SaveManager : Node
{
	public void SaveGame(int levelNumber)
	{
		//var saveFile = FileAccess.Open("user://save_game.save", FileAccess.ModeFlags.Write);
		//saveFile.StoreVar("levelNumber", levelNumber);
		//saveFile.Close();
	}
	
	public void LoadGame(string filePath)
	{
		var saveFile = FileAccess.Open("user://save_game.save", FileAccess.ModeFlags.Write);
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
