using Ninject;
using Voorbeeld02_DISamurai;

//Create a new DI container
var kernel = new StandardKernel();
//Tell the container to resolve an instance of the Sword class when it's asked for an IWeapon
kernel.Bind<IWeapon>().To<Sword>();
//Tell the container to resolve an instance of the Dagger class when it's asked for an IWeapon
kernel.Bind<IWeapon>().To<Dagger>();

//Ask the container to get in instance of the Samurai class and to resolve all of it's dependencies
var warrior = kernel.Get<Samurai>();
warrior.Attack("the evildoers");
Console.ReadLine();