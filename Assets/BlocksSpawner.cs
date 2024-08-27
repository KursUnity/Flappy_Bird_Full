using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSpawner : MonoBehaviour
{
    public BlockMover Block;
    public List<BlockMover> BlocksList = new List<BlockMover>();
    public float SpawnTime;
    public float YAxis_1, YAxis_2;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        var timer = new WaitForSeconds(SpawnTime);

        while (true)
        {
            TryGetNewBlock();
            yield return timer;
        }
    }

    private void TryGetNewBlock()
    {
        foreach (var block in BlocksList)
        {
            if (!block.gameObject.activeSelf)
            {
                block.gameObject.SetActive(true);
                block.transform.position = new Vector2(12, Random.Range(YAxis_1, YAxis_2));
                return;
            }
        }

        BlockMover newBlock = Instantiate(Block, new Vector2(12, Random.Range(YAxis_1, YAxis_2)), Quaternion.identity);
        newBlock.gameObject.SetActive(true);
        BlocksList.Add(newBlock);
    }
}
