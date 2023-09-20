using System;
using System.Collections.Generic;
using System.Linq;
using Neclor.PlayingCards;

namespace Neclor.CardGame;

public enum PlayerRank
{
    Dead = 0
    , Beggar = 10
    , Poor = 20
    , Servant = 25
    , Cictizen = 30
    , Merchant = 35
    , Prince = 40
    , King = 50
}

public class Player
{
    public string Name;

    public PlayerRank Rank = PlayerRank.Prince;

    public readonly List<Card> Kings = new();

    // return returned Cards
    public List<Card> Apply(Card card)
    {
        List<Card> returnedCards = new() { card };
        switch (card.Rank)
        {
            case CardRank.Ace:
                Rank = (PlayerRank)(Math.Min(((int)Rank / 10 + 1) * 10, (int)PlayerRank.King));
                break;
            case CardRank.Six:
                Rank = PlayerRank.Merchant;
                break;
            case CardRank.Jack:
                Rank = PlayerRank.Beggar;
                returnedCards.AddRange(Kings);
                Kings.Clear();
                break;
            case CardRank.King:
                returnedCards.Clear();
                Kings.Add(card);
                break;
        }
        return returnedCards;
    }
}


public class Game
{
    public List<Card> Deck;
    public List<Card> Trash = new();
    public readonly List<Player> Players = new();

    Card PullNextCard()
    {
        if (Deck.Count == 0)
        {
            Deck = Trash;
            Trash = new();
        }
        var card = Deck.First();
        Deck.RemoveAt(0);
        return card;
    }

    public Player Winner => Players.Count == 1 ? Players[0] : null;

    public void Round()
    {
        var pulledCards = Players.ToDictionary(p => p, p => PullNextCard());

        foreach (var (player, card) in pulledCards)
        {
            foreach (var returnedCard in player.Apply(card))
                Trash.Add(returnedCard);

            if (player.Rank is PlayerRank.Dead)
                Players.Remove(player);
        }
    }

    public Game()
    {
        var deck = Card.Deck52.ToArray();
        Random.Shared.Shuffle(deck);
        Deck = deck.ToList();
    }
}
