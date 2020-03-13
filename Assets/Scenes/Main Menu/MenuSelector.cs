using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> buttons;
    private int index = 0;
    private float timer = 0;
    private Button cur;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(buttons[index]);
    }

    // Update is called once per frame
    void Update()
    {
        float pressed = Input.GetAxis("menu");

        // Go down
        if (pressed > 0) {
            // Add duration between each calling
            timer += pressed * 0.55f;

            if (timer >= 0.3) {
                moveDown();
                pressed = 0;
                timer = 0;
            }
        }

        // Go up
        if (pressed < 0)
        {
            timer += pressed * 0.5f;

            if (timer <= -0.3)
            {
                moveUp();
                pressed = 0;
                timer = 0;
            }
        }

        if (pressed == 0) {
            timer = 0;
        }

        // Key Board controll

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            moveUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDown();
        }

        if (Input.GetButtonDown("confirmKey") || Input.GetKeyDown("space")) {
            cur = buttons[index].GetComponent<Button>();
            cur.onClick.Invoke();
        }

    }

    public void moveDown() {
        index++;

        if (index == buttons.Count)
        {
            index = 0;
        }

        EventSystem.current.SetSelectedGameObject(buttons[index]);
    }

    public void moveUp() {
        index--;

        if (index < 0)
        {
            index = buttons.Count - 1;
        }

        EventSystem.current.SetSelectedGameObject(buttons[index]);
    }

}
