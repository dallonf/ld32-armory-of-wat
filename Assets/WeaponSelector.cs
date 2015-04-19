using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour
{
    public Image[] weaponIcons;
    public GameObject[] weapons;
    public int[] ScoreToUnlock;
    public Color SelectedColor = Color.yellow;

    private KeyCode[] keys = new KeyCode[]
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3
    };

    // Use this for initialization
    void Start()
    {
        SelectWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]))
            {
                SelectWeapon(i);
            }
        }
    }

    public void SelectWeapon(int index)
    {
        for (int i = 0; i < weaponIcons.Length; i++)
        {
            if (i == index)
            {
                weaponIcons[i].color = SelectedColor;
                weapons[i].SetActive(true);
            }
            else
            {
                weaponIcons[i].color = Color.white;
                weapons[i].SetActive(false);
            }
        }
    }
}
