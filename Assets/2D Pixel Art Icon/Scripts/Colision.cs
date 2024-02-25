using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Colision : MonoBehaviour
{
    public string collidableTag = "Tag1"; 
    public GameObject spawnObjectPrefab;  
    public TextMeshProUGUI pointsText;
    public AudioClip collisionSound;

    private AudioSource audioSource;
    public int points = 0;
    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag(collidableTag))
        {
            
            Destroy(collision.gameObject);

            
            SpawnObject(collision.contacts[0].point);

            
            AddPoints(2);
            UpdatePointsText();
            
        }
    }

    void SpawnObject(Vector3 spawnPosition)
    {
        
        Instantiate(spawnObjectPrefab, spawnPosition, Quaternion.identity);
    }

    void AddPoints(int value)
    {
        
        points += value;
    }

    void UpdatePointsText()
    {
        
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points.ToString();
        }
    }
    void PlayCollisionSound()
    {
        
        if (audioSource != null && collisionSound != null)
        {
            
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
