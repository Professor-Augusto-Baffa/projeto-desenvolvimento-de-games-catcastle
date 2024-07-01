using Godot;
using System;

public partial class Map : Node2D
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
	
	public void LevelCompleted(int levelNumber)
	{
		int playerHealth = GetPlayerHealth();
		int score = GetCurrentScore();

		SaveManager saveManager = new SaveManager();
		saveManager.SaveGame(levelNumber + 1, playerHealth, score);

		if (levelNumber == 4)
		{
			EndGame(true);
		}
		else
		{
			var sceneTree = GetTree();
			sceneTree.ChangeSceneToFile("res://scenes/LevelSelection.tscn");

			var levelSelectionScene = (LevelSelection)sceneTree.CurrentScene;
			var castlePath = levelSelectionScene.GetNode<PathFollow2D>("res://scenes/LevelSelection/Path2D/PathFollow2D");
			RestoreCastlePosition(castlePath);
		}
	}
	
	public void EndGame(bool isVictory)
	{
		var gameOverScene = (GameOver)ResourceLoader.Load<PackedScene>("res://scenes/GameOver.tscn").Instance();
		gameOverScene.SetupGameOver(isVictory);
		AddChild(gameOverScene);
	}
}
