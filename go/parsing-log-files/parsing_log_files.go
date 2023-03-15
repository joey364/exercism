package parsinglogfiles

import (
	"regexp"
)

func IsValidLine(text string) bool {
	re := regexp.MustCompile(`^(\[TRC\]|\[DBG\]|\[INF\]|\[WRN\]|\[ERR\]|\[FTL\])`)
	return re.MatchString(text)
}

func SplitLogLine(text string) []string {
	re := regexp.MustCompile(`<(\*|~|=|-)*>`)
	return re.Split(text, -1)
}

func CountQuotedPasswords(lines []string) int {
	re := regexp.MustCompile(`(?i)".*password.*"`)
	count := 0
	for _, line := range lines {
		if re.MatchString(line) {
			count += 1
		}
	}
	return count
}

func RemoveEndOfLineText(text string) string {
	re := regexp.MustCompile(`(end-of-line\d+)+`)

	return re.ReplaceAllString(text, "")
}

func TagWithUserName(lines []string) []string {
	var result []string
	re := regexp.MustCompile(`\s+User\s+(\S+)`)

	for _, line := range lines {
		match := re.FindStringSubmatch(line)
		if re.MatchString(line) {
			line = "[USR] " + match[1] + " " + line
		}
		result = append(result, line)
	}
	return result
}
