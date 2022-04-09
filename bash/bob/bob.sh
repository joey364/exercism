#!/usr/bin/env bash

isQuestion() {
	[[ $sentence =~ \?\ *$ ]]
}

isYelling() {
	[[ ${sentence} =~ ^[^[:lower:]]+$ && ${sentence} =~ [[:upper:]] ]]
}

isSilence() {
	[[ $sentence =~ ^[[:space:]]*$ ]]
}

main() {
	local sentence=$1

	if isSilence; then
		echo "Fine. Be that way!"
	elif isYelling && isQuestion; then
		echo "Calm down, I know what I'm doing!"
	elif isYelling; then
		echo "Whoa, chill out!"
	elif isQuestion; then
		echo "Sure."
	else
		echo "Whatever."
	fi
}

main "$@"
