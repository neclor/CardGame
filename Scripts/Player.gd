extends Node

# ranks

# 6                 king
# 5                 prince
# 4.5   - six       merchant
# 4     - man       citizen
#vvv
# 3     - fa        servant
#-
# 2                 poor man
# 1                  beggar
# 0                 dead








const max_rank = 6
const min_rank = 0

var in_game

var player_id
var player_name

var rank
var rank_frozen
var card



func increase_rank():
	if (!rank_frozen or rank != max_rank):
		match rank:
			3:
				print("")

			4.5:
				rank = 5

			_:
				rank += 1

func demote_rank():
	if (!rank_frozen):
		match rank:
			1:
				in_game = false
				print(player_name, " Loose")

			4.5:
				rank = 4

			_:
				rank -= 1







