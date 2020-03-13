using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CharacterDisplay : MonoBehaviour
{
    [Header("List of characters")]
    [SerializeField] private List<Character> characterList = new List<Character>();

    private int characterIndex = 0;

    public Transform playerSlotsContainer;
    public Character character;
    public Image artworkImage;
    public TextMeshProUGUI nameText;
    public Character confirmedCharacter;

    public int playerNumber = 1;        // Which player are you?

    private string leftKey;    // Gets player key for moving
    private string rightKey;    //keyboard equivilant
    private string playerJump;          // Gets player key for jumping
    private string playerJumpKey;

    public int totalPlayers;
    public static int currentConfirmed = 0;
    public bool confirmed = false;
    // Start is called before the first frame update
    void Start() {
        totalPlayers = GameObject.Find("passScore").GetComponent<StateManager>().getTotal();
        Debug.Log(totalPlayers);
        UpdateDisplay();
        UpdateControles(playerNumber);  // Selects controles based on what player they are

        if (Input.GetButtonUp(leftKey))
            {
            LeftArrow();
        }
    }

    void Update() {
        float horMove = Input.GetAxis(leftKey);
        float horMoveKey = Input.GetAxis(rightKey);
        

        if (!confirmed)
        {
            if (Input.GetButtonDown(leftKey))
            {
                LeftArrow();
            }

            if (Input.GetButtonDown(rightKey))
            {
                LeftArrow();
                Debug.Log(horMove);
            }

            if (Input.GetButtonDown(playerJump) || Input.GetButtonDown(playerJumpKey))
            {
                ConfirmCharacter();
            }
        }
        else {
            totalPlayers = GameObject.Find("passScore").GetComponent<StateManager>().getTotal();
            if (this.tag == "Player1")
            {
                GameObject.Find("passScore").GetComponent<StateManager>().setP1(characterList[characterIndex]);
                Debug.Log(GameObject.Find("passScore").GetComponent<StateManager>().getP1().name);
            }
            else if (this.tag == "Player2")
            {
                GameObject.Find("passScore").GetComponent<StateManager>().setP2(characterList[characterIndex]);
            }
            else if (this.tag == "Player3")
            {
                GameObject.Find("passScore").GetComponent<StateManager>().setP3(characterList[characterIndex]);
            }
            else if (this.tag == "Player4")
            {
                GameObject.Find("passScore").GetComponent<StateManager>().setP4(characterList[characterIndex]);
            }

            if ((Input.GetButtonDown(playerJump) || Input.GetButtonDown(playerJumpKey)) && currentConfirmed == totalPlayers)
            {
                SceneManager.LoadScene("Gameplay");
            }
        }

        if (currentConfirmed == totalPlayers) {
            GameObject.Find("Tip").GetComponent<SelectListner>().t.text = "Press Jump key again to start";
        }

        // For developer test purpose, use space jump to gameplay scene without confirm characters
        if (Input.GetKeyDown("k")) {
            if (this.tag == "Player1")
            {
                GameObject.Find("passScore").GetComponent<StateManager>().setP1(characterList[characterIndex]);
                Debug.Log(GameObject.Find("passScore").GetComponent<StateManager>().getP1().name);
            }
            else if (this.tag == "Player2")
            {
                GameObject.Find("passScore").GetComponent<StateManager>().setP2(characterList[characterIndex]);
            }
            else if (this.tag == "Player3")
            {
                GameObject.Find("passScore").GetComponent<StateManager>().setP3(characterList[characterIndex]);
            }
            else if (this.tag == "Player4")
            {
                GameObject.Find("passScore").GetComponent<StateManager>().setP4(characterList[characterIndex]);
            }
            SceneManager.LoadScene("Gameplay");
        }

    }

    private void UpdateDisplay() {
        nameText.text = characterList[characterIndex].name;
        artworkImage.sprite = characterList[characterIndex].artwork;
        
    }

    public void LeftArrow() {
        characterIndex--;

        if (characterIndex < 0) {
            characterIndex = characterList.Count - 1;
        }

        UpdateDisplay();
    }

    public void RightArrow() {
        characterIndex++;

        if (characterIndex == characterList.Count)
        {
            characterIndex = 0;
        }

        UpdateDisplay();
    }

    public void ConfirmCharacter()
    {
        if (confirmedCharacter == null) {
            confirmedCharacter = characterList[characterIndex];
            transform.DOPunchPosition(new Vector3(0, 10,0), 3);
            confirmed = true;
            currentConfirmed++;
        }
    }

    public int getConfirmed() {
        return currentConfirmed;
    }

    void UpdateControles(int playerNumber)
    {
        leftKey = "Player" + playerNumber + "SelectLeft";
        rightKey = "Player" + playerNumber + "SelectRight";
        playerJump = "Player" + playerNumber + "Jump";
        playerJumpKey = "Player" + playerNumber + "JumpKey";
    }

}
