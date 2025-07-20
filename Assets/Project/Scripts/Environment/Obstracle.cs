using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstracle : MonoBehaviour
{
    [SerializeField] private Material material;

    [SerializeField] private float dissolveDuration = 0.2f;
    private float returnOffset = 5f;
    private Material mat;
    private Renderer rend;
    void Awake()
    {
        rend = GetComponent<Renderer>();
        mat = new Material(material);
        rend.material = mat;
    }
    private void OnEnable()
    {
        ResetDissolve();
    }

    private void ResetDissolve()
    {
        if (mat != null)
        {
            mat.SetFloat("_dissolveAmount", 0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Camera.main.GetComponent<Animator>().SetTrigger("shake");
            StartCoroutine(DissolveAndDisable());
        }
    }

    private IEnumerator DissolveAndDisable()
    {
        float t = 0f;

        while (t < dissolveDuration)
        {
            float dissolveValue = Mathf.Lerp(0f, 1f, t / dissolveDuration);
            mat.SetFloat("_dissolveAmount", dissolveValue);
            t += Time.deltaTime;
            yield return null;
        }

        mat.SetFloat("dissolveAmount", 1f);

    }
    void Update()
    {
        if (transform.position.z + returnOffset < GameManager.Instance.GetPlayerPosition().position.z)
        {
            PoolManager.Instance.ReturnObstacle(gameObject);
        }
    }
}
