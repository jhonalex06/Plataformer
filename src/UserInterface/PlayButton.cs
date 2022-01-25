using Godot;
using System;

[Tool]
public class PlayButton : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export(PropertyHint.File, "*.tscn")]
	private string next_scene_path = "";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	private void _on_button_up()
	{
		GetTree().ChangeScene(next_scene_path);
		// Replace with function body.
	}
	
	public String _GetConfigurationWarning()
	{
		if (next_scene_path == "")
			return "next_scene_path must be set for the button to work ";
		return "";
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
