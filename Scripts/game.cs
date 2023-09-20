using System;
using System.Collections.Generic;
using System.Linq;

namespace Neclor.CardGame;

public enum CardRank
{
    Ace = 1
    , Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten
    , Jack = 11, Queen = 12, King = 13
}

public enum Suite
{
    Hearts              // ♥
    , Diamonds          // ♦
    , Clubs             // ♣
    , Spades            // ♠
}

public readonly struct Card
{
    public CardRank Rank { get; }
    public Suite Suite { get; }

    public static readonly IReadOnlyList<Card> Deck36 = new Card[36] {
        new(CardRank.Ace, Suite.Hearts)      , new(CardRank.Ace, Suite.Diamonds)    , new(CardRank.Ace, Suite.Clubs)     , new(CardRank.Ace, Suite.Spades)
        , new(CardRank.Six, Suite.Hearts)    , new(CardRank.Six, Suite.Diamonds)    , new(CardRank.Six, Suite.Clubs)     , new(CardRank.Six, Suite.Spades)
        , new(CardRank.Seven, Suite.Hearts)  , new(CardRank.Seven, Suite.Diamonds)  , new(CardRank.Seven, Suite.Clubs)   , new(CardRank.Seven, Suite.Spades)
        , new(CardRank.Eight, Suite.Hearts)  , new(CardRank.Eight, Suite.Diamonds)  , new(CardRank.Eight, Suite.Clubs)   , new(CardRank.Eight, Suite.Spades)
        , new(CardRank.Nine, Suite.Hearts)   , new(CardRank.Nine, Suite.Diamonds)   , new(CardRank.Nine, Suite.Clubs)    , new(CardRank.Nine, Suite.Spades)
        , new(CardRank.Ten, Suite.Hearts)    , new(CardRank.Ten, Suite.Diamonds)    , new(CardRank.Ten, Suite.Clubs)     , new(CardRank.Ten, Suite.Spades)
        , new(CardRank.Jack, Suite.Hearts)   , new(CardRank.Jack, Suite.Diamonds)   , new(CardRank.Jack, Suite.Clubs)    , new(CardRank.Jack, Suite.Spades)
        , new(CardRank.Queen, Suite.Hearts)  , new(CardRank.Queen, Suite.Diamonds)  , new(CardRank.Queen, Suite.Clubs)   , new(CardRank.Queen, Suite.Spades)
        , new(CardRank.King, Suite.Hearts)   , new(CardRank.King, Suite.Diamonds)   , new(CardRank.King, Suite.Clubs)    , new(CardRank.King, Suite.Spades)
    };

    public static readonly IReadOnlyList<Card> Deck52 = new Card[52] {
        new(CardRank.Ace, Suite.Hearts)      , new(CardRank.Ace, Suite.Diamonds)    , new(CardRank.Ace, Suite.Clubs)     , new(CardRank.Ace, Suite.Spades)
        , new(CardRank.Two, Suite.Hearts)    , new(CardRank.Two, Suite.Diamonds)    , new(CardRank.Two, Suite.Clubs)     , new(CardRank.Two, Suite.Spades)
        , new(CardRank.Three, Suite.Hearts)  , new(CardRank.Three, Suite.Diamonds)  , new(CardRank.Three, Suite.Clubs)   , new(CardRank.Three, Suite.Spades)
        , new(CardRank.Four, Suite.Hearts)   , new(CardRank.Four, Suite.Diamonds)   , new(CardRank.Four, Suite.Clubs)    , new(CardRank.Four, Suite.Spades)
        , new(CardRank.Five, Suite.Hearts)   , new(CardRank.Five, Suite.Diamonds)   , new(CardRank.Five, Suite.Clubs)    , new(CardRank.Five, Suite.Spades)
        , new(CardRank.Six, Suite.Hearts)    , new(CardRank.Six, Suite.Diamonds)    , new(CardRank.Six, Suite.Clubs)     , new(CardRank.Six, Suite.Spades)
        , new(CardRank.Seven, Suite.Hearts)  , new(CardRank.Seven, Suite.Diamonds)  , new(CardRank.Seven, Suite.Clubs)   , new(CardRank.Seven, Suite.Spades)
        , new(CardRank.Eight, Suite.Hearts)  , new(CardRank.Eight, Suite.Diamonds)  , new(CardRank.Eight, Suite.Clubs)   , new(CardRank.Eight, Suite.Spades)
        , new(CardRank.Nine, Suite.Hearts)   , new(CardRank.Nine, Suite.Diamonds)   , new(CardRank.Nine, Suite.Clubs)    , new(CardRank.Nine, Suite.Spades)
        , new(CardRank.Ten, Suite.Hearts)    , new(CardRank.Ten, Suite.Diamonds)    , new(CardRank.Ten, Suite.Clubs)     , new(CardRank.Ten, Suite.Spades)
        , new(CardRank.Jack, Suite.Hearts)   , new(CardRank.Jack, Suite.Diamonds)   , new(CardRank.Jack, Suite.Clubs)    , new(CardRank.Jack, Suite.Spades)
        , new(CardRank.Queen, Suite.Hearts)  , new(CardRank.Queen, Suite.Diamonds)  , new(CardRank.Queen, Suite.Clubs)   , new(CardRank.Queen, Suite.Spades)
        , new(CardRank.King, Suite.Hearts)   , new(CardRank.King, Suite.Diamonds)   , new(CardRank.King, Suite.Clubs)    , new(CardRank.King, Suite.Spades)
    };


    public Card(CardRank rank, Suite suite) =>
        (Rank, Suite) = (rank, suite);
}

public static class CardExtensions
{
    public static string ToSymbol(this Suite suite) =>
        suite switch
        {
            Suite.Hearts => "♥",
            Suite.Diamonds => "♦",
            Suite.Clubs => "♣",
            Suite.Spades => "♠",
            _ => throw new ArgumentException(nameof(suite))
        };
}

public class Player
{
    public string Name;

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

    public PlayerRank Rank;

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
        foreach (var player in Players)
        {
            var card = PullNextCard();

            foreach (var returnedCard in player.Apply(card))
                Trash.Add(returnedCard);
        }
    }

    public Game()
    {
        var deck = Card.Deck52.ToArray();
        Random.Shared.Shuffle(deck);
        Deck = deck.ToList();

    }
}
