extends Node2D



func _ready():
	change_texture(["Diamonds", "A"])

func change_texture(card):
	$Card.texture = load("res://Assets/Cards/{0}/{1}.png".format(card))

