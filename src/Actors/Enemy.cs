using Godot;
using System;
using static Actor;

public class Enemy : Actor
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetPhysicsProcess(false);
		_velocity.x = -speed.x;
	}
	
	private void _on_StompDetector_body_entered(PhysicsBody2D body)
	{
		var stompdetector = GetNode<Area2D>("StompDetector");
		if (body.GlobalPosition.y > stompdetector.GlobalPosition.y){
			return;
		}
		var collisionshape = GetNode<CollisionShape2D>("CollisionShape2D");
		QueueFree();	
	}
	
	public override void _PhysicsProcess(float delta){
		_velocity.y += gravity * delta;
		
		if (IsOnWall()){
			_velocity.x *= -1.0F; 
		} else {
			
		}
		 
		_velocity.y = MoveAndSlide(_velocity, FLOOR_NORMAL).y;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
