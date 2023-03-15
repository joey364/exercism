package elon

import "fmt"

// the Drive method updates the number of metres driven based on
// a car's speed and reduces the battery accordingly
func (car *Car) Drive() {
	if car.battery < car.batteryDrain {
		return
	}
	car.distance += car.speed
	car.battery -= car.batteryDrain
}

// DisplayDistance returns the distance as displayed on the LED display
func (car Car) DisplayDistance() string {

	return fmt.Sprintf("Driven %d meters", car.distance)
}

// DisplayDistance returns the battery percentage as displayed on the LED display
func (car Car) DisplayBattery() string {

	return fmt.Sprintf("Battery at %d%%", car.battery)
}

// CanFinish takes a trackDistance int as its parameter and returns true
// if the car can finish the race; otherwise, returns false
func (car Car) CanFinish(trackDistance int) bool {
	maxTravelDistance := (car.battery / car.batteryDrain) * car.speed
	return maxTravelDistance >= trackDistance
}
