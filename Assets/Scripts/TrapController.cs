using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public void HandleHit(PlayerController player, GameObject obj)
    {
        if (!obj) return;
        if (obj.tag != "Trap" && obj.transform.root.tag != "Trap") return;

        if (obj.GetComponent<Axe>())
        {
            print("hit by axe");
            player.Hp -= 0.8f;
        }

        StartCoroutine(PauseObj(obj));
    }

    // Pause an object `obj` from doing dmg for `time` seconds
    private IEnumerator PauseObj(GameObject obj, float time = 1f)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(time);
        obj.SetActive(true);
    }
}
