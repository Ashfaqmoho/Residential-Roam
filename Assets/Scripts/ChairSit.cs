using UnityEngine;

public class ChairSit : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Capsule;
    public GameObject Player;

    private bool isSitting = false;
    private bool canSit = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canSit = true; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canSit = false; 
        }

        if (isSitting)
        {
            StandUp(); 
        }
    }

    void Update()
    {
        if (canSit && Input.GetKeyDown(KeyCode.E) && !isSitting)
        {
            SitDown();
        }
        else if (isSitting && Input.GetKeyDown(KeyCode.E))
        {
            StandUp();
        }
    }

    void StandUp()
    {
        print("Leaving TV");
        MainCamera.SetActive(true);
        Capsule.SetActive(false);
        Player.SetActive(true);
        isSitting = false;
    }

    void SitDown()
    {
        print("Watching TV");
        MainCamera.SetActive(false);
        Capsule.SetActive(true);
        Player.SetActive(false);
        isSitting = true;
    }
}
