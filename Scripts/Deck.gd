extends Node

const card_suits = ["Clubs", "Diamonds", "Hearts", "Spades"]
const card_values = ["A", "R", "Q", "J", 10, 9, 8, 7, 6, 5, 4, 3, 2]

func create_deck():
	var array = []

	for card_suit in card_suits:
		for card_value in card_values:
			array.append([card_suit, card_value])

	return array

func shuffle_deck(deck):
	var deck_size = deck.size()
	var card

	for i in range(0, deck_size):
		var e = randi_range(i, deck_size - 1)

		card = deck[i]
		deck[i] = deck[e]
		deck[e] = card

	return deck

func divide_deck(deck, number_stacks):
	var stacks = []
	var number_cards

	for i in range(number_stacks, 0, -1):
		var deck_size = deck.size()
		number_cards = deck_size / i

		if (deck_size % i != 0):
			number_cards += 1

		var stack = deck.slice(0, number_cards)
		stacks.append(stack)

		deck = deck.slice(number_cards, deck_size)

	return stacks
