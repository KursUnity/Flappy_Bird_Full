using UnityEngine;

public class BGMover : MonoBehaviour
{
    public float Speed;
    private float _offset;
    private Material _material;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        _offset += (Time.deltaTime * Speed) / 10;
        _material.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
    }
}
