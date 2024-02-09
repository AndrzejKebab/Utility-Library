using UnityEngine;

namespace UtilityLibrary.Unity.Runtime
{
    public static class Rigidbody2DExtensions
    {
        #region Clear
        /// <summary>
        /// Clears the momentum of the Rigidbody2D instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody2D instance.</param>
        public static void ClearMomentum(this Rigidbody2D rigidbody)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0f;
        }
        #endregion

        #region Position
        #region Set
        /// <summary>
        /// Sets the x position of the Rigidbody2D instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody2D instance.</param>
        /// <param name="x">The x position.</param>
        public static void SetPositionX(this Rigidbody2D rigidbody, float x)
        {
            var position = rigidbody.position;
            position.x = x;
            rigidbody.position = position;
        }

        /// <summary>
        /// Sets the y position of the Rigidbody2D instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody2D instance.</param>
        /// <param name="y">The y position.</param>
        public static void SetPositionY(this Rigidbody2D rigidbody, float y)
        {
            var position = rigidbody.position;
            position.y = y;
            rigidbody.position = position;
        }
        #endregion

        #region Get
        /// <summary>
        /// Gets the x position of the Rigidbody2D instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody2D instance.</param>
        /// <returns>The x position.</returns>
        public static float GetPositionX(this Rigidbody2D rigidbody)
        {
            return rigidbody.position.x;
        }

        /// <summary>
        /// Gets the y position of the Rigidbody2D instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody2D instance.</param>
        /// <returns>The y position.</returns>
        public static float GetPositionY(this Rigidbody2D rigidbody)
        {
            return rigidbody.position.y;
        }
        #endregion
        #endregion

        #region Velocity
        #region Set
        /// <summary>
        /// Sets the x velocity of the Rigidbody2D instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody2D instance.</param>
        /// <param name="x">The x velocity.</param>
        public static void SetVelocityX(this Rigidbody2D rigidbody, float x)
        {
            var velocity = rigidbody.velocity;
            velocity.x = x;
            rigidbody.velocity = velocity;
        }

        /// <summary>
        /// Sets the y velocity of the Rigidbody2D instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody2D instance.</param>
        /// <param name="y">The y velocity.</param>
        public static void SetVelocityY(this Rigidbody2D rigidbody, float y)
        {
            var velocity = rigidbody.velocity;
            velocity.y = y;
            rigidbody.velocity = velocity;
        }
        #endregion
        
        #region Get
        /// <summary>
        /// Gets the x velocity of the Rigidbody2D instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody2D instance.</param>
        /// <returns>The x velocity.</returns>
        public static float GetVelocityX(this Rigidbody2D rigidbody)
        {
            return rigidbody.velocity.x;
        }

        /// <summary>
        /// Gets the y velocity of the Rigidbody2D instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody2D instance.</param>
        /// <returns>The y velocity.</returns>
        public static float GetVelocityY(this Rigidbody2D rigidbody)
        {
            return rigidbody.velocity.y;
        }
        #endregion

        #region Add
        /// <summary>
        /// Adds to the x velocity of the Rigidbody2D instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody2D instance.</param>
        /// <param name="x">The x velocity to add.</param>
        public static void AddVelocityX(this Rigidbody2D rigidbody, float x)
        {
            var velocity = rigidbody.velocity;
            velocity.x += x;
            rigidbody.velocity = velocity;
        }

        /// <summary>
        /// Adds to the y velocity of the Rigidbody2D instance.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody2D instance.</param>
        /// <param name="y">The y velocity to add.</param>
        public static void AddVelocityY(this Rigidbody2D rigidbody, float y)
        {
            var velocity = rigidbody.velocity;
            velocity.y += y;
            rigidbody.velocity = velocity;
        }
        #endregion
        #endregion
    }
}