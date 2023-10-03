using Ninject;
using Voorbeeld01_DIEmailSender;

var kernel = new StandardKernel();
//Tell the container to resolve an instance of the EmailSender class when it's asked for an IEmailSender
kernel.Bind<IEmailSender>().To<EmailSender>();

//Ask the container to get in instance of the PasswordResetHelper class and to resolve all of it's dependencies
var passwordResetHelper = kernel.Get<PasswordResetHelper>();
passwordResetHelper.ResetPassword();
