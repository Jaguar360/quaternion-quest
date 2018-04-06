using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOW : MonoBehaviour {

    public float runSpeed;

    private Rigidbody2D rb2d;
    private Vector3 moveDir;
    private KeyCode runKey;

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        runKey = KeyCode.Z;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        bool isWalking = (Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical)) > 0;

        if (isWalking == true)
        {
            if (moveHorizontal > 0)
            {
                moveDir = new Vector3(moveHorizontal, 0);
            }

            else if (moveHorizontal < 0)
            {
                moveDir = new Vector3(moveHorizontal, 0);
            }

            else if (moveVertical > 0)
            {
                moveDir = new Vector3(0, moveVertical);
            }

            else if (moveVertical < 0)
            {
                moveDir = new Vector3(0, moveVertical);
            }

            if (Input.GetKey(runKey)) 
            {
                transform.position = transform.position + (moveDir.normalized * runSpeed * 1.5f * Time.deltaTime);
            }

            else 
            {
                transform.position = transform.position + (moveDir.normalized * runSpeed * Time.deltaTime);    
            }

        }
	}
}
