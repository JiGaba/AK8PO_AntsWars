using Godot;
using System;

public class Resources
{
    public ResourcesName Name { get; set; }
    public int Value { get; set; }
    public Resources(ResourcesName resourcesName, int value) 
    { 
        Name = resourcesName;
        Value = value;
    }  
}