using Godot;
using System;
using System.Collections.Generic;

public class DeckOfCard
{
    private List<Card> _cards;
    private Dictionary<int, string> _cardPictures;
    private Dictionary<int, string> _cardPicturesInactive;
    private Random _random;
    public DeckOfCard() 
    { 
        _random = new Random();
        InitializeDeck();
        InitializeCardPicturesDictionary();
        InitializeCardPicturesInactiveDictionary();
    }

    public Card GetRandomCard()
    {
        var cardIndex = _random.Next(0, _cards.Count);

        return _cards[cardIndex];
    }

    public string GetCardPath(int index)
    {
        return _cardPictures[index];
    }

    public string GetCardInactivePath(int index)
    {
        return _cardPicturesInactive[index];
    }

    private void InitializeDeck()
    {
        _cards = new List<Card>
        {
            new Card(1, new Price(ResourcesName.Weapons, 3), CardType.Attack, new Action(CardAction.Destroy, 5)),
            new Card(2, new Price(ResourcesName.Weapons, 5), CardType.Attack, new Action(CardAction.Destroy, 10)),
            new Card(3, new Price(ResourcesName.Weapons, 1), CardType.Attack, new Action(CardAction.DestroyWall, 5)),
            new Card(4, new Price(ResourcesName.Weapons, 2), CardType.Attack, new Action(CardAction.DestroyWall, 10)),
            new Card(5, new Price(ResourcesName.Weapons, 5), CardType.Attack, new Action(CardAction.DestroyCastle, 5)),
            new Card(6, new Price(ResourcesName.Weapons, 10), CardType.Attack, new Action(CardAction.DestroyCastle, 10)),
            new Card(7, new Price(ResourcesName.Magic, 3), CardType.Attack, new Action(CardAction.DestroyWeapons, 5)),
            new Card(8, new Price(ResourcesName.Magic, 3), CardType.Attack, new Action(CardAction.DestroyStone, 5)),
            new Card(9, new Price(ResourcesName.Magic, 3), CardType.Attack, new Action(CardAction.DestroyMagic, 5)),
            new Card(10, new Price(ResourcesName.Stone, 5), CardType.Defence, new Action(CardAction.BuildCastle, 5)),
            new Card(11, new Price(ResourcesName.Stone, 3), CardType.Defence, new Action(CardAction.BuildWall, 5)),
            new Card(12, new Price(ResourcesName.Weapons, 8), CardType.Defence, new Action(CardAction.AddWeaponsBuilder, 1)),
            new Card(13, new Price(ResourcesName.Stone, 8), CardType.Defence, new Action(CardAction.AddStoneBuilder, 1)),
            new Card(14, new Price(ResourcesName.Magic, 8), CardType.Defence, new Action(CardAction.AddMagicBuilder, 1)),
            new Card(15, new Price(ResourcesName.Magic, 3), CardType.Defence, new Action(CardAction.AddWeapons, 8)),
            new Card(16, new Price(ResourcesName.Magic, 3), CardType.Defence, new Action(CardAction.AddStone, 8)),
            new Card(17, new Price(ResourcesName.Magic, 3), CardType.Defence, new Action(CardAction.AddMagic, 8)),
            new Card(18, new Price(ResourcesName.Weapons, 8), CardType.Attack, new Action(CardAction.Abduction, 1))
        };
    }

    private void InitializeCardPicturesDictionary()
    {
        _cardPictures = new Dictionary<int, string>
        {
            { 0, "res://images/card_back.png" },
            { 1, "res://images/card_1.png" },
            { 2, "res://images/card_2.png" },
            { 3, "res://images/card_3.png" },
            { 4, "res://images/card_4.png" },
            { 5, "res://images/card_5.png" },
            { 6, "res://images/card_6.png" },
            { 7, "res://images/card_7.png" },
            { 8, "res://images/card_8.png" },
            { 9, "res://images/card_9.png" },
            { 10, "res://images/card_10.png" },
            { 11, "res://images/card_11.png" },
            { 12, "res://images/card_12.png" },
            { 13, "res://images/card_13.png" },
            { 14, "res://images/card_14.png" },
            { 15, "res://images/card_15.png" },
            { 16, "res://images/card_16.png" },
            { 17, "res://images/card_17.png" },
            { 18, "res://images/card_18.png" }
        };
    }

    private void InitializeCardPicturesInactiveDictionary()
    {
        _cardPicturesInactive = new Dictionary<int, string>
        {
            { 1, "res://images/card_1_grey.png" },
            { 2, "res://images/card_2_grey.png" },
            { 3, "res://images/card_3_grey.png" },
            { 4, "res://images/card_4_grey.png" },
            { 5, "res://images/card_5_grey.png" },
            { 6, "res://images/card_6_grey.png" },
            { 7, "res://images/card_7_grey.png" },
            { 8, "res://images/card_8_grey.png" },
            { 9, "res://images/card_9_grey.png" },
            { 10, "res://images/card_10_grey.png" },
            { 11, "res://images/card_11_grey.png" },
            { 12, "res://images/card_12_grey.png" },
            { 13, "res://images/card_13_grey.png" },
            { 14, "res://images/card_14_grey.png" },
            { 15, "res://images/card_15_grey.png" },
            { 16, "res://images/card_16_grey.png" },
            { 17, "res://images/card_17_grey.png" },
            { 18, "res://images/card_18_grey.png" }
        };
    }
}