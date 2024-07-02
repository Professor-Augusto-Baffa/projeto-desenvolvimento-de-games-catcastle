using Godot;
using System;

public partial class GameOver : TextureRect
{
	private TextureRect gameOverImage = new TextureRect();
	private TextureRect gameOverBackground = new TextureRect();
	public override void _Ready()
	{
		gameOverImage = GetNode<TextureRect>("GameOverImage");
		gameOverBackground = GetNode<TextureRect>("GameOver");
	}

	public void SetupGameOver(bool isVictory)
	{
		if (isVictory)
		{
			gameOverImage.Texture = (Texture2D)GD.Load("res://assets/buttons/botão_PARABÉNS.png");
			gameOverBackground.Texture = (Texture2D)GD.Load("res://assets/background/BACKGROUND_Azul.png");
		}
		else
		{
			gameOverImage.Texture = (Texture2D)GD.Load("res://assets/buttons/botão_DERROTA.png");
			gameOverBackground.Texture = (Texture2D)GD.Load("res://assets/background/BACKGROUND_Marrom.png");
		}
	}
}
