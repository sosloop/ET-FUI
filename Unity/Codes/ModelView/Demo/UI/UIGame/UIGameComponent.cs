namespace ET
{
    public class UIGameComponent : Entity, IAwake
    {
        public UI_GameForm View { get => this.Parent.GetComponent<UI_GameForm>();} 
    }
}