using System;
using UnityEngine;

namespace Lab5Games.Mathematics
{
    public class SpringVector3 : SpringValue<Vector3>
    {
        SpringFloat m_x = new SpringFloat();
        SpringFloat m_y = new SpringFloat();
        SpringFloat m_z = new SpringFloat();


        public override float damping 
        { 
            get => base.damping; 
            
            set
            {
                m_x.damping = value;
                m_y.damping = value;
                m_z.damping = value;
                base.damping = value;
            }
        }

        public override float mass
        {
            get => base.mass;

            set
            {
                m_x.mass = value;
                m_y.mass = value;
                m_z.mass = value;
                base.mass = value;
            }
        }

        public override float stiffness 
        { 
            get => base.stiffness; 
            
            set
            {
                m_x.stiffness = value;
                m_y.stiffness = value;
                m_z.stiffness = value;
                base.stiffness = value;
            }
        }

        public override Vector3 startValue
        {
            get => new Vector3(
                m_x.startValue, 
                m_y.startValue, 
                m_z.startValue);

            internal set
            {
                m_x.startValue = value.x;
                m_y.startValue = value.y;
                m_z.startValue = value.z;
            }
        }

        public override Vector3 endValue
        {
            get => new Vector3(
                m_x.endValue, 
                m_y.endValue, 
                m_z.endValue);

            internal set
            {
                m_x.endValue = value.x;
                m_y.endValue = value.y;
                m_z.endValue = value.z;
            }
        }

        public override Vector3 initialVelocity
        {
            get => new Vector3(
                m_x.initialVelocity, 
                m_y.initialVelocity, 
                m_z.initialVelocity);

            internal set
            {
                m_x.initialVelocity = value.x;
                m_y.initialVelocity = value.y;
                m_z.initialVelocity = value.z;
            }
        }

        public override Vector3 currentVelocity
        {
            get => new Vector3(
                m_x.currentVelocity,
                m_y.currentVelocity,
                m_z.currentVelocity);

            internal set
            {
                m_x.currentVelocity = value.x;
                m_y.currentVelocity = value.y;
                m_z.currentVelocity = value.z;
            }
        }

        public override Vector3 currentValue
        {
            get => new Vector3(
                m_x.currentValue,
                m_y.currentValue,
                m_z.currentValue);

            internal set
            {
                m_x.currentValue = value.x;
                m_y.currentValue = value.y;
                m_z.currentValue = value.z;
            }
        }

        public override void Reset()
        {
            m_x.Reset();
            m_y.Reset();
            m_z.Reset();
        }

        public override void UpdateEndValue(Vector3 Value, Vector3 Velocity)
        {
            m_x.UpdateEndValue(Value.x, Velocity.x);
            m_y.UpdateEndValue(Value.y, Velocity.y);
            m_z.UpdateEndValue(Value.z, Velocity.z);
        }

        public override Vector3 Evaluate(float DeltaTime)
        {
            currentValue = new Vector3(
                m_x.Evaluate(DeltaTime),
                m_y.Evaluate(DeltaTime),
                m_z.Evaluate(DeltaTime));

            currentVelocity = new Vector3(
                m_x.currentVelocity,
                m_y.currentVelocity,
                m_z.currentVelocity);


            return currentValue;
        }
    }
}
