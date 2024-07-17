using System;
using System.Linq;
using UnityEngine;

namespace Lucerna.Managers
{
    public class MenuManager : MonoBehaviour
    {
        // VARIABLES
        [SerializeField] private Animator[] menus;
        private Animator currentMenu;
        private Animator previousMenu;

        public string CurrentMenuName => currentMenu == null ? "" : currentMenu.name;

        public static MenuManager Instance { get; private set; }

        public event EventHandler<string> OnMenuChanged;

        // EXECUTION FUNCTIONS
        private void Awake() 
        {
            Instance = this;
        }

        private void Start() 
        {
            currentMenu = menus[0];    
        }

        // METHODS
        public void ChangeToMenu(Animator menu)
        {
            if (currentMenu != null)
            {
                previousMenu = currentMenu;
                currentMenu.Play("OnExit");
            }

            if (menu == null)
                return;
            
            currentMenu = menu;
            currentMenu.gameObject.SetActive(true);
            currentMenu.Play("OnEnter");

            OnMenuChanged?.Invoke(this, menu.name);
        }

        public void ChangeToMenu(string menuName)
        {
            var targetMenu = GetMenu(menuName);

            if (currentMenu != null)
            {
                if (targetMenu == currentMenu)
                {
                    return;
                }

                previousMenu = currentMenu;
                currentMenu.Play("OnExit");
            }

            if (string.IsNullOrEmpty(menuName))
                return;
            
            currentMenu = targetMenu;
            currentMenu.gameObject.SetActive(true);
            currentMenu.Play("OnEnter");

            OnMenuChanged?.Invoke(this, menuName);
        }

        public void ChangeToPreviousMenu()
        {
            ChangeToMenu(previousMenu);
        }

        private Animator GetMenu(string menuName)
        {
            return menus.Where(menu => menu.gameObject.name == menuName).FirstOrDefault();
        }
    }
}
