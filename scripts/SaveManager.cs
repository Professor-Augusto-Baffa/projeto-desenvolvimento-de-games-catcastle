using Godot;
using System;

public partial class SaveManager : Node
{
		public void SaveGame(int levelNumber, int playerHealth, int score)
		{
			//var saveFile = new File();
			//saveFile.Open("user://save_game.save", File.ModeFlags.Write);

			// Salvando os dados do jogo
			//saveFile.StoreVar("levelNumber", levelNumber);
			//saveFile.StoreVar("playerHealth", playerHealth);
			//saveFile.StoreVar("score", score);

			//saveFile.Close();
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
