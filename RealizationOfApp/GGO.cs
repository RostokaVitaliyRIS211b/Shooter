

namespace RealizationOfApp
{
    public class GGO:AbstractEventDrawable
    {
        public float ForceOfGravity = 0.2f;
        public IList<IGameObject> gameObjects;
        public List<IMovableObject> movableObjects;
        public List<AbstractEventDrawable> abstractEventDrawables;
        public GGO( AbstractGGOFactory factory):base(factory)
        {
            gameObjects = factory.GetGameObjects();
            movableObjects = new(from gameObj in gameObjects
                                 where gameObj is IMovableObject
                                 let movable = gameObj as IMovableObject
                                 select movable);
            abstractEventDrawables = new(from gameObj in gameObjects
                                         where gameObj is AbstractEventDrawable
                                         let absEvDr = gameObj as AbstractEventDrawable
                                         select absEvDr);
        }
        public override void InvokeAction(object source, EventType eventType, EventArgs eventArgs)
        {
            foreach (AbstractEventDrawable drawable in abstractEventDrawables)
                drawable.InvokeAction(this, eventType, eventArgs);
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            foreach(IMovableObject movable in movableObjects)
            {
                IEnumerable<IGameObject> coll = gameObjects.Where(x => x!=movable && x.Contains(movable.GetBounds().ToArray()));
                movable.Collision(this, coll);
            }
            foreach(IMovableObject movableObject in movableObjects)
            {
                if (movableObject.IsGravityOn)
                    movableObject.DeltaY += ForceOfGravity;
                if(Math.Abs(movableObject.Position.Y+movableObject.Size.Y/2-movableObject.BottomCoord)<=1)
                    movableObject.DeltaX = movableObject.DeltaX==0 ? 0 : movableObject.DeltaX > 0 ? movableObject.DeltaX-movableObject.ForceOfTrenie : movableObject.DeltaX + movableObject.ForceOfTrenie;
                Application.degubText.DisplayedString = movableObject.DeltaX.ToString();
            }
            foreach(IGameObject gameObject in gameObjects)
            {
                target.Draw(gameObject, states);
            }
        }
        #region Nah
        public override void AddAction(EventType eventType, WinEventHandler<EventArgs> action)
        {

        }
        public override void ClearAction(EventType eventType)
        {

        }
        #endregion
    }
}
