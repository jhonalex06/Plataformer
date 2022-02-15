extends Actor


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
func _physics_process(delta):
	var direction: = Vector2(
		Input.get_action_strength("move_right") - Input.get_action_strength("move_left"), 
		1.0
	)
	velocity = speed * direction
	velocity = move_and_slide(velocity)

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
