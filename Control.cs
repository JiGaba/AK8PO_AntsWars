using Godot;
using System;
using System.Linq;
using System.Threading;

public partial class Control : Godot.Control
{
	private Engine _engine;
	private ControlLabel _gameLabels;
	private ControlCards _controlCards;
	private ControlCastle _controlCastle;
	private ControlWall _controlWall;
	private VictoryBanner _victoryBanner;
	private Rect2 _card1Draw;
	private Rect2 _card2Draw;
	private Rect2 _card3Draw;
	private Rect2 _card4Draw;
	private Rect2 _startGameDraw;
	private bool _playerAllow;
	private bool _startGame;
	bool _actualizeAllow = false;
	int _tick = 0;
	public override void _Ready()
	{
		
		_playerAllow = true;
		_startGame = false;
		SetProcessInput(true);
		InitializeComponents();
	}

	public override void _Process(double delta)
	{
		_tick++;
		if(_tick == 250 && _actualizeAllow)
		{
			_playerAllow = true;
			_actualizeAllow = false;
			AiMove();
		} 
	}

    public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && _playerAllow)
		{
			MouseLeftClick(mouseEvent);
			MouseRightClick(mouseEvent);	
		}
	}

	private void InitializeComponents()
	{
		_gameLabels = GetNode<ControlLabel>("../ControlLabel");
		_controlCards = GetNode<ControlCards>("../ControlCards");
		_controlCastle = GetNode<ControlCastle>("../ControlCastle");
		_controlWall = GetNode<ControlWall>("../ControlWall");
		_victoryBanner = GetNode<VictoryBanner>("../VictoryBanner");

		_gameLabels.InitializeComponents();
		_controlCards.InitializeComponents();
		_controlCastle.InitializeComponents();
		_controlWall.InitializeComponents();

		_card1Draw = new Rect2(20,680,120,200);
		_card2Draw = new Rect2(160,680,120,200);
		_card3Draw = new Rect2(300,680,120,200);
		_card4Draw = new Rect2(440,680,120,200);
		_startGameDraw = new Rect2(580,720,120,120);

		_victoryBanner.NullVictory();
	}	

	private void MouseLeftClick(InputEventMouseButton mouseEvent)
	{
		if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left && _playerAllow)
		{
			Vector2 mousePosition = mouseEvent.Position;
			int index = GetMouseLeftClickIndex(mousePosition);

			if(index >= 0 && _engine.IsCardUseable(index))
				MouseLeftClickUseCard(index);
		}
	}

	private int GetMouseLeftClickIndex(Vector2 mousePosition)
	{
		if (_startGameDraw.HasPoint(mousePosition))
		{
			StartNewGame();
		}
		else if (_card1Draw.HasPoint(mousePosition) && _startGame)
		{
			return 0;
		}
		else if (_card2Draw.HasPoint(mousePosition) && _startGame)
		{
			return 1;
		}
		else if (_card3Draw.HasPoint(mousePosition) && _startGame)
		{
			return 2;
		}
		else if (_card4Draw.HasPoint(mousePosition) && _startGame)
		{
			return 3;
		}

		return -1;
	}

	private void MouseLeftClickUseCard(int index)
	{
		_controlCards.ActualizeBackCard(_engine.BlackNation.Cards.ElementAt(index).Id);
		_engine.UseCard(index);
		ActualizeGameField();

		if(_engine.IsEnemyLose())
		{
			_victoryBanner.SetVictory(Ants.Black);
			_playerAllow = true;
			_startGame = false;
		}
		else
		{
			_playerAllow = false;
			_tick = 0;
			_actualizeAllow = true;
		}
	}

	private void MouseRightClick(InputEventMouseButton mouseEvent)
	{
		if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Right && _playerAllow && _startGame)
		{
			Vector2 mousePosition = mouseEvent.Position;
			int index = GetMouseRightClickIndex(mousePosition);			

			if(index >= 0)
				MouseRightClickPutTheCardDown(index);	
		}
	}

	private int GetMouseRightClickIndex(Vector2 mousePosition)
	{
		if (_card1Draw.HasPoint(mousePosition))
		{
			return 0;	
		}
		else if (_card2Draw.HasPoint(mousePosition))
		{
			return 1;
		}
		else if (_card3Draw.HasPoint(mousePosition))
		{
			return 2;
		}
		else if (_card4Draw.HasPoint(mousePosition))
		{
			return 3;
		}

		return -1;
	}
	private void MouseRightClickPutTheCardDown(int index)
	{
		_controlCards.ActualizeBackCardInactive(_engine.BlackNation.Cards.ElementAt(index).Id);
		_engine.BlackNation.PutCardDown(index);	

		ActualizeGameField();

		_playerAllow = false;
		_tick = 0;
		_actualizeAllow = true;
	}

	private void StartNewGame()
	{
		_playerAllow = true;
		_startGame = true;
		_engine = new Engine();

		_victoryBanner.NullVictory();
		_controlCards.ActualizeBackCard(0);

		ActualizeGameField();	
	}

	private void ActualizeGameField()
	{
		_gameLabels.ActualizeLabels(_engine);
		_controlCards.ActualizeBlackCards(_engine.BlackNation);
		_controlCards.ActualizeRedCards(_engine.RedNation);
		_controlWall.ActualizeComponents(_engine.BlackNation);
		_controlWall.ActualizeComponents(_engine.RedNation);
		_controlCastle.ActualizeComponents(_engine.BlackNation);
		_controlCastle.ActualizeComponents(_engine.RedNation);
	}

	private void AiMove()
	{
		_engine.ChangeMove();
		var cardIndex = _engine.GetCardIndex();

		if(cardIndex > -1)
		{
			_controlCards.ActualizeBackCard(_engine.RedNation.Cards.ElementAt(cardIndex).Id);
			_engine.UseCard(cardIndex);
		}
		else
		{
			Random r = new Random();
			var index = r.Next(0, 4);

			_controlCards.ActualizeBackCardInactive(_engine.RedNation.Cards.ElementAt(index).Id);
			_engine.RedNation.PutCardDown(index);	
		}

		AiCheckVictory();
	}

	private void AiCheckVictory()
	{
		if(_engine.IsEnemyLose())
		{
			_victoryBanner.SetVictory(Ants.Red);
			_playerAllow = true;
			_startGame = false;
		}
		else
		{
			_engine.BlackNation.AddResources();
			_engine.RedNation.AddResources();
			_engine.ChangeMove();
			
			ActualizeGameField();
		}
	}
}
