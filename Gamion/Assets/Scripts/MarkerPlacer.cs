using UnityEngine;

namespace Assets.Scripts
{
	public class MarkerPlacer : MonoBehaviour
	{

		public GameObject Holder;
		public GameObject Defence;
		public GameObject Attack;
		public GameObject Health;
		
		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
			
		}

		public void ChangeHolderWithIcons()
		{
			Holder.SetActive(false);
			Defence.SetActive(true);
			Attack.SetActive(true);
			Health.SetActive(true);
		}
		
		public void ChangeIconsWithHolder()
		{
			Holder.SetActive(true);
			Defence.SetActive(false);
			Attack.SetActive(true);
			Health.SetActive(false);
		}
	}
}
