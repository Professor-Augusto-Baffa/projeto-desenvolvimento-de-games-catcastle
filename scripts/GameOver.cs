using Godot;
using System;

public partial class GameOver : TextureRect
{
	private TextureRect gameOverImage = new TextureRect();
	public override void _Ready()
	{
		gameOverImage = GetNode<TextureRect>("GameOverImage");
	}

	public void SetupGameOver(bool isVictory)
	{
		if (isVictory)
		{
			gameOverImage.Texture = (Texture2D)GD.Load("res://assets/buttons/botão_PARABÉNS.png");
		}
		else
		{
			gameOverImage.Texture = (Texture2D)GD.Load("res://assets/buttons/botão_DERROTA.png");
		}
	}
}
