#!/usr/bin/env bash

matching_brackets() {
	local -A brackets=(
		["]"]="["
		[")"]="("
		["}"]="{"
	)
	stack=""

	for ((i = 0; i < ${#1}; i++)); do
		char=${1:i:1}
		# [^|]
		if [[ $char =~ [\[|\(|\{] ]]; then
			stack+=$char
		elif [[ $char =~ [\]|\)|\}] ]]; then
			if [[ -z $stack || $stack != *"${brackets[$char]}" ]]; then
				echo false
				exit
			else
				stack=${stack%?}
			fi
		fi
	done

	[[ -z $stack ]] && echo true || echo false
}

matching_brackets "$@"
