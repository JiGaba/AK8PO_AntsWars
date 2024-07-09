using Godot;
using System;
using System.Collections.Generic;

public partial class ControlCards : Control
{
	private DeckOfCard _deckOfCard = new DeckOfCard();
	private CardBack _cardBack;
	private Card1 _card1;
	private Card2 _card2;
	private Card3 _card3;
	private Card4 _card4;
	private Card5 _card5;
	private Card6 _card6;
	private Card7 _card7;
	private Card8 _card8;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	public void InitializeComponents()
	{
		SetProcessInput(true);
		
		_cardBack = GetNode<CardBack>("../CardBack");
		_card1 = GetNode<Card1>("../Card1");
		_card2 = GetNode<Card2>("../Card2");
		_card3 = GetNode<Card3>("../Card3");
		_card4 = GetNode<Card4>("../Card4");
		_card5 = GetNode<Card5>("../Card5");
		_card6 = GetNode<Card6>("../Card6");
		_card7 = GetNode<Card7>("../Card7");
		_card8 = GetNode<Card8>("../Card8");
	}

	public void ActualizeBlackCards(AntHill antNation)
	{
		ActualizeCards(antNation, 1);
	}

	public void ActualizeRedCards(AntHill antNation)
	{
		ActualizeCards(antNation, 5);
	}

	public void ActualizeBackCard(int index)
	{
		Texture2D texture2D = GD.Load<Texture2D>(_deckOfCard.GetCardPath(index));
		SetTexture(0, texture2D);
	}

	public void ActualizeBackCardInactive(int index)
	{
		Texture2D texture2D = GD.Load<Texture2D>(_deckOfCard.GetCardInactivePath(index));
		SetTexture(0, texture2D);
	}

	private void ActualizeCards(AntHill antNation, int index)
	{
		Texture2D texture;
		var cardLocalIndex = 0;

		foreach (Card card in antNation.Cards)
		{
			if(antNation.IsCardUseable(cardLocalIndex))
			{
				texture = GD.Load<Texture2D>(_deckOfCard.GetCardPath(card.Id));
			}
			else
			{
				texture = GD.Load<Texture2D>(_deckOfCard.GetCardInactivePath(card.Id));
			}
			
			SetTexture(index, texture);
			index++;
			cardLocalIndex++;
		}
	}

	private void SetTexture(int index, Texture2D texture)
	{
		switch (index)
		{
			case 1:
				_card1.Texture = texture;
				break;
			case 2:
				_card2.Texture = texture;
				break;
			case 3:
				_card3.Texture = texture;
				break;
			case 4:
				_card4.Texture = texture;
				break;
			case 5:
				_card5.Texture = texture;
				break;
			case 6:
				_card6.Texture = texture;
				break;
			case 7:
				_card7.Texture = texture;
				break;
			case 8:
				_card8.Texture = texture;
				break;
			default:
				_cardBack.Texture = texture;
				break;
		}
	}
}
