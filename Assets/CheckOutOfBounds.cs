using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutOfBounds : MonoBehaviour
{
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        //Destroys object if it's outside of screen
        if (transform.position.y < screenBounds.y - 20 || transform.position.y > screenBounds.y + 20 ||  transform.position.x < screenBounds.x - 20 || transform.position.x > screenBounds.x + 20)
        {
            Destroy(this.gameObject);
        }

    }
}
