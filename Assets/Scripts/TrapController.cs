using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    private enum TrapType
    {
        None,
        Axe,
        Spear,
        Saw,
        Hammer
    }

    public void HandleHit(PlayerController player, GameObject obj)
    {
        if (!obj) return;
        if (obj.tag != "Trap" && obj.transform.root.tag != "Trap") return;

        var trapType = GetType(obj);

        switch (trapType)
        {
            case TrapType.Axe:
                print("hit by axe");
                player.Hp -= 0.8f;
                break;
            case TrapType.Spear:
                print("hit by spear");
                player.Hp -= 0.3f;
                break;
            case TrapType.Saw:
                print("hit by saw");
                player.Hp -= 0.6f;
                break;
            case TrapType.Hammer:
                print("hit by hammer");
                player.Hp -= 0.4f;
                break;
            case TrapType.None:
                break;
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

    private TrapType GetType(GameObject obj)
    {
        if (obj.GetComponent<Axe>()) return TrapType.Axe;
        if (obj.GetComponent<Spear>()) return TrapType.Spear;
        if (obj.GetComponent<SawBlade>()) return TrapType.Saw;
        if (obj.GetComponent<Hammer>()) return TrapType.Hammer;

        return TrapType.None;
    }
}
