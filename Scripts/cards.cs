using System;
using System.Collections.Generic;
using System.Linq;

namespace Neclor.PlayingCards;

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

    public static readonly IReadOnlyList<Card> Deck52 = GenerateDeck(Enum.GetValues<CardRank>());

    static IReadOnlyList<Card> GenerateDeck(IReadOnlyList<CardRank> ranks) =>
        Enum.GetValues<Suite>()
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
