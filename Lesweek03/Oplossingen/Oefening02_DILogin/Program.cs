using Ninject;
using Oefening02_DILogin;

var kernel = new StandardKernel();
kernel.Bind<ILogin>().To<HardCodedLoginAdapter>();

Console.WriteLine(kernel.ToString());

var verySecretApplication = kernel.Get<VerySecretApplication>();
verySecretApplication.Start();
Console.ReadLine();