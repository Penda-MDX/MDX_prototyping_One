using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GrenadeProjectile : MonoBehaviour
{
    public static event EventHandler OnAnyGrenadeExploded;

    [SerializeField] private Transform grenadeExplodeVfxPrefab;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private AnimationCurve arcYAnimationCurve;

    [SerializeField] bool useArcAnimCurve; //if you want to experiment with the two methods 

    private Vector3 targetPosition;
    private Action onGrenadeBehaviourComplete;
    private float totalDistance;
    private float grendadeLaunchHeight = 1.25f; // the height where the grenade is launched from
    private Vector3 positionXZ; //current XZ position of the projectile

    private float xzVelocity = 15f; // this is the same concept as moveSpeed in Hugo's code. We need is here for computing yVelocity in setup
    private float yVelocity; // computed in setup then used in Update()
    private const float g = 9.8f; // force of gravity in m/s^2
    private float launchStartTime; //captured in setup


    [SerializeField] private float explosiveForce;
    [SerializeField] private float upwardForce;

    private void Update()
    {
        Vector3 moveDir = (targetPosition - positionXZ).normalized; // works because targetPosition also has 0 for y value
        float moveSpeed = xzVelocity;
        positionXZ += moveDir * (moveSpeed * Time.deltaTime);
        float positionY;

        if (useArcAnimCurve)
        {
            float distance = Vector3.Distance(positionXZ, targetPosition);
            float distanceNormalized = 1 - distance / totalDistance; // how far along from start to destination

            float maxHeight = totalDistance / 4f;
            positionY = arcYAnimationCurve.Evaluate(distanceNormalized) * maxHeight; // gets the requisite Y value.

        }
        else
        {
            float t = Time.fixedTime - launchStartTime;
            positionY = grendadeLaunchHeight + (yVelocity * t) - (g * t * t) / 2f;
        }
        transform.position = new Vector3(positionXZ.x, positionY, positionXZ.z);

        Vector3 nextFramemoveDir = targetPosition - positionXZ;

        if (Vector3.Dot(moveDir, nextFramemoveDir) < 0)
        {
            float damageRadius = 4f; //note this is 4 units in WORLD position not grid space
            Collider[] colliderArray = Physics.OverlapSphere(targetPosition, damageRadius);

            foreach (Collider collider in colliderArray)
            {
                /*
                if (collider.TryGetComponent<Unit>(out Unit targetUnit))
                {
                    // see this post for explanation of what's happening here.  You can also use Hugo's code.
                    // https://community.gamedev.tv/t/extensible-physics-damage-effects-shoot-grenade-etc/225364
                    DamageContext damageContext = new DamageContext();
                    damageContext.SetUpAsExplosion(explosiveForce, targetPosition + Vector3.up * 1f, damageRadius, upwardForce);
                    targetUnit.Damage(30, damageContext);
                }
                if (collider.TryGetComponent<DestructibleCrate>(out DestructibleCrate destructibleCrate))
                {
                    destructibleCrate.Damage();
                }
                */
            }
            OnAnyGrenadeExploded?.Invoke(this, EventArgs.Empty);

            trailRenderer.transform.parent = null;
            Instantiate(grenadeExplodeVfxPrefab, targetPosition + Vector3.up * 1f, Quaternion.identity);
            Destroy(gameObject);

            onGrenadeBehaviourComplete();
        }
    }

    /*
    public void Setup(GridPosition targetGridPosition, Action onGrenadeBehaviourComplete)
    {
        this.onGrenadeBehaviourComplete = onGrenadeBehaviourComplete;
        targetPosition = LevelGrid.Instance.GetWorldPosition(targetGridPosition);

        positionXZ = transform.position;
        positionXZ.y = 0;
        transform.position = new Vector3(positionXZ.x, grendadeLaunchHeight, positionXZ.z);
        totalDistance = Vector3.Distance(positionXZ, targetPosition);
        // yVelocity is a precise calculation from parametric form of the parabola.
        // Ok to change field level constants above, but don't change this formula.
        yVelocity = g * totalDistance / 2f / xzVelocity - grendadeLaunchHeight * xzVelocity / totalDistance;
        launchStartTime = Time.time;
    }
    */
}