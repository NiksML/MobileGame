using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField] private List<Menu> _menushki;

    public void OpenMenu(string menuName)
    {
        foreach (Menu menu in _menushki)
        {
            if(menu.menuName == menuName)
            {

                menu.OpenMenu();
            }
            else
            {
                menu.CloseMenu();
            }
        }
    }
    void Awake()
    {
        instance = this;
    }

}
