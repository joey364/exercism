package lasagna

// PreparationTime returns the preparation time for a given list of layers.
func PreparationTime(layers []string, timePerLayer int) int {
	if timePerLayer < 1 {
		return len(layers) * 2
	}
	return len(layers) * timePerLayer
}

// Qantities returns the quantities of the ingredients for a given list of layers.
func Quantities(layers []string) (int, float64) {
	sauceLayerCount := 0
	noodleLayerCount := 0

	for _, v := range layers {
		if v == "sauce" {
			sauceLayerCount++
		}
		if v == "noodles" {
			noodleLayerCount++
		}
	}

	return noodleLayerCount * 50, float64(sauceLayerCount) * 0.2
}

// AddIngredients adds the secret ingredient to your recipe.
func AddSecretIngredient(friendList []string, myList []string) {
	myList[len(myList)-1] = friendList[len(friendList)-1]
}

// ScaleRecipe scales the recipe by the given number of portions.
func ScaleRecipe(amountForTwoPortions []float64, numberToServe int) []float64 {
	result := make([]float64, len(amountForTwoPortions))
	for i := 0; i < len(amountForTwoPortions); i++ {
		result[i] = amountForTwoPortions[i] * float64(numberToServe) / 2
	}
	return result
}
