using UnityEngine;

public class EnemyDisabler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
        }
    }
}
