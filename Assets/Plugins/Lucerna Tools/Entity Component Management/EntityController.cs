using UnityEngine;

namespace Lucerna.Entities
{
	public class EntityController : EntityComponentManager
	{
		// VARIABLES
		private EntityAnimationLibrary cachedAnimator;

		public EntityAnimationLibrary Animator
		{
			get
			{
				if (cachedAnimator == null)
				{
					cachedAnimator = Get<EntityAnimationLibrary>();
				}

				return cachedAnimator;
			}
		}

        // EXECUTION FUNCTIONS

		// METHODS
		public virtual void OnActivated() { }
		public virtual void OnDeactivated() { }
	}
}