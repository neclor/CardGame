extends Node2D

var card_deck


#cards.append(os.path.abspath('sprites/' + m + c + '.png'))

var players = []





func _ready():
	init()

	print(card_deck)




func init():
	card_deck = Deck.shuffle_deck(Deck.create_deck())
	card_deck = Deck.divide_deck(card_deck, 4)
	print(card_deck)


