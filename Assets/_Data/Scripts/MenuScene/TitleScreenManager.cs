using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject titleScreenMainMenu;
    public GameObject titleScreenLoadMenu;

    public Button loadMenuReturnButton;
    public Button mainMenuLoadGameButton;
    public void StartNetworkAsHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void StartNewGame()
    {
        WorldSaveGameManager.instance.CreateNewGame();
        StartCoroutine(WorldSaveGameManager.instance.LoadWorldScene());
    }

    public void OpenLoadGameMenu()
    {
        //close
        this.titleScreenMainMenu.SetActive(false);
        //open
        this.titleScreenLoadMenu.SetActive(true);

        this.loadMenuReturnButton.Select();
    }
   
    public void CloseLoadGameMenu()
    {
        //close
        this.titleScreenMainMenu.SetActive(true);
        //open
        this.titleScreenLoadMenu.SetActive(false);

        this.mainMenuLoadGameButton.Select();
   }
}
