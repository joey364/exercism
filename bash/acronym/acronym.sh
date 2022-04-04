#!/usr/bin/env bash

main() {
	local str
	local acronym=''

	# format string to have only letters and spaces
	str=$(sed 's/[_\*]//g; s/-/ /g' <<<"$1")

	for word in $str; do
		acronym+=${word:0:1}
	done

	echo ${acronym^^}
}

main "$@"
