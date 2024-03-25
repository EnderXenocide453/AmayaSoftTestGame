using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridManagement.Animations
{
    public class ParticlesAnimation : ObjectAnimation
    {
        [SerializeField] private GameObject m_ParticlePrefab;
        [SerializeField] private int m_ParticleCount;
        [SerializeField] private float m_ParticleSpread;

        private List<Transform> m_Particles;

        public override void PlayAnimation()
        {
            StopAnimation();

            StartCoroutine(SpreadParticles());
        }

        public override void StopAnimation()
        {
            StopAllCoroutines();

            for (int i = 0; i < m_Particles?.Count; i++) {
                Destroy(m_Particles[i].gameObject);
            }

            m_Particles = new List<Transform>();
        }

        private IEnumerator SpreadParticles()
        {
            for (int i = 0; i < m_ParticleCount; i++) {
                Transform particle = Instantiate(
                        m_ParticlePrefab,
                        transform
                    ).transform;
                particle.localPosition = Random.insideUnitCircle * m_ParticleSpread;

                m_Particles.Add(particle);
            }

            yield return new WaitForSeconds(m_Duration);

        }
    }
}

