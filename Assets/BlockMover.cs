using UnityEngine;

public class BlockMover : MonoBehaviour
{
    public float Speed;
    private void OnEnable()
    {
        Invoke(nameof(ObjectDisables), 15f);
    }

    private void ObjectDisables()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Translate(-Speed * Time.deltaTime, 0, 0);
    }
}
