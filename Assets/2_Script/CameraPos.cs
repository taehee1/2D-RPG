using UnityEngine;

public class CameraPos : MonoBehaviour
{
    private GameObject playerObj;
    public static CameraPos Instance;
    public GameObject screen;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            transform.position = new Vector3(playerObj.transform.position.x, 0, -10);
        }
    }
}
