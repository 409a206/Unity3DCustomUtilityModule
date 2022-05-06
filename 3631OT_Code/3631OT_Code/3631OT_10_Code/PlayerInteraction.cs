using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
	public GameObject Projectile, Potion;

	void Update ()
	{
		if(Input.GetButtonUp("Fire1"))
			Instantiate(Projectile, transform.position, transform.rotation);

		if(Input.GetButtonUp("Esc_Key"))
		{
			if(Time.timeScale != 0.00f)
				Time.timeScale = 0.00f;
			else
				Time.timeScale = 1.00f;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Potion")
		{
			GetComponent<Inventory>().AddToInventory(1, Potion);

			for(int i = 0; i < GetComponent<GUI_2D>().Items.Count; i ++)
			{
				if(GetComponent<GUI_2D>().Items[i].name == "")
					GetComponent<GUI_2D>().Items[i] = Potion;
				break;
			}
			Destroy(other.gameObject);
		}
	}
}