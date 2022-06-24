using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    [SerializeField] private int maxTapCount;
    [SerializeField] private int actualTapCount;
    [SerializeField] private CapsuleCollider2D colider;
    [SerializeField] private GameObject[] sprites;

    public GameObject personaje;
    public GameObject explosion;

    private void Start()
    {
        personaje.SetActive(true);
        explosion.SetActive(false);
        OnInitializeZombie();
    }

    void Update()
    {
        OnMove();
    }

    private void OnMouseDown()
    {
        actualTapCount--;
        if (actualTapCount <= 0)
        {
            OnSetSpriteRenderer(1);
            speedMovement = 0;
            colider.enabled = false;
        }
    }
    public void OnInitializeZombie()
    {
        actualTapCount = maxTapCount;
        colider.enabled = true;
        OnSetSpriteRenderer(0);
        speedMovement = WaveController.Instance.movementSpeed;
    }

    private void OnMove()
    {
        transform.Translate(Vector3.down * speedMovement * Time.deltaTime);
    }

    void OnSetSpriteRenderer(int index)
    {   
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].gameObject.SetActive(i == index);
        }
    }
}
