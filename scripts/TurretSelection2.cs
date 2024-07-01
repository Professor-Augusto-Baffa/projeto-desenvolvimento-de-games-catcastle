using Godot;
using System;

public partial class TurretSelection2 : Control
{
	[Signal]
	public delegate void TurretSelectedEventHandler(PackedScene turretScene);

	[Export]
	public PackedScene Turret1Scene;
	[Export]
	public PackedScene Turret2Scene;

	public override void _Ready()
	{
		// Register the signal
		AddUserSignal("TurretSelectedEventHandler");

		// Connect signals to the input handlers
		GetNode<TextureRect>("VBoxContainer/PreviewTurret1").Connect("gui_input", new Callable(this, nameof(OnPreviewTurret1Input)));
		GetNode<TextureRect>("VBoxContainer/PreviewTurret2").Connect("gui_input", new Callable(this, nameof(OnPreviewTurret2Input)));
	}

	private void OnPreviewTurret1Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
		{
			EmitSignal("TurretSelectedEventHandler", Turret1Scene);
		}
	}

	private void OnPreviewTurret2Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
		{
			EmitSignal("TurretSelectedEventHandler", Turret2Scene);
		}
	}
}
