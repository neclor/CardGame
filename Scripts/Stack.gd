extends Node2D

var stack_scene = preload("res://Scenes/Stack.tscn")

var number_cards = 13

func _ready():
	pass


#func _init(number):
	#var stack = stack_scene.instantiate()
	#number_cards = number
	


func _on_stack_button_pressed():
	number_cards -= 1
	if number_cards > 0:
		update_number_cards()
	else:
		queue_free()



func update_number_cards():
	$NumberCards.text = str(number_cards)

func able_stack():
	$Stack.modulate = Color(1, 1, 1, 1.0)
	$SatckButton.disable = false

func disable_stack():
	$Stack.modulate = Color(0.5, 0.5, 0.5, 1.0)
	$StackButton.disabled = true


