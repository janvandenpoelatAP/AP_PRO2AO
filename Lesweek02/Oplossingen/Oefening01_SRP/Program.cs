using Oefening01_SRP;

var serviceStationUtility = new ServiceStationUtility();
var serviceStation = new ServiceStation(serviceStationUtility);

serviceStation.OpenForService();
serviceStation.DoService();
serviceStation.CloseForDay();