using Godot;
using System;

public partial class TurretSelectionMenu : Control
{
	[Signal]
	public delegate void TurretSelectedEventHandler(PackedScene turretScene);

	[Export]
	public PackedScene Turret1Scene;

	public override void _Ready()
	{
		// Correct the node paths to match the structure
		GetNode<TextureRect>("VBoxContainer/PreviewTurret1").Connect("gui_input", new Callable(this, nameof(OnPreviewTurret1Input)));
	}

	private void OnPreviewTurret1Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
		{
			EmitSignal(nameof(TurretSelectedEventHandler), Turret1Scene);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
