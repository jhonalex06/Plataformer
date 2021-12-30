using Godot;
using System;
using static Actor;

public class Player : Actor
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export]
	public float stomp_impulse = 700.0F;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}
	
	private void _on_EnemyDetector_area_entered(Area2D area)
	{
		_velocity = CalculateStompVelocity(_velocity, stomp_impulse);
	}
	
	private void _on_EnemyDetector_body_entered(object body)
	{
		QueueFree();
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
 	{
//		base._PhysicsProcess(delta);
		bool isJumpInterrupted = Input.IsActionJustReleased("jump") & _velocity.y < 0.0;
		Vector2 direction = GetDirection();
		_velocity = CalculateMoveVelocity(_velocity, direction, speed, isJumpInterrupted);
		_velocity = MoveAndSlide(_velocity, FLOOR_NORMAL);
	}
	
	public Vector2 GetDirection(){
		float position_y = 0F;
		
		if (Input.IsActionJustPressed("jump") & IsOnFloor()){
			position_y = -1.0F;
		} else {
			position_y = 0.0F;
		}
		
		return new Vector2(Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left"), position_y);
	}
	
	public Vector2 CalculateMoveVelocity(
		Vector2 linear_velocity,
		Vector2 direction,
		Vector2 speed,
		bool isJumpInterrupted)
		{
		Vector2 output = linear_velocity;
		output.x = speed.x * direction.x;
		output.y += gravity * GetPhysicsProcessDeltaTime();

		if (direction.y == -1.0){
			output.y = speed.y * direction.y;
		}
		if (isJumpInterrupted){
			output.y = 0.0F;
		}

		return output;
	}
	
	public Vector2 CalculateStompVelocity(Vector2 linear_velocity, float impulse){
		var output = linear_velocity;
		output.y = -impulse;
		return output;
	}
}
