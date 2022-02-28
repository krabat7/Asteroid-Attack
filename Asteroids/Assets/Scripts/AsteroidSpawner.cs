using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] Asteroid _asteroidPrefab;

    [SerializeField] float trajectoryVariance = 15.0f;

    [SerializeField] float spawnRate = 2.0f;

    [SerializeField] float spawnAmount = 1;

    [SerializeField] float spawnDistance = 15.0f;
    private void Start()
    {
        InvokeRepeating("Spawn", this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this._asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
