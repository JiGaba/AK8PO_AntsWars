using Godot;
using System;
using System.Collections.Generic;

public partial class VictoryBanner : Sprite2D
{
	private Dictionary<Ants, string> _victoryPictures;
	public override void _Ready()
	{
		_victoryPictures = new Dictionary<Ants, string>
		{
            { Ants.Black, "res://images/win_black.png" },
            { Ants.Red, "res://images/win_red.png" }
        };
	}

	public override void _Process(double delta)
	{
	}

	public void SetVictory(Ants ants)
	{
		this.Texture = GD.Load<Texture2D>(_victoryPictures[ants]);
	}

	public void NullVictory()
	{
		this.Texture = null;
	}
}
