#!/usr/bin/env bash

function scrabble_score {
	local word=${1,,}
	local score=0
	local letter_score=0

	for ((i = 0; i < ${#word}; i++)); do
		letter=${word:$i:1}

		if [[ ${letter} =~ [aeioulnrst] ]]; then
			letter_score=1
		elif [[ ${letter} =~ [dg] ]]; then
			letter_score=2
		elif [[ ${letter} =~ [bcmp] ]]; then
			letter_score=3
		elif [[ ${letter} =~ [fhvwy] ]]; then
			letter_score=4
		elif [[ ${letter} =~ [k] ]]; then
			letter_score=5
		elif [[ ${letter} =~ [jx] ]]; then
			letter_score=8
		elif [[ ${letter} =~ [qz] ]]; then
			letter_score=10
		fi

		score=$((score + letter_score))
	done

	echo ${score}
}

main() {
	scrabble_score ${1}
}

main "$@"
