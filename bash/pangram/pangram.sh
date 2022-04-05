#!/usr/bin/env bash

main() {

	local str=${1,,}

	for letter in {a..z}; do
		if [[ ! $str =~ $letter ]]; then
			echo false
			exit 0
		fi
	done

	echo true
}

main "$@"
