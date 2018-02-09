using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPool : MonoBehaviour {

	[SerializeField] List<Image> manaCristals = new List<Image>();
	[SerializeField] GameObject manaObject;
	[SerializeField] GameObject canvas;

	public int currentMana = 1;
	public int currentManaMax = 1;
	public int maxMana = 10;

	void Start () {
		for (int i = 0; i < maxMana; i++)
        {
            SetMaxMana();
        }
    }

    private void SetMaxMana()
    {
        GameObject mana = Instantiate(manaObject, canvas.transform.position, canvas.transform.rotation);
        mana.transform.SetParent(canvas.transform);
        manaCristals.Add(mana.GetComponent<Image>());
    }

    void Update () {
		for (int i = 0; i < currentMana; i++)
		{
			manaCristals[i].color = Color.white;
		}
		for (int i = maxMana - 1; i >= currentMana; i--)
		{
			manaCristals[i].color = Color.grey;
		}
	}

	public void AddMana(int num) {
		for (int i = 0; i < num; i++)
		{
			if (currentMana >= maxMana) {currentMana = maxMana; return;}
			currentMana++;
		}
	}

	public void SpendMana(int num) {
		for (int i = 0; i < num; i++)
		{
			if (currentMana <= 0) {currentMana = 0; return;}
			currentMana--;
		}
	}

	public void AddCurrentMaxMana(int num) {
		for (int i = 0; i < num; i++)
		{
			if (currentManaMax >= maxMana) {currentManaMax = maxMana; return;}
			currentManaMax++;
		}
	}

	public void RefillMana() {
		currentMana = currentManaMax;
	}

	public void AddMaxMana (int num) {
		for (int i = 0; i < num; i++)
		{
			if (maxMana >= 20) {maxMana = 20; return;}
			maxMana++;
			SetMaxMana();
		}
	}

	public void RemoveMaxMana (int num) {
		for (int i = 0; i < num; i++)
		{
			if (maxMana <= 1) {maxMana = 1; return;}
			maxMana--;
			if (maxMana <= currentMana) {currentMana = maxMana;}
			Destroy(manaCristals[manaCristals.Count-1].gameObject);
			manaCristals.RemoveAt(manaCristals.Count-1);
		}
	}
}