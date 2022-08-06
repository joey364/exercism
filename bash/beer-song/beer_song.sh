#!/usr/bin/env bash

gen_verse() {
	verse_no=$1
	template="xxx bottles of beer on the wall, xxx bottles of beer.
Take one down and pass it around, ddd bottles of beer on the wall."

	output=$template

	# make substititions in template when appropriate
	if [ "$verse_no" -eq 2 ]; then
		output=${output//xxx/2}
		output=${output//ddd bottles/1 bottle}
	elif [ "$verse_no" -eq 1 ]; then
		output=${output//xxx bottles/1 bottle}
		output=${output//one/it}
		output=${output//ddd/no more}
	elif [ "$verse_no" -eq 0 ]; then
		output=${output//xxx/no more}
		output=${output//Take one down and pass it around/Go to the store and buy some more}
		output=${output//ddd/99}
		output=$(echo "$output" | sed 's/^n/N/')
	else
		output=${output//xxx/$verse_no}
		output=${output//ddd/$((verse_no - 1))}
	fi

	echo "$output"
}

beer_song() {
	local -i start=$1
	local -i end=$2

	case $# in
	1) gen_verse "$1" ;;
	2)
		# test "$start" -le "$end" && echo "si" || echo "non"
		if ((start <= end)); then
			echo "Start must be greater than End" >&2
			exit 1
		fi
		for ((i = "$1"; i >= "$2"; i--)); do
			gen_verse "$i"
			echo
		done
		;;
	*)
		echo "1 or 2 arguments expected" >&2
		echo "usage: ${0##*/} verse_num" >&2
		echo "   or: ${0##*/} start end" >&2
		exit 2
		;;
	esac

}

beer_song "$@"
