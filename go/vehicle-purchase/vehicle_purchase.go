package purchase

import (
	"fmt"
	"strings"
)

// NeedsLicense determines whether a license is needed to drive a type of vehicle. Only "car" and "truck" require a license.
func NeedsLicense(kind string) bool {
	return kind == "car" || kind == "truck"
}

// ChooseVehicle recommends a vehicle for selection. It always recommends the vehicle that comes first in lexicographical order.
func ChooseVehicle(option1, option2 string) string {
	betterCar := option2
	// option1 > option2
	if strings.Compare(option1, option2) == -1 {
		betterCar = option1
	}
	return fmt.Sprintf("%s is clearly the better choice.", betterCar)
}

func Compare(b bool) {
	panic("unimplemented")
}

// CalculateResellPrice calculates how much a vehicle can resell for at a certain age.
func CalculateResellPrice(originalPrice, age float64) float64 {
	if age >= 10 {
		return originalPrice * 0.5
	} else if age >= 3 && age < 10 {
		return originalPrice * 0.7
	} else if age < 3 {
		return originalPrice * 0.8

	}
	return originalPrice
}
