using Godot;
using System;

public partial class TurretSelection : Control
{
	[Signal]
	public delegate void TurretSelectedEventHandler(PackedScene turretScene); // Corrected signal name

	[Export]
	public PackedScene TurretScene;

	public override void _Ready()
	{
		// Register the signal
		AddUserSignal("TurretSelectedEventHandler");

		// Connect signals to the input handlers
		GetNode<TextureRect>("VBoxContainer/PreviewTurret").Connect("gui_input", new Callable(this, nameof(OnPreviewTurretInput)));
	}

	private void OnPreviewTurretInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
		{
			EmitSignal("TurretSelectedEventHandler", TurretScene); // Emit the signal with the turret scene
		}
	}
}
