using Oefening_02_01_SRP;

var serviceStationUtility = new ServiceStationUtility();
var serviceStation = new ServiceStation(serviceStationUtility);

serviceStation.OpenForService();
serviceStation.DoService();
serviceStation.CloseForDay();