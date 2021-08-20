using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWithParticles : Projectile
{
    //public ParticleParams particles;
    public List<GameObject> particles;
    public List<float> timeGapsBetweenSpews;
    public List<bool> wait;
    private void Update()
    {
        for (int i = 0; i < particles.Count; i++)
        {
            if (!wait[i])
            {
                IEnumerator e = Spew(i);
                StartCoroutine(e);
            }
        }
    }

    public IEnumerator Spew(int index)
    {
        wait[index] = true;
        GameObject.Instantiate(particles[index], this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(timeGapsBetweenSpews[index]);
        wait[index] = false;
    }
}
