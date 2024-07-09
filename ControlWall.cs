using Godot;
using System;
using System.Collections.Generic;

public partial class ControlWall : Control
{
	private BlackWall _blackWall;
	private RedWall _redWall;	
	private Dictionary<int, string> _wallPath;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	public void InitializeComponents()
	{
		_blackWall = GetNode<BlackWall>("../BlackWall");
		_redWall = GetNode<RedWall>("../RedWall");

		InitializeWallPath();
	}

	public void ActualizeComponents(AntHill antsNation)
	{
		switch(antsNation.WallValue)
		{
			case > 20:
				SetTexture(antsNation.Nation, GD.Load<Texture2D>(_wallPath[5]));
				break;
			case > 15 and <= 20:
				SetTexture(antsNation.Nation, GD.Load<Texture2D>(_wallPath[4]));
				break;
			case > 10 and <= 15:
				SetTexture(antsNation.Nation, GD.Load<Texture2D>(_wallPath[3]));
				break;
			case > 5 and <= 10:
				SetTexture(antsNation.Nation, GD.Load<Texture2D>(_wallPath[2]));
				break;
			case > 0 and <= 5:	
				SetTexture(antsNation.Nation, GD.Load<Texture2D>(_wallPath[1]));
				break;
			default:
				SetTexture(antsNation.Nation, null);
				break;
		}
	}

	private void InitializeWallPath()
	{
		_wallPath = new Dictionary<int, string>
		{
			{ 1, "res://images/wall_1.png" },
			{ 2, "res://images/wall_2.png" },
			{ 3, "res://images/wall_3.png" },
			{ 4, "res://images/wall_4.png" },
			{ 5, "res://images/wall_5.png" }
		};
	}

	private void SetTexture(Ants nation, Texture2D texture)
	{
		switch (nation)
		{
			case Ants.Black:
				_blackWall.Texture = texture;
				break;
			case Ants.Red:
				_redWall.Texture = texture;
				break;
		}
	}
}
