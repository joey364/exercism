#!/usr/bin/env bash

# print usage of script
print_usage() {
	echo "Usage: error_handling.sh <person>"
	exit 1
}

main() {
	person=$1
	case "$#" in
	0)
		print_usage
		;;
	1)
		echo "Hello, $person"
		;;
	*)
		print_usage
		;;
	esac
}

main "$@"
