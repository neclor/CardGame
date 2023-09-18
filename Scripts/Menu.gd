extends Node2D

const main_scene = preload("res://Scenes/Main.tscn")

func _ready():
	#main_scene.instatiate()
	pass

func _on_join_button_pressed():
	get_tree().change_scene_to_file("res://Scenes/Main.tscn")
	Main.join_game("localhost", $Name.text) #Ip.text

func _on_host_button_pressed():
	get_tree().change_scene_to_file("res://Scenes/Main.tscn")
	Main.host_game($Name.text)
