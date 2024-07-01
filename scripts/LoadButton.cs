using Godot;
using System;

public partial class LoadButton : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Connect("pressed", new Callable(this, nameof(OnLoadPressed)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void OnLoadPressed()
	{
		FileDialog fileDialog = GetNode<FileDialog>("/root/Control/FileDialog");
		fileDialog.PopupCentered();
	}
	
	private void OnFileSelected(String path)
	{
		// Adicione código aqui para carregar o jogo do arquivo selecionado
	}
}
