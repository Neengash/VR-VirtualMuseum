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

        if (onPointerLoad != null) {
            loadingCoroutine = StartCoroutine(Loading());
        }
    }

    public void OnPointerExit() {
        onPointerExit?.Invoke();

        if (loadingCoroutine != null) {
            StopCoroutine(loadingCoroutine);
            LoadingReticle.instance.resetLoad();
        }
    }

    public void OnPointerClick() {
        onPointerClick?.Invoke();
    }

    IEnumerator Loading() {
        float time = Time.deltaTime;
        LoadingReticle.instance.SetMaxLoad(LoadTime);

        while (time < LoadTime) {
            LoadingReticle.instance.SetLoad(time);
            yield return null;
            time += Time.deltaTime;
        }

        onPointerLoad?.Invoke();
        loadingCoroutine = null;
        LoadingReticle.instance.resetLoad();
    }
}
