

var services = new DIServiceCollection();

services.RegisterTransient<IRandomGuidProvider,RandomGuidProvider>();
services.RegisterTransient<ISomeService,SomeServiceOne>();

var container = services.GenerateContainer();

var instanceOne = container.GetService<ISomeService>();
var instanceTwo = container.GetService<ISomeService>();

instanceOne.PrintMessage();
instanceTwo.PrintMessage();

