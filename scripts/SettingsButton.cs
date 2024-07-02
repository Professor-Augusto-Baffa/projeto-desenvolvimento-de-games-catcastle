using Godot;
using System;

public partial class SettingsButton : TextureButton
{
	private PopupMenu popupSettings;

	public override void _Ready()
	{
		popupSettings = GetNode<PopupMenu>("/root/Control/SettingsPopup");
		this.Connect("pressed", new Callable(this, nameof(OnSettingsButtonPressed)));
	}

	private void OnSettingsButtonPressed()
	{
		popupSettings.Exclusive = true;
		popupSettings.PopupCentered();
	}
}
