interface IActivationObjects 
{
    public void SetActivateTrigger(TriggerEvent trigger) 
    {
        trigger.OnActivate += OnActivate;
    }

    public void OnActivate();

    public void OnDiactivate();
}
