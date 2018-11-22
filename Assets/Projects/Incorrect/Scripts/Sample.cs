using System;
using UniRx;
using UnityEngine;

namespace Monry.DebuggerDemo.Incorrect
{
    public class Sample : MonoBehaviour
    {
        private const float RotateAnglePerSecond = 180.0f;

        private const float ScaleRatioPerSecond = 1.2f;

        private const double DestroyTimer = 3.0;

        private Parent Parent { get; set; }

        private void Awake()
        {
            Parent = transform.parent.GetComponent<Parent>();
        }

        private void Start()
        {
            Observable.EveryUpdate()
                .Select(_ => transform)
                .Subscribe(
                    x =>
                    {
                        x.Rotate(
                            Vector3.forward,
                            RotateAnglePerSecond * Time.deltaTime
                        );
                        x.localScale +=
                            Vector3.one
                            * ScaleRatioPerSecond
                            * Time.deltaTime;
                    },
                    () => Parent.Spawn()
                );
            Observable
                .Timer(TimeSpan.FromSeconds(DestroyTimer))
                .Subscribe(_ => Destroy(gameObject));
        }
    }
}