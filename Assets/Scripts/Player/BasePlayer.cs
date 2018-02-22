using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BasePlayer : BaseClass 
{

	private string _name;
	private BaseClass _class = new BaseClass();
	private List<BaseStat> _playerStats = new List<BaseStat>();
	private int _xp;
	private int _money;
	private int _followers;
	private List<BaseItem> _equippedItems = new List<BaseItem>();
	private List<BaseItem> _inventory = new List<BaseItem>();
	private List<Quest> _completedQuests = new List<Quest>();
	private Image _portrait;

	public string PlayerName
	{
		get { return _name; }
		set { _name = value; }
	}

	public BaseClass PlayerClass
	{
		get { return _class; }
		set { _class = value; }
	}

	public List<BaseStat> PlayerStats
	{
		get { return _playerStats; }
		set { _playerStats = value; }
	}

	public int PlayerXP
	{
		get { return _xp; }
		set { _xp = value; }
	}

	public int PlayerMoney
	{
		get { return _money; }
		set { _money = value; }
	}

	public int PlayerFollowers
	{
		get { return _followers; }
		set { _followers = value; }
	}

	public List<BaseItem> PlayerEquippedItems
	{
		get { return _equippedItems; }
		set { _equippedItems = value; }
	}

	public List<BaseItem> PlayerInventory
	{
		get { return _inventory; }
		set { _inventory = value; }
	}

	public List<Quest> PlayerCompletedQuests
	{
		get { return _completedQuests; }
		set { _completedQuests = value; }
	}

	public Image PlayerPortrait
	{
		get { return _portrait; }
		set { _portrait = value; }
	}

}
