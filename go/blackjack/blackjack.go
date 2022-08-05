package blackjack

// ParseCard returns the integer value of a card following blackjack ruleset.
func ParseCard(card string) int {
	switch card {
	case "ace":
		return 11
	case "two":
		return 2
	case "three":
		return 3
	case "four":
		return 4
	case "five":
		return 5
	case "six":
		return 6
	case "seven":
		return 7
	case "eight":
		return 8
	case "nine":
		return 9
	case "ten":
		return 10
	case "jack":
		return 10
	case "queen":
		return 10
	case "king":
		return 10
	default:
		return 0
	}
}

// inRange returns true if the value is in the range [min, max].
func inRange(value, lowerBound, upperBound int) bool {
	return value >= lowerBound && value <= upperBound
}

// FirstTurn returns the decision for the first turn, given two cards of the
// player and one card of the dealer.
func FirstTurn(card1, card2, dealerCard string) string {
	result := "win"
	cardSum := ParseCard(card1) + ParseCard(card2)
	dealerCardValue := ParseCard(dealerCard)

	switch {
	case card1 == "ace" && card2 == "ace":
		result = "P"
	case cardSum == 21 && (dealerCard != "ace" && dealerCardValue != 10):
		result = "W"
	case cardSum == 21 && (dealerCard == "ace" || dealerCardValue == 10):
		result = "S"
	case inRange(cardSum, 17, 20):
		result = "S"
	case (inRange(cardSum, 12, 16)) && dealerCardValue < 7:
		result = "S"
	case (inRange(cardSum, 12, 16)) && dealerCardValue >= 7:
		result = "H"
	case inRange(cardSum, 0, 11):
		result = "H"
	}

	return result
}
