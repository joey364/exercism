package interest

// InterestRate returns the interest rate for the provided balance.
func InterestRate(balance float64) float32 {
	var rate float32
	switch {
	case balance < 0:
		rate = float32(3.213)
	case balance >= 0 && balance < 1000:
		rate = float32(0.5)
	case balance >= 1000 && balance < 5000:
		rate = float32(1.621)
	case balance >= 5000:
		rate = float32(2.475)
	}
	return rate
}

// Interest calculates the interest for the provided balance.
func Interest(balance float64) float64 {
	rate := InterestRate(balance)

	return float64(rate/100) * balance
}

// AnnualBalanceUpdate calculates the annual balance update, taking into account the interest rate.
func AnnualBalanceUpdate(balance float64) float64 {
	interset := Interest(balance)

	return balance + interset
}

// YearsBeforeDesiredBalance calculates the minimum number of years required to reach the desired balance.
func YearsBeforeDesiredBalance(balance, targetBalance float64) int {
	var years int
	for balance < targetBalance {
		balance = AnnualBalanceUpdate(balance)
		years++
	}
	return years
}
