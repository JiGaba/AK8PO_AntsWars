using Godot;
using System;

public class Card
{
    public int Id {  get; set; }
    public Price Price { get; set; }
    public CardType Type { get; set; }
    public Action Action { get; set; }
    public Card(int id, Price price, CardType type, Action action)
    {
        Id = id;
        Price = price;
        Type = type;
        Action = action;
    }
}