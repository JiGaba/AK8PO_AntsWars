using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class AntHill
{
    public int CastleValue { get; set; }
    public int WallValue { get; set; }
    public Ants Nation { get; set; }
    public List<Card> Cards { get; set; }
    public List<Resources> Resources { get; set; }
    public List<Builder> Builders { get; set; }
    public bool Lose { get {  return CastleValue <= 0; } }
    private const int _cardCount = 4;
    private DeckOfCard _deckOfCard { get; set; }
    public AntHill(int castleValue, int wallValue, Ants nation) 
    {
        CastleValue = castleValue;
        WallValue = wallValue;
        Nation = nation;

        _deckOfCard = new DeckOfCard();
        InitializeResources();
        InitializeBuilders();
        GenerateCardStarterPack();
    }
    public bool IsCardUseable(int index) 
    {
        var card = Cards[index];
        
        return card.Price.Count <= Resources.Where(r => r.Name.Equals(card.Price.Resources)).First().Value;
    }
    public void UseCard(Card card)
    {
        switch (card.Action.Activity)
        {
            case CardAction.Destroy:
                ActionDestroy(card);
                break;
            case CardAction.DestroyCastle:
                ActionDestroyCastle(card);
                break;
            case CardAction.DestroyWall:
                ActionDestroyWall(card);
                break;
            case CardAction.DestroyWeapons:
                ActionDestroyWeapons(card);
                break;
            case CardAction.DestroyStone:
                ActionDestroyStone(card);
                break;
            case CardAction.DestroyMagic:
                ActionDestroyMagic(card);
                break;
            case CardAction.BuildCastle:
                CastleValue += card.Action.Value;
                break;
            case CardAction.BuildWall:
                WallValue += card.Action.Value;
                break;
            case CardAction.AddWeaponsBuilder:
                ActionAddWeaponsBuilder(card);
                break;
            case CardAction.AddStoneBuilder:
                ActionAddStoneBuilder(card);
                break;
            case CardAction.AddMagicBuilder:
                ActionAddMagicBuilder(card);
                break;
            case CardAction.AddWeapons:
                ActionAddWeapons(card);
                break;
            case CardAction.AddStone:
                ActionAddStone(card);
                break;
            case CardAction.AddMagic:
                ActionAddMagic(card);
                break;
            case CardAction.Abduction:
                Builders.ForEach(b => b.Value -= b.Value == 1 ? 0 : card.Action.Value);
                break;
        }
    }
    public void PutCardDown(int index)
    {
        GetNewCard(index);
    }
    public void GetNewCard(int index)
    {
        Cards[index] = GenerateNewCard();
    }
    public void AddResources()
    {
        foreach(var res in Resources)
        {
            var builder = Builders.Where(b => b.Name == res.Name).First();
            res.Value += builder.Value;
        }
    }
    public void RemoveResources(Card card)
    {
        var res = Resources.Where(r => r.Name == card.Price.Resources).First();
        res.Value -= card.Price.Count;
    }
    private void InitializeResources()
    {
        Resources = new List<Resources>
        {
            new Resources (ResourcesName.Weapons, 10),
            new Resources (ResourcesName.Stone, 10),
            new Resources (ResourcesName.Magic, 10)
        };
    }
    private void InitializeBuilders()
    {
        Builders = new List<Builder>
        {
            new Builder(ResourcesName.Weapons, 2),
            new Builder(ResourcesName.Stone, 2),
            new Builder(ResourcesName.Magic, 2)
        };
    }
    private void GenerateCardStarterPack()
    {
        Cards = new List<Card>();
        
        for(int i = 0; i < _cardCount; i++)
        {
            Cards.Add(GenerateNewCard());
        }
    }
    private Card GenerateNewCard() 
    {
        return _deckOfCard.GetRandomCard();
    }
    private void ActionDestroy(Card card)
    {
        WallValue -= card.Action.Value;

        if (WallValue < 0)
        {
            var tempVal = WallValue;
            WallValue = 0;
            CastleValue -= Math.Abs(tempVal);
            if (CastleValue < 0)
                CastleValue = 0;
        } 
    }
    private void ActionDestroyCastle(Card card)
    {
        CastleValue -= card.Action.Value;

        if(CastleValue < 0)
            CastleValue = 0;
    }
    private void ActionDestroyWall(Card card)
    {
        WallValue -= card.Action.Value;

        if (WallValue < 0)
            WallValue = 0;
    }
    private void ActionDestroyWeapons(Card card)
    {
        var resDesWeapons = Resources.First(r => r.Name == ResourcesName.Weapons);
        resDesWeapons.Value -= card.Action.Value;

        if (resDesWeapons.Value < 0)
            resDesWeapons.Value = 0;
    }
    private void ActionDestroyStone(Card card)
    {
        var resDesStone = Resources.First(r => r.Name == ResourcesName.Stone);
        resDesStone.Value -= card.Action.Value;

        if (resDesStone.Value < 0)
            resDesStone.Value = 0;
    }
    private void ActionDestroyMagic(Card card)
    {
        var resDesMagic = Resources.First(r => r.Name == ResourcesName.Magic);
        resDesMagic.Value -= card.Action.Value;
        
        if(resDesMagic.Value < 0)
            resDesMagic.Value = 0;
    }
    private void ActionAddWeaponsBuilder(Card card)
    {
        var builderWeapons = Builders.First(b => b.Name == ResourcesName.Weapons);
        builderWeapons.Value += card.Action.Value;
    }
    private void ActionAddStoneBuilder(Card card)
    {
        var builderStone = Builders.First(b => b.Name == ResourcesName.Stone);
        builderStone.Value += card.Action.Value;
    }
    private void ActionAddMagicBuilder(Card card)
    {
        var builderMagic = Builders.First(b => b.Name == ResourcesName.Magic);
        builderMagic.Value += card.Action.Value;
    }
    private void ActionAddWeapons(Card card)
    {
        var resWeapons = Resources.First(r => r.Name == ResourcesName.Weapons);
        resWeapons.Value += card.Action.Value;
    }
    private void ActionAddStone(Card card)
    {
        var resStone = Resources.First(r => r.Name == ResourcesName.Stone);
        resStone.Value += card.Action.Value;
    }
    private void ActionAddMagic(Card card)
    {
        var resMagic = Resources.First(r => r.Name == ResourcesName.Magic);
        resMagic.Value += card.Action.Value;
    }
}