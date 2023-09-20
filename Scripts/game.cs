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

    public static readonly IReadOnlyList<Card> Deck36 = GenerateDeck(new CardRank[]{
        CardRank.Ace, CardRank.Six, CardRank.Seven, CardRank.Eight, CardRank.Nine, CardRank.Ten, CardRank.Jack, CardRank.Queen, CardRank.King
    });

    public static readonly IReadOnlyList<Card> Deck52 = GenerateDeck(Enum.GetValues(typeof(CardRank)).Cast<CardRank>().ToArray());

    static IReadOnlyList<Card> GenerateDeck(IReadOnlyList<CardRank> ranks) =>
        Enum.GetValues(typeof(Suite)).Cast<Suite>()
            .SelectMany(suite => ranks.Select(rank => new Card(rank, suite)))
            .ToArray();

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
