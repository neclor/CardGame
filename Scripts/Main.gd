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
	pass




func join_game(ip, _name):
	enet_peer.create_client(ip, PORT) #$Menu/ip.text
	multiplayer.multiplayer_peer = enet_peer
	#$/root/Main/StartButton.visible = false

func host_game(_name):
	enet_peer.create_server(PORT)

	multiplayer.multiplayer_peer = enet_peer
	multiplayer.peer_connected.connect(add_player)

	add_player(multiplayer.get_unique_id(), _name)
	$Button.text = "abc"

func add_player(id, _name):
	var player = player_scene.instantiate()

	player.name = str(id)

	players.append(player)
	add_child(player)

	player.init(id, _name)
	#player.position = $MarkerPlayer0.position







func _on_test_pressed():
	test.rpc()
	
	
@rpc("any_peer")
func test():
	add_child(card_scene.instantiate())
