using System;
using UnityEngine;

namespace Assets.Scripts
{
	public class HeroesFactory : MonoBehaviour {

		public GameObject Barbarian;
		public GameObject Chan;
		public GameObject Jack;
		public GameObject John;
		public GameObject Josh;
		public GameObject Aname;
		public Transform Position;

		private GameObject CurrentHero;
		private GameObject Enemy = null;


		private Animation enemyAnimation;
		private Animator enemyAnimator;

		private float _time = 0;
		
		// Use this for initialization
		void Start ()
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;
			HeroSelection selection = FindObjectOfType<HeroSelection>();
			if (selection != null)
			{
				Hero selectedHero = (Hero) Enum.Parse(typeof(Hero), selection.SelectedHero, true);
				switch (selectedHero)
				{
					case Hero.Barbarian:
						CurrentHero = Barbarian;
						break;
					case Hero.Aname:
						CurrentHero = Aname;
						break;
					case Hero.Chan:
						CurrentHero = Chan;
						break;
					case Hero.Jack:
						CurrentHero = Jack;
						break;
					case Hero.John:
						CurrentHero = John;
						break;
					case Hero.Josh:
						CurrentHero = Josh;
						break;
				}
				CurrentHero.SetActive(true);
			}
			SpawnEnemy();
		}

		private void SpawnEnemy()
		{
			Enemy = Instantiate(Jack, Position);
			if (CurrentHero != null)
			{
				Enemy.transform.LookAt(CurrentHero.transform);
				CurrentHero.transform.LookAt(Enemy.transform);
			}
			Enemy.SetActive(true);
			enemyAnimation = Enemy.GetComponent<Animation>();
			enemyAnimator = Enemy.GetComponent<Animator>();
		}

		public void Attack()
		{
			if (Time.time - _time > 4 || Math.Abs(_time) < 0.01)
			{
				_time = Time.time;
				CurrentHero.GetComponent<Animator>().SetBool("Idle", false);
				CurrentHero.GetComponent<Animator>().SetBool("RoundKick", true);
			}
		}
		
		// Update is called once per frame
		void Update () {

			if (Enemy != null && CurrentHero != null && Vector3.Distance(CurrentHero.transform.position, Enemy.transform.position) > 0.04)
			{
				Enemy.transform.position += new Vector3(0.05f * Time.deltaTime, 0, 0);
			}
			else
			{
				enemyAnimator.SetBool("walk_attack", true);
			}
		}
	}
}
