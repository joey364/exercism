// Package weather provides tools
// helpful for weather forecast.
package weather

// CurrentCondition stores the current weather condition.
var CurrentCondition string

// CurrentLocation stores the current location.
var CurrentLocation string

// Forecast returns the weather forcast for a city given the weather condition.
func Forecast(city, condition string) string {
	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}
