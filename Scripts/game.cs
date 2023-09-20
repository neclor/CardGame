using System;
using System.Collection.Generic;

namespace Neclor.CardGame;

public readonly struct Card
{
    public enum Rank {
        Ace = 1
        , Two, Three, Four, Five, Size, Seven, Eight. Nine, Ten
        , Jack = 11, Queen = 12, King = 13
    }

    public enum Suite {
        Hearts              // ♥
        , Diamonds          // ♦
        , Clubs             // ♣
        , Spades            // ♠
    }

    public Rank Rank { get; }
    public Suite Suite { get; }

    public static readonly IReadOnlyList<Card> Deck36 = new Card[36] {
        new(Rank.Ace, Suite.Hearts)      , new(Rank.Two, Suite.Diamonds)    , new(Rank.Two, Suite.Clubs)     , new(Rank.Two, Suite.Spades)
        , new(Rank.Six, Suite.Hearts)    , new(Rank.Six, Suite.Diamonds)    , new(Rank.Six, Suite.Clubs)     , new(Rank.Six, Suite.Spades)
        , new(Rank.Seven, Suite.Hearts)  , new(Rank.Seven, Suite.Diamonds)  , new(Rank.Seven, Suite.Clubs)   , new(Rank.Seven, Suite.Spades)
        , new(Rank.Eight, Suite.Hearts)  , new(Rank.Eight, Suite.Diamonds)  , new(Rank.Eight, Suite.Clubs)   , new(Rank.Eight, Suite.Spades)
        , new(Rank.Nine, Suite.Hearts)   , new(Rank.Nine, Suite.Diamonds)   , new(Rank.Nine, Suite.Clubs)    , new(Rank.Nine, Suite.Spades)
        , new(Rank.Ten, Suite.Hearts)    , new(Rank.Ten, Suite.Diamonds)    , new(Rank.Ten, Suite.Clubs)     , new(Rank.Ten, Suite.Spades)
        , new(Rank.Jack, Suite.Hearts)   , new(Rank.Jack, Suite.Diamonds)   , new(Rank.Jack, Suite.Clubs)    , new(Rank.Jack, Suite.Spades)
        , new(Rank.Queen, Suite.Hearts)  , new(Rank.Queen, Suite.Diamonds)  , new(Rank.Queen, Suite.Clubs)   , new(Rank.Queen, Suite.Spades)
        , new(Rank.King, Suite.Hearts)   , new(Rank.King, Suite.Diamonds)   , new(Rank.King, Suite.Clubs)    , new(Rank.King, Suite.Spades)
    };

    public static readonly IReadOnlyList<Card> Deck52 = new Card[52] {
        new(Rank.Ace, Suite.Hearts)      , new(Rank.Two, Suite.Diamonds)    , new(Rank.Two, Suite.Clubs)     , new(Rank.Two, Suite.Spades)
        , new(Rank.Two, Suite.Hearts)    , new(Rank.Two, Suite.Diamonds)    , new(Rank.Two, Suite.Clubs)     , new(Rank.Two, Suite.Spades)
        , new(Rank.Three, Suite.Hearts)  , new(Rank.Three, Suite.Diamonds)  , new(Rank.Three, Suite.Clubs)   , new(Rank.Three, Suite.Spades)
        , new(Rank.Four, Suite.Hearts)   , new(Rank.Four, Suite.Diamonds)   , new(Rank.Four, Suite.Clubs)    , new(Rank.Four, Suite.Spades)
        , new(Rank.Five, Suite.Hearts)   , new(Rank.Five, Suite.Diamonds)   , new(Rank.Five, Suite.Clubs)    , new(Rank.Five, Suite.Spades)
        , new(Rank.Six, Suite.Hearts)    , new(Rank.Six, Suite.Diamonds)    , new(Rank.Six, Suite.Clubs)     , new(Rank.Six, Suite.Spades)
        , new(Rank.Seven, Suite.Hearts)  , new(Rank.Seven, Suite.Diamonds)  , new(Rank.Seven, Suite.Clubs)   , new(Rank.Seven, Suite.Spades)
        , new(Rank.Eight, Suite.Hearts)  , new(Rank.Eight, Suite.Diamonds)  , new(Rank.Eight, Suite.Clubs)   , new(Rank.Eight, Suite.Spades)
        , new(Rank.Nine, Suite.Hearts)   , new(Rank.Nine, Suite.Diamonds)   , new(Rank.Nine, Suite.Clubs)    , new(Rank.Nine, Suite.Spades)
        , new(Rank.Ten, Suite.Hearts)    , new(Rank.Ten, Suite.Diamonds)    , new(Rank.Ten, Suite.Clubs)     , new(Rank.Ten, Suite.Spades)
        , new(Rank.Jack, Suite.Hearts)   , new(Rank.Jack, Suite.Diamonds)   , new(Rank.Jack, Suite.Clubs)    , new(Rank.Jack, Suite.Spades)
        , new(Rank.Queen, Suite.Hearts)  , new(Rank.Queen, Suite.Diamonds)  , new(Rank.Queen, Suite.Clubs)   , new(Rank.Queen, Suite.Spades)
        , new(Rank.King, Suite.Hearts)   , new(Rank.King, Suite.Diamonds)   , new(Rank.King, Suite.Clubs)    , new(Rank.King, Suite.Spades)
    };


    public Card(Rank rank, Suite suite) =>
        (Rank, Suite) = (rank suite);
}

public static class CardExtensions {
    public string string ToString(this Card.Suite suite) =>
        suite switch {
            Card.Suite.Hearts => "♥",
            Card.Suite.Diamonds => "♦",
            Card.Suite.Clubs => "♣",
            Card.Suite.Spades => "♠"
        };
}

public class Game
{
}
