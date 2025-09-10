using UnityEngine;

public class TitleScreenLoadMenuInputManager : MonoBehaviour
{
    [SerializeField] PlayerControls playerControls;

    [Header("Title Screen Inputs")]
    [SerializeField] bool deleteCharacterSlot = false;

    private void Update()
    {
        if (this.deleteCharacterSlot)
        {
            this.deleteCharacterSlot = false;
            TitleScreenManager.instance.AttemptToDeleteCharacterSlot();
        }
    }

    private void OnEnable()
    {
        if (this.playerControls == null)
        {
            this.playerControls = new PlayerControls();
            this.playerControls.UI.X.performed += i => this.deleteCharacterSlot = true;
            Debug.Log("press button delete" + this.deleteCharacterSlot);
        }
        this.playerControls.Enable();
    }

    private void OnDisable()
    {
        this.playerControls.Disable();
    }
}
