package thefarm

import "errors"
import "fmt"

// See types.go for the types defined for this exercise.

// TODO: Define the SillyNephewError type here.
type SillyNephewError struct {
	cows int
}

func (e *SillyNephewError) Error() string {
	return fmt.Sprintf("silly nephew, there cannot be %d cows", e.cows)
}

// DivideFood computes the fodder amount per cow for the given cows.
func DivideFood(weightFodder WeightFodder, cows int) (float64, error) {
	negativeFodderError := errors.New("negative fodder")
	divisionByZeroError := errors.New("division by zero")
	cowsAsFloat := float64(cows)

	fodderAmount, err := weightFodder.FodderAmount()

	if err != nil && err != ErrScaleMalfunction {
		return 0, err
	}

	if err == ErrScaleMalfunction {
		fodderAmount *= 2
	}

	if fodderAmount < 0 {
		return 0.0, negativeFodderError
	}

	if cows == 0 {
		return 0.0, divisionByZeroError
	}

	if cows < 0 {
		return 0, &SillyNephewError{cows: cows}
	}

	return fodderAmount / cowsAsFloat, nil

}
