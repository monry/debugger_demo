using UnityEngine;

namespace Monry.DebuggerDemo.Incorrect
{
    public class Parent : MonoBehaviour
    {
        [SerializeField] private GameObject monryPrefab;
        private GameObject MonryPrefab => monryPrefab;

        private void Start()
        {
            Spawn();
        }

        public void Spawn()
        {
            Instantiate(MonryPrefab, transform);
        }
    }
}