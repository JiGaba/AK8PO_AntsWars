using Godot;
using System;

public class Action
{
    public CardAction Activity { get; set; }
    public int Value { get; set; }
    public Action(CardAction action, int value)
    {
        Activity = action; 
        Value = value; 
    }
}