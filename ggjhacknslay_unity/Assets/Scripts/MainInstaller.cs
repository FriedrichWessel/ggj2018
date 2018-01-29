using Zenject;

public class MainInstaller : MonoInstaller
{
	public PlayerCamera PlayerCam;
	
	public override void InstallBindings()
	{
		Container.DeclareSignal<NewWalkTargetSignal>();
		Container.DeclareSignal<KeyPressedSignal>();
		Container.DeclareSignal<TargetAquiredSignal>();
		Container.DeclareSignal<GameStartSignal>();
		Container.DeclareSignal<GameOverSignal>();
		Container.DeclareSignal<ItemSelectedSignal>();
		Container.DeclareSignal<ShowLootPickerSignal>();
		Container.Bind<GameModel>().AsSingle();
		Container.Bind<TaskSystem>().AsSingle();
		Container.Bind<ITickable>().To<InputSystem>().AsSingle().NonLazy();
		Container.Bind<ITickable>().To<TaskSystem>().AsSingle().NonLazy();
		Container.Bind<IPlayerCamera>().FromInstance(PlayerCam).AsSingle();
		Container.Bind<IRandomGenerator>().To<UnityRandomGenerator>().AsSingle();
		Container.Bind<IObjectInstantiator>().To <ZenjectObjectIInstantiator>().AsSingle();
	}
}
