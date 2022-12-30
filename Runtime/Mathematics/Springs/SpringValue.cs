
namespace Lab5Games.Mathematics
{
    /// <summary>
    /// https://github.com/llamacademy/juicy-springs/tree/main/Assets/Scripts/Spring
    /// </summary>
    public abstract class SpringValue<T>
    {
        public virtual float damping { get; set; } = 26f;
        public virtual float mass { get; set; } = 1f;
        public virtual float stiffness { get; set; } = 169f;

        public virtual T startValue { get; internal set; }
        public virtual T endValue { get; internal set; }
        public virtual T initialVelocity { get; internal set; }
        public virtual T currentValue { get; internal set; }
        public virtual T currentVelocity { get; internal set; }

        /// <summary>
        /// Reset all values to initial states.
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// Update the end value in the middle of motion.
        /// This reuse the current velocity and interpolate the value smoothly afterwards.
        /// </summary>
        /// <param name="Value">End value</param>
        public virtual void UpdateEndValue(T Value) => UpdateEndValue(Value, currentVelocity);

        /// <summary>
        /// Update the end value in the middle of motion but using a new velocity.
        /// </summary>
        /// <param name="Value">End value</param>
        /// <param name="Velocity">New velocity</param>
        public abstract void UpdateEndValue(T Value, T Velocity);

        /// <summary>
        /// Advance a step by deltaTime(seconds).
        /// </summary>
        /// <param name="DeltaTime">Delta time since previous frame</param>
        /// <returns>Evaluated value</returns>
        public abstract T Evaluate(float DeltaTime);
    }
}
