using Godot;
using System;
using System.Linq;

public partial class ControlLabel : Control
{
	private Label _blackWeaponsLabel;
	private Label _blackStoneLabel;
	private Label _blackMagicLabel;
	private Label _redWeaponsLabel;
	private Label _redStoneLabel;
	private Label _redMagicLabel;
	private Label _blackCastleLabel;
	private Label _blackWallLabel;
	private Label _redCastleLabel;
	private Label _redWallLabel;
	private const string _separatedSymbol = " / +";
	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{
	}

	public void InitializeComponents()
	{
		_blackWeaponsLabel = GetNode<Label>("../BlackWeaponsLabel");
		_blackStoneLabel = GetNode<Label>("../BlackStoneLabel");
		_blackMagicLabel = GetNode<Label>("../BlackMagicLabel");
		_redWeaponsLabel = GetNode<Label>("../RedWeaponsLabel");
		_redStoneLabel = GetNode<Label>("../RedStoneLabel");
		_redMagicLabel = GetNode<Label>("../RedMagicLabel");

		_blackCastleLabel = GetNode<Label>("../BlackCastleLabel");
		_blackWallLabel = GetNode<Label>("../BlackWallLabel");
		_redCastleLabel = GetNode<Label>("../RedCastleLabel");
		_redWallLabel = GetNode<Label>("../RedWallLabel");
	}

	public void ActualizeLabels(Engine engine)
	{
		ActualizeResources(engine);
		ActualizeBuilding(engine);
	}

	private void ActualizeResources(Engine engine)
	{
		_blackWeaponsLabel.Text = engine.BlackNation.Resources.Where(r => r.Name == ResourcesName.Weapons).First().Value.ToString();
		_blackWeaponsLabel.Text += _separatedSymbol;
		_blackWeaponsLabel.Text += engine.BlackNation.Builders.Where(r => r.Name == ResourcesName.Weapons).First().Value.ToString();

		_blackStoneLabel.Text = engine.BlackNation.Resources.Where(r => r.Name == ResourcesName.Stone).First().Value.ToString();
		_blackStoneLabel.Text += _separatedSymbol;
		_blackStoneLabel.Text += engine.BlackNation.Builders.Where(r => r.Name == ResourcesName.Stone).First().Value.ToString();

		_blackMagicLabel.Text = engine.BlackNation.Resources.Where(r => r.Name == ResourcesName.Magic).First().Value.ToString();
		_blackMagicLabel.Text += _separatedSymbol;
		_blackMagicLabel.Text += engine.BlackNation.Builders.Where(r => r.Name == ResourcesName.Magic).First().Value.ToString();

		_redWeaponsLabel.Text = engine.RedNation.Resources.Where(r => r.Name == ResourcesName.Weapons).First().Value.ToString();
		_redWeaponsLabel.Text += _separatedSymbol;
		_redWeaponsLabel.Text += engine.RedNation.Builders.Where(r => r.Name == ResourcesName.Weapons).First().Value.ToString();

		_redStoneLabel.Text = engine.RedNation.Resources.Where(r => r.Name == ResourcesName.Stone).First().Value.ToString();
		_redStoneLabel.Text += _separatedSymbol;
		_redStoneLabel.Text += engine.RedNation.Builders.Where(r => r.Name == ResourcesName.Stone).First().Value.ToString();

		_redMagicLabel.Text = engine.RedNation.Resources.Where(r => r.Name == ResourcesName.Magic).First().Value.ToString();
		_redMagicLabel.Text += _separatedSymbol;
		_redMagicLabel.Text += engine.RedNation.Builders.Where(r => r.Name == ResourcesName.Magic).First().Value.ToString();
	}
	
	private void ActualizeBuilding(Engine engine)
	{
		_blackCastleLabel.Text = engine.BlackNation.CastleValue.ToString();
		_blackWallLabel.Text = engine.BlackNation.WallValue.ToString();
		_redCastleLabel.Text = engine.RedNation.CastleValue.ToString();
		_redWallLabel.Text = engine.RedNation.WallValue.ToString();
	}
}
