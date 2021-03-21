using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRObject : MonoBehaviour
{
    [SerializeField, Range(0.5f, 10f)]
    private float LoadTime = 2f;
    Coroutine loadingCoroutine;

    [SerializeField]
    UnityEvent onPointerEnter, onPointerExit, onPointerClick, onPointerLoad;

    public void OnPointerEnter() {
        onPointerEnter?.Invoke();
        loadingCoroutine = StartCoroutine(Loading());
    }

    public void OnPointerExit() {
        onPointerExit?.Invoke();

        if (loadingCoroutine != null) {
            StopCoroutine(loadingCoroutine);
        }
    }

    public void OnPointerClick() {
        onPointerClick?.Invoke();
    }

    IEnumerator Loading() {
        yield return new WaitForSeconds(LoadTime);
        onPointerLoad?.Invoke();
        loadingCoroutine = null;
    }
}
