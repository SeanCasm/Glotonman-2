using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Glotonman2.Data;

namespace Glotonman2.Scenario.Items
{
    public class ItemGenerator : MonoBehaviour
    {
        [Header("Spawn rates config")]
        public int m_ItemMin = 30, m_ItemMax = 60;
        public float m_FruitMin = 1.5f, m_FruitMax = 6.6f;
        [Header("References")]
        public PlayerStats m_GameData;
        public GameObject[] m_FruitPrefabs;
        public List<Item> m_Items = new List<Item>();
        private BoxCollider2D box;
        private Queue<Fruit> fruits = new Queue<Fruit>();

        void Start()
        {
            box = GetComponent<BoxCollider2D>();

            CreateFruits();

            StartCoroutine(SpawnItem());
            StartCoroutine(SpawnFruit());
        }
        private void CreateFruits()
        {
            for (int i = 0; i < 10; i++)
            {
                int index = UnityEngine.Random.Range(0, m_FruitPrefabs.Length);
                GameObject newF = Instantiate(m_FruitPrefabs[index], Vector2.right * 100, Quaternion.identity);
                Fruit fruit = newF.GetComponent<Fruit>();
                fruit.itemGenerator = this;
                fruit.gameData = m_GameData;
                newF.SetActive(false);
                fruits.Enqueue(fruit);
            }
        }
        private (Vector2, Vector2) SetDirectionAndSpawn(int side)
        {
            float x = 0, y = 0;
            switch (side)
            {
                case 0://top
                    x = UnityEngine.Random.Range(0, box.bounds.max.x);
                    y = box.bounds.max.y;
                    return (new Vector2(x, y), Vector2.down);
                case 1://right
                    x = box.bounds.max.x;
                    y = UnityEngine.Random.Range(0, box.bounds.max.y);
                    return (new Vector2(x, y), Vector2.left);
                case 2://bottom
                    x = UnityEngine.Random.Range(0, box.bounds.max.x);
                    y = box.bounds.min.y;
                    return (new Vector2(x, y), Vector2.up);
                case 3://left
                    x = box.bounds.min.x;
                    y = UnityEngine.Random.Range(0, box.bounds.max.y);
                    return (new Vector2(x, y), Vector2.right);
                default:
                    return (Vector2.zero, Vector2.zero);
            }
        }
        private IEnumerator SpawnItem()
        {
            if (m_ItemMin >= m_ItemMax) m_ItemMin = m_ItemMax - 10;
            while (true)
            {
                int counter = UnityEngine.Random.Range(m_ItemMin, m_ItemMax + 1);
                float prob = UnityEngine.Random.Range(0f, 1f);

                m_Items.Sort((x, y) => x.m_SpawnProb.CompareTo(y.m_SpawnProb));
                m_Items.Reverse();

                yield return new WaitForSeconds(counter);
                int side = UnityEngine.Random.Range(0, 4);
                (Vector2 spawnPoint, Vector2 direction) = SetDirectionAndSpawn(side);


                for (int i = 0; i < m_Items.Count; i++)
                {
                    if (prob > i * m_Items[i].m_SpawnProb && prob <= m_Items[i].m_SpawnProb)
                    {
                        Item item = m_Items[i];
                        item.SetSpawnPoint(spawnPoint);
                        item.SetActiveSelf(true);
                        item.direction = direction;
                        break;
                    }
                }
            }
        }
        private IEnumerator SpawnFruit()
        {
            while (true)
            {
                float counter = UnityEngine.Random.Range(m_FruitMin, m_FruitMax);
                yield return new WaitForSeconds(counter);
                int side = UnityEngine.Random.Range(0, 4);
                (Vector2 spawnPoint, Vector2 direction) = SetDirectionAndSpawn(side);
                if (fruits.Count == 0) continue;
                Fruit fruit = fruits.Dequeue();
                fruit.SetSpawnPoint(spawnPoint);
                fruit.direction = direction;
                fruit.SetActiveSelf(true);
            }
        }
        public void EnqueueFruit(Fruit fruit) => fruits.Enqueue(fruit);
    }
}
