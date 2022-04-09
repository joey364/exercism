#!/usr/bin/env bash

main() {
	input=$1

	if [[ $input == 'total' ]]; then
		bc <<<'(2 ^ 64) - 1'
	elif [[ $input -le 0 || $input -gt 64 ]]; then
		echo "Error: invalid input"
		exit 1
	else
		bc <<<2^$((input - 1))
	fi

}

main "$@"
