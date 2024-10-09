using UnityEngine;

public class ExitManager : MonoBehaviour
{
    private PlayerStatsManager psvm;
    void Awake()
    {
        psvm = GameObject.Find("PlayerStats").GetComponent<PlayerStatsManager>();
    }
    void Update() { }
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject enemy = col.gameObject;
        if (enemy.CompareTag("Enemy"))
        {
            psvm.SubLives(enemy.GetComponent<Health>().hpSub);
            Destroy(enemy);
        }
    }
}
