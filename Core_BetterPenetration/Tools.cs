﻿using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Linq;
#if AI || HS2
using AIChara;
#endif

namespace Core_BetterPenetration
{
    static class Tools
    {
        internal struct MemberKey
        {
            public readonly Type type;
            public readonly string name;
            internal readonly int _hashCode;

            public MemberKey(Type inType, string inName)
            {
                this.type = inType;
                this.name = inName;
                this._hashCode = this.type.GetHashCode() ^ this.name.GetHashCode();
            }

            public override int GetHashCode()
            {
                return this._hashCode;
            }
        }

        internal static readonly Dictionary<MemberKey, PropertyInfo> _propertyCache = new Dictionary<MemberKey, PropertyInfo>();

        internal static object GetPrivateProperty(this object self, string name)
        {
            MemberKey key = new MemberKey(self.GetType(), name);
            if (_propertyCache.TryGetValue(key, out PropertyInfo info) == false)
            {
                info = key.type.GetProperty(key.name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                _propertyCache.Add(key, info);
            }
            return info.GetValue(self, null);
        }

        public static Transform GetTransformOfChaControl(ChaControl chaControl, string transformName)
        {
            Transform transform = null;
            if (chaControl == null)
                return transform;

            var transforms = chaControl.GetComponentsInChildren<Transform>().Where(x => x.name != null && x.name.Equals(transformName));
            if (transforms.Count() == 0)
                return transform;

            for (int transformIndex = transforms.Count() - 1; transformIndex >= 0; transformIndex--)
            {
                transform = transforms.ElementAt(transformIndex);
                if (transform == null || chaControl != transform.GetComponentInParent<ChaControl>())
                    continue;

                return transform;
            }

            return transform;
        }

        public static DynamicBone GetDynamicBoneOfChaControl(ChaControl chaControl, string dynamicBoneName)
        {
            DynamicBone dynamicBone = null;
            if (chaControl == null)
                return dynamicBone;

            var dynamicBones = chaControl.GetComponentsInChildren<DynamicBone>().Where(x => x.name != null && x.name.Equals(dynamicBoneName));
            if (dynamicBones.Count() == 0)
                return dynamicBone;

            for (int boneIndex = dynamicBones.Count() - 1; boneIndex >= 0; boneIndex--)
            {
                dynamicBone = dynamicBones.ElementAt(boneIndex);
                if (dynamicBone != null && chaControl == dynamicBone.GetComponentInParent<ChaControl>())
                    return dynamicBone;
            }

            return dynamicBone;
        }

        public static List<DynamicBoneCollider> GetCollidersOfChaControl(ChaControl chaControl, string colliderName)
        {
            List<DynamicBoneCollider> colliderList = new List<DynamicBoneCollider>();
            if (chaControl == null)
                return colliderList;

            var colliders = chaControl.GetComponentsInChildren<DynamicBoneCollider>().Where(x => x.name != null && x.name.Contains(colliderName));
            if (colliders.Count() == 0)
                return colliderList;

            foreach (var collider in colliders)
            {
                if (chaControl != collider.GetComponentInParent<ChaControl>())
                    continue;

                colliderList.Add(collider);
            }

            return colliderList;
        }

        public static List<DynamicBoneCollider> GetCollidersOfChaControl(ChaControl chaControl, List<string> colliderNames)
        {
            List<DynamicBoneCollider> colliderList = new List<DynamicBoneCollider>();
            if (chaControl == null)
                return colliderList;

            var colliders = chaControl.GetComponentsInChildren<DynamicBoneCollider>().Where(x => x.name != null && colliderNames.Contains(x.name));
            if (colliders.Count() == 0)
                return colliderList;

            foreach (var collider in colliders)
            {
                if (chaControl != collider.GetComponentInParent<ChaControl>())
                    continue;

                colliderList.Add(collider);
            }

            return colliderList;
        }

        internal static DynamicBoneCollider InitializeCollider(Transform parent, float radius, float length, Vector3 centerOffset,
                                                               DynamicBoneCollider.Direction direction = DynamicBoneCollider.Direction.X,
                                                               DynamicBoneCollider.Bound bound = DynamicBoneCollider.Bound.Outside)
        {
            if (parent == null)
                return null;

            DynamicBoneCollider collider = parent.GetComponent<DynamicBoneCollider>();

            if (collider == null)
                collider = parent.gameObject.AddComponent(typeof(DynamicBoneCollider)) as DynamicBoneCollider;

            collider.m_Direction = direction;
            collider.m_Center = centerOffset;
            collider.m_Bound = bound;
            collider.m_Radius = radius;
            collider.m_Height = length;

            return collider;
        }

        internal static float ComputeRadiusScale(Transform transform, DynamicBoneCollider.Direction direction)
        {
            if (direction == DynamicBoneCollider.Direction.X)
                return (transform.lossyScale.y + transform.lossyScale.z) / 2;

            if (direction == DynamicBoneCollider.Direction.Y)
                return (transform.lossyScale.x + transform.lossyScale.z) / 2;

            return (transform.lossyScale.x + transform.lossyScale.y) / 2;
        }

        internal static float ComputeHeightScale(Transform transform, DynamicBoneCollider.Direction direction)
        {
            if (direction == DynamicBoneCollider.Direction.X)
                return transform.lossyScale.x;

            if (direction == DynamicBoneCollider.Direction.Y)
                return transform.lossyScale.y;

            return transform.lossyScale.z;
        }

        internal static void RemoveCollidersFromCoordinate(ChaControl character)
        {
            var dynamicBones = character.GetComponentsInChildren<DynamicBone>(true);

            if (dynamicBones == null)
                return;

            foreach (var dynamicBone in dynamicBones)
            {
                if (!dynamicBone)
                    continue;

                var dbName = dynamicBone.name;
                var dbColliders = dynamicBone.m_Colliders;

                if (dbName == null || dbColliders == null || dbColliders.Count <= 0)
                    continue;

                bool bpBone = dbName.Contains("Vagina") || dbName.Contains("Belly") || dbName.Contains("Ana");
                int last = 0;

                for (int collider = 0; collider < dbColliders.Count; ++collider)
                {
                    if (dbColliders[collider])
                    {
                        var colliderName = dbColliders[collider].name;

                        if (colliderName != null)
                        {
                            bool bpCollider = colliderName.Contains("cm_J_vdan") || colliderName.Contains("cm_J_dan");

                            if (bpBone != bpCollider)
                                continue;   //remove collider
                        }
                    }

                    //keep collider
                    if (last != collider)
                        dbColliders[last] = dbColliders[collider];
                    ++last;
                }

                dbColliders.RemoveRange(last, dbColliders.Count - last);
            }
        }
    }
}