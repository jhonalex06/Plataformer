using Godot;
using System;

public class Portal2D : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	[Export]
	public PackedScene next_scene = new PackedScene();
	
	private void _on_body_entered(object body)
	{
		teleport();
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	public async void teleport(){
		AnimationPlayer animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animPlayer.Play("fade_in");
		await ToSignal(animPlayer, "animation_finished");
		GetTree().ChangeSceneTo(next_scene);
	}
	
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
