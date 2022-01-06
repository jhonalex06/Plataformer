using Godot;
using System;

public class Actor : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public Vector2 FLOOR_NORMAL = new Vector2(0,-1);
	[Export]
	public Vector2 speed = new Vector2(300,1000);
	[Export]
	public float gravity = 4000.0F;
	public Vector2 _velocity = new Vector2(0, 0);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//	public override void _PhysicsProcess(float delta)
//	{
//
//	}
}
