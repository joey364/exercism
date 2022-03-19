#!/usr/bin/env bash

main() {
	if [ -z "$1" ]; then
		person="you"
	else
		person="$1"
	fi
	echo "One for ${person}, one for me."
}
main "$@"
