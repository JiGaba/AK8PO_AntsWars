using Godot;
using System;

public class Price
{
    public ResourcesName Resources {  get; set; }
    public int Count {  get; set; }
    public Price(ResourcesName resources, int count) 
    {
        Resources = resources;
        Count = count;
    }
}