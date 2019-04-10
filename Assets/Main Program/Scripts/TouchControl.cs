using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour
{
    public float movementSpeed = 800f;
    private Vector3 position;
    private float width;
    private float height;

    private float xHelper = 0f;
    private float yHelper = 0f;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void OnGUI()
    {
        // Compute a fontSize based on the size of the screen width.
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

        GUI.Label(new Rect(20, 20, width, height * 0.25f),
            "x = " + position.x.ToString("f2") +
            ", y = " + position.y.ToString("f2"));
    }

    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(pos.x, pos.y, 0f);


                // Position the cube.

                transform.localPosition = position * movementSpeed;
                // transform.localPosition = new Vector3(
                //     (xHelper < pos.x ? transform.localPosition.x + movementSpeed : transform.localPosition.x - movementSpeed),
                //     (yHelper < pos.y ? transform.localPosition.y + movementSpeed : transform.localPosition.y - movementSpeed),
                //     0f);

                xHelper = pos.x;
                yHelper = pos.y;
            }

            // if (Input.touchCount == 2)
            // {
            //     touch = Input.GetTouch(1);

            //     if (touch.phase == TouchPhase.Began)
            //     {
            //         // Halve the size of the cube.
            //         transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            //     }

            //     if (touch.phase == TouchPhase.Ended)
            //     {
            //         // Restore the regular size of the cube.
            //         transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            //     }
            // }
        }
    }
}