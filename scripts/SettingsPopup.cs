using Godot;
using System;

public partial class SettingsPopup : PopupMenu
{
	private HSlider volumeSlider = new HSlider();
	private OptionButton resolutionDropdown = new OptionButton();
	 
	public override void _Ready()
	{
		var volumeSlider = GetNode<HSlider>("/root/Control/SettingsPopup/VboxContainer/VolumeSlider");
		volumeSlider.Value = (float)ProjectSettings.GetSetting("audio/volume_master");
		volumeSlider.Connect("value_changed", new Callable(this, nameof(OnVolumeSliderChanged)));

		var screenModeDropdown = GetNode<OptionButton>("/root/Control/SettingsPopup/VboxContainer/ScreenModeDropdown");
		screenModeDropdown.AddItem("Janela", 0);
		screenModeDropdown.AddItem("Tela Cheia", 1);
		screenModeDropdown.AddItem("Tela Cheia Sem Bordas", 2);
		screenModeDropdown.Connect("item_selected", new Callable(this, nameof(OnScreenModeSelected)));
	}

	private void OnVolumeSliderChanged(float value)
	{
		ProjectSettings.SetSetting("audio/volume_master", value);
		GetNode<Label>("/root/Control/SettingsPopup/VboxContainer/VolumeLabel").Text = "Volume: " + value.ToString("F0");
	}

	private void OnScreenModeSelected(int index)
	{
		switch (index)
		{
			case 0: // Janela
				DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
				DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, false, 0);
				break;
			case 1: // Tela Cheia
				DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
				DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, false, 0);
				break;
			case 2: // Tela Cheia Sem Bordas
				DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
				DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, true, 0);
				break;
		}
	}
}
