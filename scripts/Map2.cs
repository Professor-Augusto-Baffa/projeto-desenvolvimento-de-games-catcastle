using Godot;
using System;

public partial class Map2 : Node2D
{
	[Export]
	public PackedScene TurretScene; // Use the normal turret scene

	private PackedScene selectedTurretScene;
	private Node2D turretPreviewInstance;
	private bool isPlacingTurret = false;

	public override void _Ready()
	{
		// Connect the TurretSelectedEventHandler signal from the UI
		var turretSelection = GetNode<Control>("CanvasLayer/TurretSelection");
		turretSelection.Connect("TurretSelectedEventHandler", new Callable(this, nameof(OnTurretSelected)));
	}

	public override void _Process(double delta)
	{
		if (isPlacingTurret && selectedTurretScene != null)
		{
			if (turretPreviewInstance == null)
			{
				turretPreviewInstance = selectedTurretScene.Instantiate<Node2D>();
				AddChild(turretPreviewInstance);
			}

			// Update the turret preview position to follow the mouse
			var mousePosition = GetGlobalMousePosition();
			turretPreviewInstance.GlobalPosition = mousePosition;
			turretPreviewInstance.Visible = true;

			// Check for mouse click to place the turret
			if (Input.IsActionJustPressed("mouse_left_click"))
			{
				PlaceTurret(mousePosition);
			}
		}
		else if (turretPreviewInstance != null)
		{
			turretPreviewInstance.Visible = false;
		}
	}

	private void OnTurretSelected(PackedScene turretScene)
	{
		selectedTurretScene = turretScene;
		isPlacingTurret = true;

		// Ensure the preview is properly instantiated and added
		if (turretPreviewInstance != null)
		{
			turretPreviewInstance.QueueFree();
		}
		turretPreviewInstance = selectedTurretScene.Instantiate<Node2D>();
		AddChild(turretPreviewInstance);
		turretPreviewInstance.Visible = false;
	}

	private void PlaceTurret(Vector2 position)
	{
		// Ensure we are not placing the turret over the UI
		var uiRect = GetNode<Control>("CanvasLayer/TurretSelection").GetGlobalRect();
		if (!uiRect.HasPoint(position))
		{
			// Instantiate and add the turret to the scene at the mouse position
			var turretInstance = selectedTurretScene.Instantiate<Node2D>();
			turretInstance.GlobalPosition = position;
			AddChild(turretInstance);
			
			if (turretInstance is CatSlingshot turret)
			{
				turret.IsPlaced = true;
			}


			// Optionally, reset the selected turret scene to prevent multiple placements
			isPlacingTurret = false;
			selectedTurretScene = null;

			// Hide and reset the preview instance
			turretPreviewInstance.Visible = false;
			turretPreviewInstance.QueueFree();
			turretPreviewInstance = null;
		}
	}
}
