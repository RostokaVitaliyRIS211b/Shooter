namespace RealizationOfApp
{
    public class GGO:AbstractEventDrawable
    {
        public float ForceOfGravity = 0.2f;
        public int oldCount = 0;
        public IList<IGameObject> gameObjects;
        public List<IMovableObject> movableObjects;
        public List<AbstractEventDrawable> abstractEventDrawables;
        public GGO( AbstractGGOFactory factory):base(factory)
        {
            gameObjects = factory.GetGameObjects();
            oldCount = gameObjects.Count;
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
            if(gameObjects.Count!=oldCount)
            {
                movableObjects = new(from gameObj in gameObjects
                                     where gameObj is IMovableObject
                                     let movable = gameObj as IMovableObject
                                     select movable);
                abstractEventDrawables = new(from gameObj in gameObjects
                                             where gameObj is AbstractEventDrawable
                                             let absEvDr = gameObj as AbstractEventDrawable
                                             select absEvDr);
                oldCount = gameObjects.Count;
            }
            foreach (AbstractEventDrawable drawable in abstractEventDrawables)
                drawable.InvokeAction(this, eventType, eventArgs);
            DeleteObjects();
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            if (gameObjects.Count!=oldCount)
            {
                movableObjects = new(from gameObj in gameObjects
                                     where gameObj is IMovableObject
                                     let movable = gameObj as IMovableObject
                                     select movable);
                abstractEventDrawables = new(from gameObj in gameObjects
                                             where gameObj is AbstractEventDrawable
                                             let absEvDr = gameObj as AbstractEventDrawable
                                             select absEvDr);
                oldCount = gameObjects.Count;
            }
            foreach (IMovableObject movable in movableObjects)
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
                //Application.degubText.DisplayedString = movableObject.DeltaX.ToString();
            }
            DeleteObjects();
            foreach (IGameObject gameObject in gameObjects)
            {
                target.Draw(gameObject, states);
            }       
        }
        public void DeleteObjects()
        {
            List<IGameObject> isNeedRemove = new(from elem in gameObjects
                                                 where (elem.IsNeedToRemove)
                                                              select elem);
            foreach (IGameObject eventDrawable in isNeedRemove)
                gameObjects.Remove(eventDrawable);
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
