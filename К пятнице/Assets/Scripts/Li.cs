using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Li : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Danger"))
        {
            Debug.Log("Dead");
            Die();
        }
    }

    void Die()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Movment>().enabled = false; 
        GetComponent<MeshRenderer>().enabled = false;
        Respawn();
    }
    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
