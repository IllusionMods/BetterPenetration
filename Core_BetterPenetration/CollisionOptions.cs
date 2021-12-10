﻿using System.Collections.Generic;

namespace Core_BetterPenetration
{
    class CollisionOptions
    {
        internal float kokanOffset = 0.0f;
        internal float innerKokanOffset = 0.0f;
        internal float mouthOffset = 0.0f;
        internal float innerMouthOffset = 0.0f;

        internal bool kokan_adjust = false;
        internal float kokan_adjust_position_z = 0;
        internal float kokan_adjust_position_y = 0;
        internal float kokan_adjust_rotation_x = 0;
        internal float clippingDepth = 0;
#if HS2 || AI
        internal bool enableKokanPush = true;
#else
        internal bool enableKokanPush = false;
#endif
        internal float maxKokanPush = 0.08f;
        internal float maxKokanPull = 0.04f;
        internal float kokanPullRate = 18.0f;
        internal float kokanReturnRate = 0.3f;
        internal bool enableOralPush = true;
        internal float maxOralPush = 0.02f;
        internal float maxOralPull = 0.10f;
        internal float oralPullRate = 18.0f;
        internal float oralReturnRate = 0.3f;
#if HS2 || AI
        internal bool enableAnaPush = true;
#else
        internal bool enableAnaPush = false;
#endif
        internal float maxAnaPush = 0.08f;
        internal float maxAnaPull = 0.04f;
        internal float anaPullRate = 18.0f;
        internal float anaReturnRate = 0.3f;

        internal List<CollisionPointInfo> frontCollisionInfo;
        internal List<CollisionPointInfo> backCollisonInfo;

        public CollisionOptions(float kokanOffset, float innerKokanOffset, float mouthOffset, float innerMouthOffset, bool kokan_adjust,
        float kokan_adjust_position_z, float kokan_adjust_position_y, float kokan_adjust_rotation_x, float clippingDepth, List<CollisionPointInfo> frontInfo, List<CollisionPointInfo> backInfo,
        bool enableKokanPush, float maxKokanPush, float maxKokanPull, float kokanPullRate, float kokanReturnRate,
        bool enableOralPush, float maxOralPush, float maxOralPull, float oralPullRate, float oralReturnRate,
        bool enableAnaPush, float maxAnaPush, float maxAnaPull, float anaPullRate, float anaReturnRate)
        {
            this.kokanOffset = kokanOffset;
            this.innerKokanOffset = innerKokanOffset;
            this.mouthOffset = mouthOffset;
            this.innerMouthOffset = innerMouthOffset;

            this.kokan_adjust = kokan_adjust;
            this.kokan_adjust_position_z = kokan_adjust_position_z;
            this.kokan_adjust_position_y = kokan_adjust_position_y;
            this.kokan_adjust_rotation_x = kokan_adjust_rotation_x;
            this.clippingDepth = clippingDepth;
#if HS2 || AI
            this.enableKokanPush = enableKokanPush;
#else
            this.enableKokanPush = false;
#endif
            this.maxKokanPush = maxKokanPush;
            this.maxKokanPull = maxKokanPull;
            this.kokanPullRate = kokanPullRate;
            this.kokanReturnRate = kokanReturnRate;

            this.enableOralPush = enableOralPush;
            this.maxOralPush = maxOralPush;
            this.maxOralPull = maxOralPull;
            this.oralPullRate = oralPullRate;
            this.oralReturnRate = oralReturnRate;

            this.enableAnaPush = enableAnaPush;
            this.maxAnaPush = maxAnaPush;
            this.maxAnaPull = maxAnaPull;
            this.anaPullRate = anaPullRate;
            this.anaReturnRate = anaReturnRate;

            frontCollisionInfo = frontInfo;
            backCollisonInfo = backInfo;
        }

        public CollisionOptions(bool enablePush, float maxPush, float maxPull, float pullRate, float returnRate)
        {
            kokanOffset = 0.0f;
            innerKokanOffset = 0.0f;
            mouthOffset = 0.0f;
            innerMouthOffset = 0.0f;

            kokan_adjust = false;
            kokan_adjust_position_z = 0;
            kokan_adjust_position_y = 0;
            kokan_adjust_rotation_x = 0;
            clippingDepth = 0;

#if HS2 || AI
            enableKokanPush = enablePush;
#else
            enableKokanPush = false;
#endif
            maxKokanPush = maxPush;
            maxKokanPull = maxPull;
            kokanPullRate = pullRate;
            kokanReturnRate = returnRate;

            enableOralPush = enablePush;
            maxOralPush = maxPush;
            maxOralPull = maxPull;
            oralPullRate = pullRate;
            oralReturnRate = returnRate;

#if HS2 || AI
            enableAnaPush = enablePush;
#else
            enableAnaPush = false;
#endif
            maxAnaPush = maxPush;
            maxAnaPull = maxPull;
            anaPullRate = pullRate;
            anaReturnRate = returnRate;

            frontCollisionInfo = null;
            backCollisonInfo = null;
        }
    }
}
