#!/usr/bin/env bash

main() {
	local str="$1"
	local acronym=''

	# format string to have only letters and spaces
	str=${str//-/ }
	str=${str//[_\*]/}

	for word in $str; do
		acronym+=${word:0:1}
	done

	echo ${acronym^^}
}

main "$@"
