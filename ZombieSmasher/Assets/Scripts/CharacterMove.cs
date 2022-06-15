using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]float speedMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("click on me!!!");
    }

    private void OnMove()
    {
        transform.Translate(Vector3.down * speedMovement * Time.deltaTime);
    }

}
