extends Node2D

var stack = []



func _ready():
	pass


func update_number_cards():
	$NumberCards.text = stack.size()

func able_stack():
	$Stack.modulate = Color(1, 1, 1, 1.0)
	$SatckButton.disable = false

func disable_stack():
	$Stack.modulate = Color(0.5, 0.5, 0.5, 1.0)
	$SatckButton.disable = true
