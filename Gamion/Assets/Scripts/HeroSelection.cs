using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public enum Hero
	{
		Barbarian,
		Chan,
		Jack,
		John,
		Josh,
		Aname
	}

	public class HeroSelection : MonoBehaviour {
		
		private static HeroSelection _instance;

		public string SelectedHero;
		public Image HeroIconHolder;
		public Image HeroIconPreview;
		public Text HeroName;
		
		public RectTransform Agility;
		public RectTransform Power;
		public RectTransform Health;
		
		public RectTransform AgilityPreview;
		public RectTransform PowerPreview;
		public RectTransform HealthPreview;

		public Sprite Barbarian;
		public Sprite Chan;
		public Sprite Jack;
		public Sprite John;
		public Sprite Josh;
		public Sprite Aname;

		private Dictionary<string, Sprite> _heroes;
		private readonly Dictionary<string, int> _power = new Dictionary<string, int>()
		{
			{ Hero.Barbarian.ToString(), 10 },
			{ Hero.Chan.ToString(), 9 },
			{ Hero.Jack.ToString(), 8 },
			{ Hero.John.ToString(), 7 },
			{ Hero.Josh.ToString(), 10 },
			{ Hero.Aname.ToString(), 5 }
		};
		private readonly Dictionary<string, int> _agility = new Dictionary<string, int>()
		{
			{ Hero.Barbarian.ToString(), 4 },
			{ Hero.Chan.ToString(), 7 },
			{ Hero.Jack.ToString(), 6 },
			{ Hero.John.ToString(), 7 },
			{ Hero.Josh.ToString(), 6 },
			{ Hero.Aname.ToString(), 9 }
		};
		private readonly Dictionary<string, int> _health = new Dictionary<string, int>()
		{
			{ Hero.Barbarian.ToString(), 6 },
			{ Hero.Chan.ToString(), 4 },
			{ Hero.Jack.ToString(), 6 },
			{ Hero.John.ToString(), 6 },
			{ Hero.Josh.ToString(), 4 },
			{ Hero.Aname.ToString(), 6 }
		};


		void Awake ()
		{
			if (_instance == null)
			{
				_instance = this;
			}
			else if(_instance != this)
			{
				Destroy(gameObject);
			}
			DontDestroyOnLoad(gameObject);
		}
		
		// Use this for initialization
		void Start ()
		{
			_heroes = new Dictionary<string, Sprite>()
			{
				{ Hero.Barbarian.ToString(), Barbarian },
				{ Hero.Chan.ToString(), Chan },
				{ Hero.Jack.ToString(), Jack },
				{ Hero.John.ToString(), John },
				{ Hero.Josh.ToString(), Josh },
				{ Hero.Aname.ToString(), Aname }
			};
		}
	
		public void SelectHero(string hero)
		{
			SelectedHero = hero;
			HeroIconHolder.sprite = _heroes[SelectedHero];
			HeroIconPreview.sprite = _heroes[SelectedHero];
			HeroIconHolder.color = Color.white;
			HeroName.text = hero;

			Agility.offsetMax = new Vector2(-100 + 20 * _agility[hero], 0);
			Power.offsetMax = new Vector2(-100 + 20 * _power[hero], 0);
			Health.offsetMax = new Vector2(-100 + 20 * _health[hero], 0);
			
			AgilityPreview.offsetMax = new Vector2(-100 + 20 * _agility[hero], 0);
			PowerPreview.offsetMax = new Vector2(-100 + 20 * _power[hero], 0);
			HealthPreview.offsetMax = new Vector2(-100 + 20 * _health[hero], 0);
		}
	}
}