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

	case $# in
	0)
		print_usage
		;;
	1)
		print_usage
		;;
	2)
		# check if both strands are of the same length
		if [[ "${#dna_strand_1}" != "${#dna_strand_2}" ]]; then
			wrong_length_msg
		fi

		# check if one string is longer than the other
		if [[ "${#dna_strand_1}" -gt "${#dna_strand_2}" || "${#dna_strand_1}" -lt "${#dna_strand_2}" ]]; then
			wrong_length_msg
		fi

		# if both strings are empty provide count
		if [[ -z "${dna_strand_1}" && -z "${dna_strand_2}" ]]; then
			echo $count
			exit 0
		fi

		# check if one of the strings are empty
		if [[ -z "${dna_strand_1}" || -z "${dna_strand_2}" ]]; then
			wrong_length_msg
		fi

		# loop over the string and compare each char
		for ((i = 0; i < ${#dna_strand_1}; i++)); do
			if [[ "${dna_strand_1:$i:1}" != "${dna_strand_2:$i:1}" ]]; then
				((count++))
			fi
		done
		;;
	*)
		print_usage
		;;
	esac

	echo $count
}

main "$@"
