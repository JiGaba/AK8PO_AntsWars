using Godot;
using System;
using System.Collections.Generic;

public partial class ControlCastle : Control
{
	private BlackCastle _blackCastle;
	private RedCastle _redCastle;
	private Dictionary<int, string> _castlePath;
	public override void _Ready()
	{
	}

	
	public override void _Process(double delta)
	{
	}

	public void InitializeComponents()
	{
		_blackCastle = GetNode<BlackCastle>("../BlackCastle");
		_redCastle = GetNode<RedCastle>("../RedCastle");

		InitializeWallPath();
	}

	public void ActualizeComponents(AntHill antsNation)
	{
		switch(antsNation.CastleValue)
		{
			case > 20:
				SetTextureCastleFull(antsNation);
				break;
			case > 15 and <= 20:
				SetTexture(antsNation.Nation, GD.Load<Texture2D>(_castlePath[4]));
				break;
			case > 10 and <= 15:
				SetTexture(antsNation.Nation, GD.Load<Texture2D>(_castlePath[3]));
				break;
			case > 5 and <= 10:
				SetTexture(antsNation.Nation, GD.Load<Texture2D>(_castlePath[2]));
				break;
			case > 0 and <= 5:	
				SetTexture(antsNation.Nation, GD.Load<Texture2D>(_castlePath[1]));
				break;
			default:
				SetTexture(antsNation.Nation, null);
				break;
		}
	}

	private void InitializeWallPath()
	{
		_castlePath = new Dictionary<int, string>
		{
			{ 1, "res://images/castle_1.png" },
			{ 2, "res://images/castle_2.png" },
			{ 3, "res://images/castle_3.png" },
			{ 4, "res://images/castle_4.png" },
			{ 5, "res://images/castle_black_full.png" },
			{ 6, "res://images/castle_red_full.png" }
		};
	}

	private void SetTexture(Ants nation, Texture2D texture)
	{
		switch (nation)
		{
			case Ants.Black:
				_blackCastle.Texture = texture;
				break;
			case Ants.Red:
				_redCastle.Texture = texture;
				break;
		}
	}

	private void SetTextureCastleFull(AntHill antsNation)
	{
		if(antsNation.Nation.Equals(Ants.Black))
			SetTexture(antsNation.Nation, GD.Load<Texture2D>(_castlePath[5]));
		else
			SetTexture(antsNation.Nation, GD.Load<Texture2D>(_castlePath[6]));
	}
}
