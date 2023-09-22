extends Node2D
#class_name Stack

var number_cards

var stack_scene = preload("res://Scenes/Stack.tscn")

func _ready():
	pass


#func _init(number):
	#var stack = stack_scene.instantiate()
	#number_cards = number
	


func _on_stack_button_pressed():
	pass # Replace with function body.


func update_number_cards():
	$NumberCards.text = number_cards

func able_stack():
	$Stack.modulate = Color(1, 1, 1, 1.0)
	$SatckButton.disable = false

func disable_stack():
	$Stack.modulate = Color(0.5, 0.5, 0.5, 1.0)
	$StackButton.disabled = true


