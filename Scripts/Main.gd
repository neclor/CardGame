extends Node2D

const player_scene = preload("res://Scenes/Player.tscn")
const card_scene = preload("res://Scenes/Card.tscn")

const PORT = 6789
var enet_peer = ENetMultiplayerPeer.new()
var players = []

var card_deck = []
var stacks = []

func init():
	#card_deck = Deck.shuffle_deck(Deck.create_deck())
	#card_deck = Deck.divide_deck(card_deck, 4)
	pass

func _ready():
	init()
	#$StartButton.visible = true
	print()



func start():
	print(players)
	pass












func _on_test_pressed():
	test.rpc()
	
	
@rpc("any_peer")
func test():
	add_child(card_scene.instantiate())


func _on_start_button_pressed():
	start()
	pass # Replace with function body.



















func _on_host_pressed():
	$StartButton.visible = true

	
	enet_peer.create_server(PORT)
	multiplayer.multiplayer_peer = enet_peer
	multiplayer.peer_connected.connect(add_player)
	
	add_player(multiplayer.get_unique_id())


func _on_join_pressed():


	enet_peer.create_client("localhost", PORT) #$Menu/ip.text
	multiplayer.multiplayer_peer = enet_peer



func add_player(peer_id):
	print("asdsad")
	var player = player_scene.instantiate()
	player.name = str(peer_id)
	players.append(player)
	add_child(player)
