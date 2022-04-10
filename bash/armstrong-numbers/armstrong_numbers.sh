#!/usr/bin/env bash

main() {
	# determine whether a number is an Armstrong number.
	local num=$1
	local sum=0
	local temp=$num
	local digit_count=${#num}

	while [ $temp -gt 0 ]; do
		local remainder=$(($temp % 10))
		sum=$(($sum + $remainder ** $digit_count))
		temp=$(($temp / 10))
	done

	[ $sum -eq $num ] && echo "true" || echo "false"
}

main "$@"
