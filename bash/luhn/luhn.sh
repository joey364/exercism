#!/usr/bin/env bash

# check if a given string is valid by the luhn algorithm

quit() {
	echo false
	exit
}

luhn() {
	inputStr="$*"
	number="${inputStr// /}"
	[[ $number =~ ^[0-9]*$ ]] || quit
	[[ ${#number} -gt 1 ]] || quit

	declare -i sum=0 digit

	for ((i = 1; i <= ${#number}; i++)); do
		digit=${number:$((-i)):1}
		((i % 2 == 0)) && ((digit *= 2)) && ((digit > 9)) && ((digit -= 9))
		((sum += digit))
	done

	((sum % 10 == 0)) && echo true || echo false
}

main() {
	luhn $1
}

main "$@"
