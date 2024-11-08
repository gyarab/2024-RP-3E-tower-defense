using System.Collections;
using UnityEngine;

public class Magic : BaseTower
{
    protected override IEnumerator AnimateProjectile(GameObject enemy)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.SetParent(transform);
        sphere.transform.position = transform.position;
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        sphere.GetComponent<Renderer>().material.color = Color.blue;

        yield return TowerHelpers.AnimateDirectProjectile(sphere, enemy, 5, KillProjectile);
    }

    protected override void KillProjectile(GameObject sphere, GameObject enemy, Vector3 _enemyPosition)
    {
        Destroy(sphere);
        if (enemy != null) enemy.GetComponent<BaseEnemy>().TakeDamage((int)damage, DamageTypes.MAGIC);
    }
}
