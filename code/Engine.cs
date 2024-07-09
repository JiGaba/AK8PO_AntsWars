using Godot;
using System;
using System.Collections.Generic;

public class Engine
{
    public AntHill RedNation { get; set; }
    public AntHill BlackNation { get; set; }
    public Ants ActualMove { get; set; }
    public AntHill GetActiveNation { get { return ActualMove == Ants.Red ? RedNation : BlackNation; }}
    private const int _castleValue = 25;
    private const int _wallValue = 15;
    private Random _random;
    private AntHill GetInActiveNation { get { return ActualMove == Ants.Black ? RedNation : BlackNation; } }
    public Engine() 
    {
        RedNation = InitializeNation(Ants.Red);
        BlackNation = InitializeNation(Ants.Black);
        ActualMove = Ants.Black;

        _random = new Random();
    }

    public bool IsEnemyLose()
    {
        return ActualMove == Ants.Black ? RedNation.Lose : BlackNation.Lose;
    }

    public bool IsCardUseable(int index)
    {
        return GetActiveNation.IsCardUseable(index);
    }

    public void UseCard(int index)
    {
        switch (GetActiveNation.Cards[index].Type)
        {
            case CardType.Attack:
                GetInActiveNation.UseCard(GetActiveNation.Cards[index]);
                break;
            case CardType.Defence:
                GetActiveNation.UseCard(GetActiveNation.Cards[index]);
                break;
        }

        GetActiveNation.RemoveResources(GetActiveNation.Cards[index]);
        GetActiveNation.GetNewCard(index);
    }

    public void PutCardDown(int index)
    {
        GetActiveNation.PutCardDown(index);
    }

    public void ChangeMove()
    {
        ActualMove = ActualMove == Ants.Red ? Ants.Black : Ants.Red;
    }

    public int GetCardIndex()
    {
        var usedIds = new List<int>();

        while (true)
        {
            var cardId = _random.Next(0, RedNation.Cards.Count);
            if(IsCardUseable(cardId)) return cardId;

            if (usedIds.Contains(cardId)) continue;
            usedIds.Add(cardId);

            if (usedIds.Count == RedNation.Cards.Count) break;
        }

        return -1;
    }

    private AntHill InitializeNation(Ants nation)
    {
        return new AntHill
        (
            _castleValue,
            _wallValue,
            nation
        );
    }
}