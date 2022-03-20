#!/usr/bin/env bash

print_usage() {
	echo "Usage: hamming.sh <string1> <string2>"
	exit 1
}

wrong_length_msg() {
	echo "strands must be of equal length"
	exit 1
}

main() {
	dna_strand_1=$1
	dna_strand_2=$2

	count=0

	# accept the right number of args
	if [[ $# != 2 ]]; then
		print_usage
	fi

	# check if both strands are of the same length
	if [[ "${#dna_strand_1}" != "${#dna_strand_2}" ]]; then
		wrong_length_msg
	fi

	# loop over the string and compare each char
	for ((i = 0; i < ${#dna_strand_1}; i++)); do
		if [[ "${dna_strand_1:$i:1}" != "${dna_strand_2:$i:1}" ]]; then
			((count++))
		fi
	done

	echo $count
}

main "$@"
